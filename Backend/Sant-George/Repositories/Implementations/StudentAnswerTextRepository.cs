using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Interfaces;

namespace SantGeorgeWebsite.Repositories.Implementations
{
    public class StudentAnswerTextRepository : GenericRepository<StudentAnswerText>, IStudentAnswerTextRepository
    {
        public StudentAnswerTextRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
