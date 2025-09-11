using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Sant_George.Models.User;

namespace Sant_George.Models.Exam
{
    public class TeacherMarkExam
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Teacher))]
        public string TeacherId { get; set; }
        public virtual ApplicationUser Teacher { get; set; }

        [ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

    }
}
