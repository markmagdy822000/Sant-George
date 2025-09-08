using Microsoft.AspNetCore.Identity;

namespace SantGeorgeWebsite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public Gender Gender{ get; set; }
        public int Class{ get; set; } 
    }
    public enum Gender
    {
        Male, Female
    }
}
