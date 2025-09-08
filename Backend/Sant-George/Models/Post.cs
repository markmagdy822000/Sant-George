using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace SantGeorgeWebsite.Models
{
    public class Post
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate{ get; set; }
        public DateTime UpdateDate{ get; set; }
    }
}
