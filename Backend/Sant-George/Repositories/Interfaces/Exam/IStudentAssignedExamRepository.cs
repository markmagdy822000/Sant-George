using Sant_George.DTOs.Exam;
using Sant_George.Models.ExamModels;
using Sant_George.Repositories.Interfaces;

namespace Sant_George.Repositories.Interfaces.Exam
{
    public interface IStudentAssignedExamRepository : IGenericRepository<StudentAssignedExam>
    {
        Task<List<StudentAssignedExam>> GetAllStudentExams(string studentId);

    }
}
