using System.Collections.Generic;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
namespace StudentManagementSystem.DAL.StudentCourseDAL
{
    public interface IStudentCourseRepository
    {
        IEnumerable<StudentCourseDTO> GetAllStuCou();
        IEnumerable<Course> GetCoursesByStudentId(int studentId);
        IEnumerable<Student> GetStudentByCourseId(int courseId);

        StudentCourseDTO? GetEnrollmentDetail(int studentId, int courseId);
        void EnrolleStudentToCourse(int studentId, int courseId);
        void DeleteEnrollment(int studentId, int courseId);
    }
}

