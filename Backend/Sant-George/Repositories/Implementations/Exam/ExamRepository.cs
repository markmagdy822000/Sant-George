using Sant_George.Repositories.Interfaces.Exam;
using Sant_George.Models.Exam;
using Sant_George.Models;
using Sant_George.Repositories.Implementations;


namespace Sant_George.Repositories.Implementations.Exam
{
    public class ExamRepository : GenericRepository<Sant_George.Models.Exam.Exam>, IExamRepository
    {
        public ExamRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
