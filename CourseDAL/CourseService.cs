using System.Collections.Generic;
using System.Linq;
using WebApplication7.DTO;
using WebApplication7.model;

namespace WebApplication7.CourseDAL
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }
        public Course? GetCourseById(int id)
        {
            return _courseRepository.GetById(id);
        }
        public void AddCourse(CoursetitleDTO course)
        {
            
            _courseRepository.Add(course);
            _courseRepository.Save();
        }
        public void UpdateCourse(Course course)
        {
            var courseDTO = new CourseDTO
            {
                Title = course.Title
            };
            _courseRepository.Update(courseDTO);
            _courseRepository.Save();
        }
        public void DeleteCourse(int id)
        {
            _courseRepository.Delete(id);
            _courseRepository.Save();
        }
    }
}
