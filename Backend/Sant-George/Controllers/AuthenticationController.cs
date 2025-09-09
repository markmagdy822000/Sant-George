using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using Sant_George_Website.DTOs;
using Sant_George_Website.UnitOfWorks;
using SantGeorgeWebsite.Models;

namespace Sant_George_Website.Controllers
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

        public AuthenticationController(
            IUnitOfWorks unit,
            IMapper mapper,
            IEmailSender mailSender,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AuthenticationController> logger)
        {
            _unit = unit;
            _mapper = mapper;
            _mailSender = mailSender;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
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

            #region JWT Token Generation
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
            };
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is my secrect key for the SantGeorge project"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7), // Changed from 10000 days to 7 days
                signingCredentials: credentials,
                notBefore: DateTime.UtcNow // Token valid from now
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            #endregion
            return Ok(new
            {
                token = tokenString,
                expires = token.ValidTo,
                userId = user.Id,
                email = user.Email,
                username= user.UserName
            });
        }

        [AllowAnonymous]
        [HttpGet("forgot-password")]
        // public async Task<IActionResult> ForgetPassword([FromBody] ForgotPasswordDTO forgotPasswordDTO)
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
    }
}