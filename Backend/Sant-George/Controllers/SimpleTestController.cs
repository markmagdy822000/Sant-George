//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace Sant_George_Website.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class SimpleTestController : ControllerBase
//    {
//        [HttpGet("no-auth")]
//        public IActionResult NoAuth()
//        {
//            return Ok("Working - No Auth Required");
//        }

//        [Authorize]
//        [HttpGet("with-auth")]
//        public IActionResult WithAuth()
//        {
//            return Ok(new
//            {
//                message = "Authentication Success!",
//                isAuthenticated = HttpContext.User.Identity?.IsAuthenticated,
//                userName = HttpContext.User.Identity?.Name,
//                authType = HttpContext.User.Identity?.AuthenticationType
//            });
//        }

//        [HttpGet("check-token")]
//        public IActionResult CheckToken()
//        {
//            var authHeader = Request.Headers["Authorization"].ToString();
//            var hasBearer = authHeader.StartsWith("Bearer ");
//            var tokenPart = hasBearer ? authHeader.Substring(7) : authHeader;

//            return Ok(new
//            {
//                hasAuthHeader = !string.IsNullOrEmpty(authHeader),
//                hasBearer = hasBearer,
//                tokenLength = tokenPart.Length,
//                tokenStart = tokenPart.Length > 20 ? tokenPart.Substring(0, 20) + "..." : tokenPart,
//                tokenParts = tokenPart.Split('.').Length, // Should be 3 for valid JWT
//                userAuthenticated = HttpContext.User.Identity?.IsAuthenticated ?? false
//            });
//        }
//    }
//}