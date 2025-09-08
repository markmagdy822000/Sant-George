using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Interfaces;

namespace SantGeorgeWebsite.Repositories.Implementations
{
    public class StudentAnswerChooseRepository : GenericRepository<StudentAnswerChoose>, IStudentAnswerChooseRepository
    {
        public StudentAnswerChooseRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
