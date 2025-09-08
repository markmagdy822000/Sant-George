using System.ComponentModel.DataAnnotations.Schema;

namespace SantGeorgeWebsite.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Degree { get; set; }
        [ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
