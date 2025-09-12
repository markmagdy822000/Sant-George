using System.ComponentModel.DataAnnotations.Schema;
using Sant_George.Models.User;

namespace Sant_George.Models.ExamModels
{
    public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        //public int MaxDegree { get; set; } //should be calculated from questions degree, exam should have percentage
        //public int MinDegree { get; set; }
        public string? Description { get; set; }
        [ForeignKey(nameof(Teacher))]
        public string TeacherId { get; set; }
        public virtual ApplicationUser Teacher { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

    }
}
