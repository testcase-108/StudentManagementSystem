using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.DAL.StudentCourseDAL
{
    public class StudentCourseServices
    {
        private readonly IStudentCourseRepository _studentCourseRepository;

        public StudentCourseServices(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }

        public IEnumerable<StudentCourseDTO> GetAllStuCourse() => _studentCourseRepository.GetAllStuCou();
        
        public IEnumerable<Course> GetCoursesByStudentId(int studentId)
        {
            return _studentCourseRepository.GetCoursesByStudentId(studentId);
        }

        public IEnumerable<Student> GetStudentByCourseId(int courseId)
        {
            return _studentCourseRepository.GetStudentByCourseId(courseId);
        }

        public void EnrolletStudentToCourse(int studentId, int courseId)
        {
            _studentCourseRepository.EnrolleStudentToCourse(studentId, courseId);
        }

        public void DeleteEnrollment(int studentId, int courseId)
        {
            _studentCourseRepository.DeleteEnrollment(studentId,courseId);
        }

        public StudentCourseDTO? GetEnrollmentDetails(int studentId, int courseId)
        {
            return _studentCourseRepository.GetEnrollmentDetail(studentId, courseId);
        }
        
    }
}