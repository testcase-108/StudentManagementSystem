using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.DAL.StudentCourseDAL
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly AppDbContext _context;

        public StudentCourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void EnrolleStudentToCourse(int studentId, int courseId)
        {
            var StudentCourse = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };
            _context.StudentCourses.Add(StudentCourse);
            _context.SaveChanges();
        }

        public void DeleteEnrollment(int studentId, int courseId)
        {
            var enrollment = _context.StudentCourses
                .FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            if (enrollment != null)
            {
                _context.StudentCourses.Remove(enrollment);
                _context.SaveChanges();
            }
        }


        public StudentCourseDTO? GetEnrollmentDetail(int studentId, int courseId)
        {
            var enrollment = _context.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == courseId);

            if (enrollment == null || enrollment.Student == null || enrollment.Course == null)
                return null;

            return new StudentCourseDTO
            {
                StudentId = enrollment.Student.StudentId,
                StudentFirstName = enrollment.Student.FirstName!,
                StudentLastName = enrollment.Student.LastName!,
                CourseId = enrollment.Course.CourseId,
                CourseTitle = enrollment.Course.Title!
            };
        }

        public IEnumerable<StudentCourseDTO> GetAllStuCou()
        {
            var result = _context.StudentCourses
                .Where(sc => sc.Student != null && sc.Course != null)
                .Select(sc => new StudentCourseDTO
                {
                    StudentId = sc.Student.StudentId,
                    StudentFirstName = sc.Student.FirstName!,
                    StudentLastName = sc.Student.LastName!,
                    CourseId = sc.Course.CourseId,
                    CourseTitle = sc.Course.Title!
                }).ToList();
            return result;
        }

        public IEnumerable<Course> GetCoursesByStudentId(int studentId)
        {
            return _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Include(sc => sc.Course)
                .Select(sc => sc.Course!)
                .ToList();
        }

        public IEnumerable<Student> GetStudentByCourseId(int courseId)
        {
            return _context.StudentCourses
                .Where(sc => sc.CourseId == courseId)
                .Include(sc => sc.Student)
                .Select(sc => sc.Student)
                .ToList();
        }
    }
}