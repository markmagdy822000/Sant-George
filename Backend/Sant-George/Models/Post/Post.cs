using System.ComponentModel.DataAnnotations.Schema;
using Sant_George.Models.User;

namespace Sant_George.Models.PostModels
{
    public class Post
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
