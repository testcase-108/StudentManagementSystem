using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using WebApplication7.DAL;
using WebApplication7.DTO;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;
        //private readonly Use

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, AdminStudent")]
        public ActionResult<StuDTOWithId> GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            return Ok(student);
        }

        [HttpGet("Mydetails")]
        [Authorize(Roles = "Student")]
        public ActionResult<StuDTOWithId> GetMyDetails()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var student = _studentService.GetStudentById(int.Parse(userId));
            return Ok(student);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, AdminStudent")]
        public ActionResult<IEnumerable<StuDTOWithId>> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        

        [HttpPost]
        [Authorize(Roles = "Admin, AdminStudent")]
        public IActionResult AddStudent([FromBody] StuDTO studto)
        {
            _studentService.AddStudent(studto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, AdminStudent")]
        public IActionResult UpdateStudent(int id, [FromBody] StuDTOWithId student)
        {
            student.StudentId = id;
            _studentService.UpdateStudent(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, AdminStudent")]
        public IActionResult DeleteStudentById(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
