using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Interfaces;

namespace SantGeorgeWebsite.Repositories.Implementations
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
