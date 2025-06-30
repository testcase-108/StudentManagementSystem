using System.Collections.Generic;
using WebApplication7.model;
using System.Linq;
using WebApplication7.Data;
using WebApplication7.DTO;

namespace WebApplication7.StuCourseDAL
{
    public interface IStuCourseRepository
    {
        IEnumerable<StudentCourse> GetAll();
        StudentCourse? GetByIds(int studentId, int courseId);
        void Add(StudentCourse studentCourse);
        //void Update(StudentCourse studentCourse);
        void Delete(int studentId, int courseId);
        void Save();
    }
}