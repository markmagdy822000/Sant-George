using Sant_George.Models.ExamModels;
using Sant_George.Repositories.Interfaces;

namespace Sant_George.Repositories.Interfaces.Exam
{
    public interface IExamRepository : IGenericRepository<Sant_George.Models.ExamModels.Exam>
    {
        public Task<List<Sant_George.Models.ExamModels.Exam>> GetAllTeahcerExams(string teacherId);
    }
}
