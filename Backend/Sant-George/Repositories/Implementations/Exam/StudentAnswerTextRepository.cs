using Sant_George.Models.ExamModels;
using Sant_George.Repositories.Interfaces.Exam;
using Sant_George.Models;
using Sant_George.Repositories.Implementations;

namespace Sant_George.Repositories.Implementations.Exam
{
    public class StudentAnswerTextRepository : GenericRepository<StudentAnswerText>, IStudentAnswerTextRepository
    {
        public StudentAnswerTextRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
