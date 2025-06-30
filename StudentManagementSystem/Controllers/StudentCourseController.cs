using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DAL.StudentCourseDAL;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Data;
using System.Linq;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly StudentCourseServices _service;
        private readonly AppDbContext _context;

        public StudentCourseController(StudentCourseServices service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var enrollments = _service.GetAllStuCourse();
            return Ok(enrollments);
        }

        [HttpGet("student/{studentId}/courses")]
        public IActionResult GetCoursesByStudentId(int studentId)
        {
            var courses = _service.GetCoursesByStudentId(studentId);
            return Ok(courses);
        }

        [HttpGet("course/{courseId}/students")]
        public IActionResult GetStudentByCourseId(int courseId)
        {
            var students = _service.GetStudentByCourseId(courseId);
            return Ok(students);
        }

        [HttpGet("{studentId}/{courseId}")]
        public IActionResult GetEnrollmentDetails(int studentId, int courseId)
        {
            var enrollmentDto = _service.GetEnrollmentDetails(studentId, courseId);
            return Ok(enrollmentDto);
        }

        [HttpPut("enroll")]
        public IActionResult EnrollStudentToCourse([FromBody] EnrollRequestDTO request)
        {
            _service.EnrolletStudentToCourse(request.StudentId, request.CourseId);
            return Ok();
        }

        [HttpDelete("{studentId}/{courseId}")]
        public IActionResult DeleteEnrollment(int studentId, int courseId)
        {
            _service.DeleteEnrollment(studentId, courseId);
            return Ok();
        }
    }
}
