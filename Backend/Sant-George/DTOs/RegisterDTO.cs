using SantGeorgeWebsite.Models;

namespace Sant_George_Website.DTOs
{
    public class RegisterDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Class { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
