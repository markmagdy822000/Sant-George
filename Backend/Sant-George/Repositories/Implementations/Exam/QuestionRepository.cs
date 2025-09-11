using Sant_George.Models.ExamModels;
using Sant_George.Repositories.Interfaces.Exam;
using Sant_George.Models;
using Sant_George.Repositories.Implementations;

namespace Sant_George.Repositories.Implementations.Exam
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
