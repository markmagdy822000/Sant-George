using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace SantGeorgeWebsite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
