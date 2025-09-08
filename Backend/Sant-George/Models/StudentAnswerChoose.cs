using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SantGeorgeWebsite.Models
{
    public class StudentAnswerChoose
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        public virtual ApplicationUser Student { get; set; }
        [ForeignKey(nameof(Answer))]
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
