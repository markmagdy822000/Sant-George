using System.ComponentModel.DataAnnotations.Schema;

namespace Sant_George.Models.User
{
    public class Phonenumber
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int phonenumber { get; set; }
    }
}
