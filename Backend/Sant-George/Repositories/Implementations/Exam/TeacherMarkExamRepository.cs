using Sant_George.Models.Exam;
using Sant_George.Repositories.Interfaces.Exam;
using Sant_George.Models;
using Sant_George.Repositories.Implementations;

namespace Sant_George.Repositories.Implementations.Exam
{
    public class TeacherMarkExamRepository : GenericRepository<TeacherMarkExam>, ITeacherMarkExamRepository
    {
        public TeacherMarkExamRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
