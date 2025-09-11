using Sant_George.Models;
using Sant_George.Models.ExamModels;
using Sant_George.Repositories.Interfaces.Exam;


namespace Sant_George.Repositories.Implementations.Exam
{
    public class ExamRepository : GenericRepository<Sant_George.Models.ExamModels.Exam>, IExamRepository
    {
        public ExamRepository(SantGeorgeWebsiteDBContext context) : base(context){}
      

        public async Task<List<Sant_George.Models.ExamModels.Exam>> GetAllTeahcerExams(string teacherId)
        {
            return  _context.Exams.Where(e=>e.TeacherId== teacherId).ToList();
        }

    }
}
