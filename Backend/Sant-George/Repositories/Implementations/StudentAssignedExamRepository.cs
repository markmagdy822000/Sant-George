using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Interfaces;

namespace SantGeorgeWebsite.Repositories.Implementations
{
    public class StudentAssignedExamRepository : GenericRepository<StudentAssignedExam>, IStudentAssignedExamRepository
    {
        public StudentAssignedExamRepository(SantGeorgeWebsiteDBContext context) : base(context)
        {
        }
    }
}
