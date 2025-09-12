using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sant_George.DTOs.Exam;
using Sant_George.Models.ExamModels;
using Sant_George.Models.User;
using Sant_George.UnitOfWorks;

namespace Sant_George.Controllers.Exam
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        public IUnitOfWorks _unit;
        public IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public ExamController(
            IUnitOfWorks unit,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)

        {
            _unit = unit;
            _mapper = mapper;
            _userManager = userManager;
        }

        #region Student
        [Authorize]
        [HttpGet("StudentExams")]
        public async Task<IActionResult> GetAllStudentExams()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId == null) { return BadRequest(new { message = "no user found" }); };

            var examsDto = _mapper.Map<List<ExamDTO>>(await _unit.StudentAssignedExamRepository.GetAllStudentExams(userId));

            return Ok(new
            {
                message = "exams returd",
                exams = examsDto
            });
        }
        #endregion

        #region Teacher

      
        [Authorize]
        [HttpGet("TeacherExams")]
        public async Task<IActionResult> GetAllTeacherExams()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId == null) { return BadRequest(new { message = "no user found" }); };

            var exmaDto = _mapper.Map<List<ExamDTO>>(await _unit.ExamRepository.GetAllTeahcerExams(userId));
            return Ok(new
            {
                message = "exams returd",
                exams = exmaDto
            });
        }

        [Authorize]
        [HttpPost("AddExam")]
        public async Task<IActionResult> AddExam(ExamDTO examDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId == null) { return BadRequest(new { message = "no user found" }); };

            //var user = await _userManager.FindByIdAsync(userId);
            //var roles = await _userManager.GetRolesAsync(user);
            //if (!roles.Contains("Teacher")) return Unauthorized(new { message = "you are not authorized to add exam, you need to be a teacher first!" });
            if (!await isTeacher(userId)) 
                return Unauthorized(new { message = "you are not authorized to add exam, you need to be a teacher first!" });
            if (examDto == null) return BadRequest(new { message = "examDto cannot be null" });
            var exam = _mapper.Map<Sant_George.Models.ExamModels.Exam>(examDto);
            await _unit.ExamRepository.AddAsync(exam);
            await _unit.SaveChanges();
            return Ok(new { message = "exam created successfully✅" });
        }
        public string getUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return userId;

        }

        public async Task<bool> isTeacher(string userId) {

            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);
                if (!roles.Contains("Teacher")) return false;
            return true;
            
        }

        [Authorize]
        [HttpDelete("DeleteExam/{Id}")]
        public async Task<IActionResult> DeleteExam(int Id)
        {
            var userId = getUserId();
            if(userId==null) { return BadRequest(new { message = "no user found" }); };

            if (!await isTeacher(userId))
                return Unauthorized(new { message = "you are not authorized to remove exam, you need to be a teacher first!" });

            await _unit.ExamRepository.DeleteAsync(Id);
            await _unit.SaveChanges();
            return Ok(new { message = "exam deleted successfully✅" });
        }
       
        [Authorize]
        [HttpPut("UpdateExam")]
        public async Task<IActionResult> UpdateExam(ExamDTO examDto)
        {
            var userId = getUserId();
            if (userId == null) 
                return BadRequest(new { message = "no user found" });

            if (!await isTeacher(userId))
                return Unauthorized(new { message = "you are not authorized to update exam, you need to be a teacher first!" });
            
            if(examDto.TeacherId != userId) 
                return Unauthorized(new { message="you are not exam owner!"});
            var exam = await _unit.ExamRepository.GetByIdAsync(examDto.Id??0);
            
            //mapping manual as the auto mapping create new object which is not allowed in update
            exam.Description = examDto?.Description;
            exam.StartDate = examDto.StartDate;
            exam.Duration = examDto.Duration;
            exam.Title = examDto.Title;
            foreach (var questionDto in examDto.Questions)
            {
                //var question = await _unit.QuestionRepository.GetByIdAsync(questionDto.Id ?? 0);
                var question = exam.Questions.Where(q=>q.Id  == questionDto.Id).FirstOrDefault();
                
                question.Title = questionDto.Title;
                question.Degree = questionDto.Degree;
                //question.Answers
                foreach (var answerDto in questionDto.Answers)
                {
                    //var answer = await _unit.AnswerRepository.GetByIdAsync(answerDto.Id ?? 0);
                    var answer = question.Answers.Where(a=>a.Id == answerDto.Id).FirstOrDefault();
                    answer.Text = answerDto.Text;
                    answer.IsCorrect = answerDto.IsCorrect;
                }
            }
            await _unit.ExamRepository.UpdateAsync(exam, exam.Id);
            await _unit.SaveChanges();

            return Ok(new { message = "exam updated sucessfully✅" });
        }
        [Authorize]
        [HttpGet("ExamDetails/{examId}")]
        public async Task<IActionResult> GetExamById(int examId)
        {
            var exam = await _unit.ExamRepository.GetByIdAsync(examId);
            var examDto = _mapper.Map<ExamDTO>(exam);
            if (exam == null) return BadRequest(new { message="exam not found!"});
            return Ok(new { exam = examDto , message="exam returned successfully✅"});
        }
        #endregion
    }
}
