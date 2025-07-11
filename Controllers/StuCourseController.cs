using Microsoft.AspNetCore.Mvc;
using WebApplication7.model;
using System.Collections.Generic;
using WebApplication7.DTO;
using WebApplication7.StuCourseDAL;
using WebApplication7.CourseDAL;
using WebApplication7.DAL;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StuCourseController : ControllerBase
    {
        private readonly StuCourseSevice _service;
        private readonly StudentService _studentService;
        private readonly CourseService _courseService;

        public StuCourseController(StuCourseSevice service, StudentService studentService, CourseService courseService)
        {
            _service = service;
            _studentService = studentService;
            _courseService = courseService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<StuCourseDetailDTO>> GetAll()
        {
            var detailDtos = _service.GetAllStuCourses();
            return Ok(detailDtos);
        }

        [HttpGet("{studentId}/{courseId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<StuCourseDetailDTO> GetByIds(int studentId, int courseId)
        {
            var detailDto = _service.GetStuCourseByIds(studentId, courseId);
            if (detailDto == null)
                return NotFound();

            return Ok(detailDto);
        }

        [HttpPut("{studentId}/{courseId}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Update(int studentId, int courseId, [FromBody] StuCourseDTO dto)
        {
            var existing = _service.GetStuCourseByIds(studentId, courseId);

            var newAssociation = new StuCourseDTO
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };

            _service.AddStuCourse(newAssociation);
            return NoContent();
        }

        [HttpDelete("{studentId}/{courseId}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int studentId, int courseId)
        {
            var existing = _service.GetStuCourseByIds(studentId, courseId);
            if (existing == null)
                return NotFound();

            _service.DeleteStuCourse(studentId, courseId);
            return NoContent();
        }
    }
}