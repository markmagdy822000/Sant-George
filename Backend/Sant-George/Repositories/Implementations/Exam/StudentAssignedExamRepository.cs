using Sant_George.Models.Exam;
using Sant_George.Repositories.Interfaces.Exam;
using Sant_George.Models;
using Sant_George.Repositories.Implementations;

namespace Sant_George.Repositories.Implementations.Exam
{
    public class StudentAssignedExamRepository : GenericRepository<StudentAssignedExam>, IStudentAssignedExamRepository
    {
        public StudentAssignedExamRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
