using Sant_George.Models.ExamModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sant_George.DTOs.Exam
{
    public class AnswerDTO
    {
        public int? Id { get; set; }

        public string Text { get; set; }
        public bool? IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
