using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sant_George.Models.User;

namespace Sant_George.Models.Exam
{
    public class StudentAssignedExam
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        public virtual ApplicationUser Student { get; set; }
        [ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
