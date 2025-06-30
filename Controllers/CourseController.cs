using System.Collections.Generic;
using WebApplication7.model;
using System.Linq;
using WebApplication7.Data;
using WebApplication7.CourseDAL;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.DTO;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDTO>> GetAllCourses()
        {
            var courses = _courseService.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public ActionResult<CourseDTO> GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);
            return Ok(course);
        }

        [HttpPost]
        public IActionResult AddCourse([FromBody] CoursetitleDTO coursedto)
        {
            
            _courseService.AddCourse(coursedto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] CourseDTO coursedto)
        {
            _courseService.UpdateCourse(coursedto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            _courseService.DeleteCourse(id);
            return NoContent();
        }
    }
}
