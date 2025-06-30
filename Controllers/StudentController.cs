using Microsoft.AspNetCore.Mvc;
using WebApplication7.model;
using WebApplication7.Data;
using System.Collections.Generic;
using WebApplication7.DTO;
using WebApplication7.DAL;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StuDTOWithId>> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            //var studentDtos = students.Select(s => new Student
            //{
            //    StudentId = s.StudentId,
            //    FirstName = s.FirstName,
            //    LastName = s.LastName
            //});
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<StuDTOWithId> GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StuDTO studto)
        {
            _studentService.AddStudent(studto);
            return Ok(studto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StuDTOWithId student)
        {
            _studentService.UpdateStudent(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
