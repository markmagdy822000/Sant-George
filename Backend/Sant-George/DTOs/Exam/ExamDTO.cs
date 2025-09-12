using System.ComponentModel.DataAnnotations.Schema;
using Sant_George.Models.ExamModels;
using Sant_George.Models.User;

namespace Sant_George.DTOs.Exam
{
    public class ExamDTO
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        //public int MaxDegree { get; set; }
        //public int MinDegree { get; set; }
        public string? Description { get; set; }
        public string TeacherId { get; set; }
        //public virtual ApplicationUser Teacher { get; set; }
        public virtual ICollection<QuestionDTO> Questions { get; set; }

    }

}
