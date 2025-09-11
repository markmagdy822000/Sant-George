using Sant_George.Models.ExamModels;
using Sant_George.Repositories.Interfaces.Exam;
using Sant_George.Models;
using Sant_George.Repositories.Implementations;
using Sant_George.DTOs.Exam;

namespace Sant_George.Repositories.Implementations.Exam
{
    public class StudentAssignedExamRepository : GenericRepository<StudentAssignedExam>, IStudentAssignedExamRepository
    {
        public StudentAssignedExamRepository(SantGeorgeWebsiteDBContext context) : base(context) { }
        public async Task<List<StudentAssignedExam>> GetAllStudentExams(string studentId)
        {
            return _context.StudentAssignedExam.Where(e => e.StudentId == studentId).ToList();
        }

    }
}
