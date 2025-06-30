using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DAL.StudentDAL;
using StudentManagementSystem.Models;
using StudentManagementSystem.DTO;
namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var student = _service.GetAllStudent();
            return Ok(student);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _service.GetStudentById(id);
            return Ok(student);
        }
        
        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentAddDto stuAddDto)
        {
            _service.AddNewStudent(stuAddDto);
            return Ok(stuAddDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentDto stuDto)
        {
            _service.UpdateStudent(id, stuDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _service.DeleteStudent(id);
            return NoContent();
        }
    }
}

