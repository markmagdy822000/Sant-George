using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Interfaces;

namespace SantGeorgeWebsite.Repositories.Implementations
{
    public class TeacherMarkExamRepository : GenericRepository<TeacherMarkExam>, ITeacherMarkExamRepository
    {
        public TeacherMarkExamRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
