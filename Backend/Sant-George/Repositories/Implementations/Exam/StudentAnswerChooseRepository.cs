using Sant_George.Models.Exam;
using Sant_George.Repositories.Interfaces.Exam;
using Sant_George.Models;
using Sant_George.Repositories.Implementations;

namespace Sant_George.Repositories.Implementations.Exam
{
    public class StudentAnswerChooseRepository : GenericRepository<StudentAnswerChoose>, IStudentAnswerChooseRepository
    {
        public StudentAnswerChooseRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
