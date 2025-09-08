using Microsoft.EntityFrameworkCore.Diagnostics;
using Sant_George_Website.Repositories.Interfaces;
using SantGeorgeWebsite.Models;
using SantGeorgeWebsite.Repositories.Implementations;
using SantGeorgeWebsite.Repositories.Interfaces;

namespace Sant_George_Website.UnitOfWorks
{
    public interface IUnitOfWorks
    {
        //IAnswerRepository AnswerRepository { get; }
        //ICommentRepository CommentRepository { get; set; }
        //IExamRepository ExamRepository { get; set; }
        //IPhonenumberRepository PhonenumberRepository { get; set; }
        //IPostRepository PostRepository { get; set; }
        //IQuestionRepository QuestionRepository { get; set; }
        //IServiceRepository ServiceRepository { get; set; }

        ICommentRepository CommentRepository { get; }
        IExamRepository ExamRepository { get; }
        IPhonenumberRepository PhonenumberRepository { get; }
        IPostRepository PostRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IStudentAnswerChooseRepository StudentAnswerChooseRepository { get; }
        IStudentAnswerTextRepository StudentAnswerTextpository { get; }
        IStudentAssignedExamRepository StudentAssignedExamRepository { get; }
        ITeacherMarkExamRepository TeacherMarkExamRepository { get; }
        IUserParentRepository UserParentRepository { get; }
        IUserServiceRoleRepository UserServiceRoleRepository { get; }
        Task SaveChanges();
    }
}
