using Sant_George.Models.ExamModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sant_George.DTOs.Exam
{
    public class QuestionDTO
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public float Degree { get; set; }
        //[ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }
        public virtual ICollection<AnswerDTO> Answers { get; set; }
        public QuestionType  Type { get; set; }

    }
}
