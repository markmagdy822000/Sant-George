using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sant_George.DTOs.Exam;
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
                return Unauthorized(new { message = "you are not authorized to add exam, you need to be a teacher first!" });

            await _unit.ExamRepository.DeleteAsync(Id);
            await _unit.SaveChanges();
            return Ok(new { message = "exam deleted successfully✅" });
        }

        #endregion
    }
}
