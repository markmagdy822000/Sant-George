using Microsoft.EntityFrameworkCore;

namespace Sant_George.Models
{
    [Owned]
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime ExpiresOn{ get; set; }
        public DateTime CreatedOn { get; set; } 
        public bool IsActive => !IsExpired && RevokedOn == null;
        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
        public DateTime? RevokedOn { get; set; }
    }
}
