using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace SantGeorgeWebsite.Models
{
    public class UserServiceRole
    {
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Service Service { get; set; }
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public RoleType Role{ get; set; }
    }
    public enum RoleType
    {
        Student=0, Teacher=1, Admin=2, Super_Admin=4, Parent=8
    }
}
