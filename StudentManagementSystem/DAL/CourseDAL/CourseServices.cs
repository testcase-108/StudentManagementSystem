using System.Collections.Generic;
using StudentManagementSystem.Data;
using System.Linq;
using StudentManagementSystem.DTO;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.DAL
{ 
    public class CourseService
    {
        private readonly ICourse _courseRepository;

        public CourseService(ICourse courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<CourseDto> GetAllCourse() => _courseRepository.GetAllCourse();

        public CourseDto? GetCourseById(int id) => _courseRepository.GetCourseById(id);

        public void UpdateCourse(int id,CourseDto course)
        {
            _courseRepository.UpdateCourse(course);
            _courseRepository.SaveCourse();
        }

        public void AddNewCourse(CourseTitleDto courseDto)
        {
            _courseRepository.AddCourse(courseDto);
            _courseRepository.SaveCourse();
        }

        public void DeleteCourse(int id)
        {
             _courseRepository.DeleteCourse(id);
             _courseRepository.SaveCourse();
            
        }
        
    }
}

