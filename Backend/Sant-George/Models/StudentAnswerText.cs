using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SantGeorgeWebsite.Models
{
    
    public class StudentAnswerText
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        public virtual ApplicationUser Student { get; set; }
        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public string? Text{ get; set; }
    }
}
