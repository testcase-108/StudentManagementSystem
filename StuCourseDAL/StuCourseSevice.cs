using System.Collections.Generic;
using WebApplication7.model;
using System.Linq;
using WebApplication7.Data;
using WebApplication7.DTO;

namespace WebApplication7.StuCourseDAL
{
    public class StuCourseSevice
    {
        private readonly IStuCourseRepository _stucourserepo;

        public StuCourseSevice(IStuCourseRepository stucourserepo)
        {
            _stucourserepo = stucourserepo;
        }

        public IEnumerable<StuCourseDetailDTO> GetAllStuCourses()
        {
            return _stucourserepo.GetAll().Select(sc => new StuCourseDetailDTO
            {
                StudentId = sc.StudentId,
                StudentFirstName = sc.Student.FirstName,
                StudentLastName = sc.Student.LastName,
                CourseId = sc.CourseId,
                CourseTitle = sc.Course.Title
            });
        }

        public StuCourseDetailDTO? GetStuCourseByIds(int studentId, int courseId)
        {
            var sc = _stucourserepo.GetByIds(studentId, courseId);
            if (sc == null) return null;

            return new StuCourseDetailDTO
            {
                StudentId = sc.StudentId,
                StudentFirstName = sc.Student.FirstName,
                StudentLastName = sc.Student.LastName,
                CourseId = sc.CourseId,
                CourseTitle = sc.Course.Title
            };
        }

        public void AddStuCourse(StuCourseDTO dto)
        {
            
            var studentCourse = new StudentCourse
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                
            };
            _stucourserepo.Add(studentCourse);
            _stucourserepo.Save();
        }

        public void DeleteStuCourse(int studentId, int courseId)
        {
            _stucourserepo.Delete(studentId, courseId);
            _stucourserepo.Save();
        }
    }
}
