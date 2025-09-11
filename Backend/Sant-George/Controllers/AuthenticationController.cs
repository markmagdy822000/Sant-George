using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sant_George.DTOs.Auth;
using Sant_George.Models.User;
using Sant_George.UnitOfWorks;

namespace Sant_George.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        public IUnitOfWorks _unit;
        public IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AuthenticationController> _logger;
        public IEmailSender _mailSender;
        public IConfiguration _config;
        public AuthenticationController(
            IUnitOfWorks unit,
            IMapper mapper,
            IEmailSender mailSender,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AuthenticationController> logger,
            IConfiguration config)

        {
            _unit = unit;
            _mapper = mapper;
            _mailSender = mailSender;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _config = config;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ApplicationUser user = _mapper.Map<ApplicationUser>(registerDto);
            user.Id = Guid.NewGuid().ToString();
            if (registerDto.Gender.ToLower() == "male") user.Gender = Gender.Male;
            else user.Gender = Gender.Female;

            ApplicationUser existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
                return BadRequest("User with this email already exists");

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            _userManager.AddToRolesAsync(user, ["User"]);

            #region Email Confirmation
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = $"{Request.Scheme}://{Request.Host}/api/ConfirmEmail/EmailConfirmed?userId={user.Id}&token={Uri.EscapeDataString(token)}";
            await _mailSender.SendEmailAsync(user.Email, "Confirm your Email",
                $"Please Confirm your account by clicking this link: \n<a href='{confirmationLink}'>Click Here</a>\n");
            #endregion

            return Ok("Registration successful! Please check your email to confirm account");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ApplicationUser user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return Unauthorized(new { errors = new[] { "No User Found with this email!" } });

            var found = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!found)
                return BadRequest(new { errors = new[] { "Invalid User Email or Password" } });

            AuthDTO? authDTO = new AuthDTO();


            #region JWT Token Generation

            var token = await GenerateAccessToken(user);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            authDTO.token = tokenString;
            authDTO.expires = token.ValidTo;
            #endregion

            #region handle refresh token

            RefreshToken RefreshToken = new RefreshToken();

            if (user.RefreshTokens.Any(r => r.IsActive))
            {
                RefreshToken = user.RefreshTokens.FirstOrDefault(r => r.IsActive);
                authDTO.refreshToken = RefreshToken.Token;
                authDTO.refreshTokenExpiresOn = RefreshToken.ExpiresOn;
            }
            else
            {
                RefreshToken = GenerateRefreshToken();
                authDTO.refreshToken = RefreshToken.Token;
                authDTO.refreshTokenExpiresOn = RefreshToken.ExpiresOn;
                user.RefreshTokens.Add(RefreshToken);
                await _userManager.UpdateAsync(user);
            }

            AddRefreshTokenToCookie(RefreshToken);
            authDTO.userId = user.Id;
            authDTO.email = user.Email;
            authDTO.username = user.UserName;
            authDTO.roles = await _userManager.GetRolesAsync(user);

            #endregion
            return Ok(authDTO);
        }
        public void AddRefreshTokenToCookie(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions()
            {
                Expires = new DateTimeOffset(refreshToken.ExpiresOn.ToLocalTime()),
                HttpOnly = true,
                // Change to Secure=true //on production
                Secure = false,
                SameSite = SameSiteMode.None
            };
            HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
        public async Task<JwtSecurityToken> GenerateAccessToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
            };
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JWTKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials,
                notBefore: DateTime.UtcNow
            );
            return token;
        }
        [AllowAnonymous]
        [HttpGet("forgot-password")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return Ok("user not found");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            //var baseURL = "https://SantGeorge.com";
            var baseURL = "http://localhost:4200";//front-end port
            var link = $"{baseURL}/reset-password?email={Uri.EscapeDataString(email)}&code={code}";

            var htmlMessage = $"Click here to reset your password <a href='{link}'> Reset Link</a>" +
                $" \n ignore link if you don't request";
            var subject = "Reset Password";
            await _mailSender.SendEmailAsync(email, subject, htmlMessage);
            return Ok(new { success = true, message = "Email was sent successfully✅" });
        }

        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
            if (user == null) return Ok();

            var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetPasswordDTO.code));

            var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordDTO.newPassword);
            if (!result.Succeeded) return Ok();
            return Ok(result);
        }
        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                CreatedOn = DateTime.UtcNow,
                ExpiresOn = DateTime.UtcNow.AddDays(30),
            };
        }

        [AllowAnonymous]
        [HttpPost("newTokens")]
        public async Task<IActionResult> GenerateNewRefreshAndAccessTokens(RefreshTokenDTO refreshTokenDto)
        {
            //if (oldToken == null) Request.Cookies["refreshToken"].ToString();
            //var oldToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshTokenDto.oldToken))
                return BadRequest(new AuthDTO { Message = "Refresh token not found" });

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(r => r.Token == refreshTokenDto.oldToken));
            if (user == null) return BadRequest(new AuthDTO { Message = "not valid" });

            var refreshToken = user.RefreshTokens.FirstOrDefault(r => r.Token == refreshTokenDto.oldToken);

            if (refreshToken.IsExpired) return BadRequest(new AuthDTO { Message = "token expired" });

            if (!refreshToken.IsActive) return BadRequest(new AuthDTO { Message = "token is not active (used before or expired)" });
            refreshToken.RevokedOn = DateTime.UtcNow;
            refreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);
            AddRefreshTokenToCookie(refreshToken);

            var accessToken = await GenerateAccessToken(user);
            return Ok(new AuthDTO
            {
                token = new JwtSecurityTokenHandler().WriteToken(accessToken),
                expires = accessToken.ValidTo,
                refreshToken = refreshToken.Token,
                refreshTokenExpiresOn = refreshToken.ExpiresOn,
                userId = user.Id,
                email = user.Email,
                username = user.UserName,
                roles = await _userManager.GetRolesAsync(user)
            });
        }

        [Authorize]
        [HttpGet("secured")]
        public IActionResult Secured()
        {
            return Ok("accessed✅");
        }
    }
}