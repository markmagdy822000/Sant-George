using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Sant_George.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public int Class { get; set; }
        [JsonIgnore]
        public List<RefreshToken>? RefreshTokens { get; set; }
        // added through user profile edit
        public string? Location { get; set; }
    }
    public enum Gender
    {
        Male, Female
    }
}
