using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DAL;
using StudentManagementSystem.Models;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _service;

        public CourseController(CourseService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddNewCourse([FromBody] CourseTitleDto courseDto)
        {
            _service.AddNewCourse(courseDto);
            return Ok(courseDto);
        }

        [HttpGet]
        public IActionResult GetAllCourse()
        {
            var course = _service.GetAllCourse();
            return Ok(course);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _service.GetCourseById(id);
            return Ok(course);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] CourseDto courseDto)
        {
            _service.UpdateCourse(id,courseDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            _service.DeleteCourse(id);
            return Ok(new { message = $"Course with ID {id} deleted successfully." });
        }
    }
}