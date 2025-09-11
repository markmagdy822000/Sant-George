using Microsoft.AspNetCore.Identity;
using Sant_George.Models;

namespace SantGeorgeWebsite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public Gender Gender{ get; set; }
        public int Class{ get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }
        // added through user profile edit
        public string? Location { get; set; }
    }
    public enum Gender
    {
        Male, Female
    }
}
