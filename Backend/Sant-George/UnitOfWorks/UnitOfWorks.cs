using Sant_George.Models;
using Sant_George.Repositories.Implementations;
using Sant_George.Repositories.Implementations.Exam;
using Sant_George.Repositories.Implementations.Post;
using Sant_George.Repositories.Implementations.User;
using Sant_George.Repositories.Interfaces;
using Sant_George.Repositories.Interfaces.Exam;
using Sant_George.Repositories.Interfaces.Post;
using Sant_George.Repositories.Interfaces.User;

namespace Sant_George.UnitOfWorks
{
    public class UnitOfWorks : IUnitOfWorks
    {
        SantGeorgeWebsiteDBContext _context { get; }
        public UnitOfWorks(SantGeorgeWebsiteDBContext context )
        {
            _context = context;
        }

        ICommentRepository commentRepository;
        public ICommentRepository CommentRepository { 
            get
            {
                if(commentRepository == null) commentRepository = new CommentRepository(_context);
                return commentRepository;
            } 
        }

        IExamRepository examRepository;
        public IExamRepository ExamRepository
        {
            get
            {
                if (examRepository == null) examRepository = new ExamRepository(_context);
                return examRepository;
            }
        }


        IPhonenumberRepository phonenumberRepository;
        public IPhonenumberRepository PhonenumberRepository
        {
            get
            {
                if (phonenumberRepository == null) phonenumberRepository = new PhonenumberRepository(_context);
                return phonenumberRepository;
            }
        }

        IPostRepository postRepository;
        public IPostRepository PostRepository
        {
            get
            {
                if (postRepository == null) postRepository = new PostRepository(_context);
                return postRepository;
            }
        }



        IQuestionRepository questionRepository;
        public IQuestionRepository QuestionRepository
        {
            get
            {
                if (questionRepository == null) questionRepository = new QuestionRepository(_context);
                return questionRepository;
            }
        }

        IServiceRepository serviceRepository;
        public IServiceRepository ServiceRepository
        {
            get
            {
                if (serviceRepository == null) serviceRepository = new ServiceRepository(_context);
                return serviceRepository;
            }
        }

        IStudentAnswerChooseRepository studentAnswerChooseRepository;
        public IStudentAnswerChooseRepository StudentAnswerChooseRepository
        {
            get
            {
                if (studentAnswerChooseRepository == null) studentAnswerChooseRepository = new StudentAnswerChooseRepository(_context);
                return studentAnswerChooseRepository;
            }
        }
        IStudentAnswerTextRepository studentAnswerTextRepository;
        public IStudentAnswerTextRepository StudentAnswerTextRepository
        {
            get
            {
                if (studentAnswerTextRepository == null) studentAnswerTextRepository = new StudentAnswerTextRepository(_context);
                return studentAnswerTextRepository;
            }
        }

        IStudentAssignedExamRepository studentAssignedExamRepository;
        public IStudentAssignedExamRepository StudentAssignedExamRepository
        {
            get
            {
                if (studentAssignedExamRepository == null) studentAssignedExamRepository = new StudentAssignedExamRepository(_context);
                return studentAssignedExamRepository;
            }
        }

        ITeacherMarkExamRepository teacherMarkExamRepository;
        public ITeacherMarkExamRepository TeacherMarkExamRepository
        {
            get
            {
                if (teacherMarkExamRepository == null) teacherMarkExamRepository = new TeacherMarkExamRepository(_context);
                return teacherMarkExamRepository;
            }
        }

        IUserParentRepository userParentRepository;
        public IUserParentRepository UserParentRepository
        {
            get
            {
                if (userParentRepository == null) userParentRepository = new UserParentRepository(_context);
                return userParentRepository;
            }
        }
        IUserServiceRoleRepository userServiceRoleRepository;
        public IUserServiceRoleRepository UserServiceRoleRepository
        {
            get
            {
                if (userServiceRoleRepository == null) userServiceRoleRepository = new UserServiceRoleRepository(_context);
                return userServiceRoleRepository;
            }
        }

        IAnswerRepository answerRepository;
        public IAnswerRepository AnswerRepository
        {
            get
            {
                if (answerRepository == null) answerRepository = new AnswerRepository(_context);
                return answerRepository;
            }
        }
        public async Task SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
