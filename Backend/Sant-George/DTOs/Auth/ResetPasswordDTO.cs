namespace Sant_George.DTOs.Auth
{
    public class ResetPasswordDTO
    {
        public string newPassword { get; set; }
        public string code { get; set; }
        public string Email { get; set; }
    }
}
