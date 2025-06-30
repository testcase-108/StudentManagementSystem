using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication7.Data;
using WebApplication7.model;

namespace WebApplication7.StuCourseDAL
{
    public class StuCourseRepository : IStuCourseRepository
    {
        private readonly AppDbContext _appDbContext;

        public StuCourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<StudentCourse> GetAll() => 
            _appDbContext.StuCourse
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .ToList();

        public StudentCourse GetByIds(int studentId, int courseId) =>
            _appDbContext.StuCourse
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == courseId);

        public void Add(StudentCourse studentCourse)
        {
            var student = _appDbContext.students.Find(studentCourse.StudentId);
            var course = _appDbContext.courses.Find(studentCourse.CourseId);

            studentCourse.Student = student;
            studentCourse.Course = course;

            _appDbContext.StuCourse.Add(studentCourse);
        }


        public void Delete(int studentId, int courseId)
        {
            var sc = GetByIds(studentId, courseId);
            if (sc != null)
            {
                _appDbContext.StuCourse.Remove(sc);
            }
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
