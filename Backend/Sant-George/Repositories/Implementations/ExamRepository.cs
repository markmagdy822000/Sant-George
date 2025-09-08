using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Interfaces;

namespace SantGeorgeWebsite.Repositories.Implementations
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        public ExamRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
