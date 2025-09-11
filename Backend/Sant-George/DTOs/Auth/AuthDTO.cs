using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Sant_George.DTOs.Auth
{
    public class AuthDTO
    {
        public string token { get; set; }
        public DateTime expires { get; set; }
        //[JsonIgnore]
        public string refreshToken { get; set; }
        public DateTime refreshTokenExpiresOn { get; set; }
        public string userId { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public IList<string> roles { get; set; }
        public string Message { get; set; }

    }
}
