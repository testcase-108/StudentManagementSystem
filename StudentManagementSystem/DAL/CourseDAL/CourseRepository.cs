using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.Models;
using StudentManagementSystem.Data;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.DAL
{
    public class CourseRepository : ICourse
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CourseDto> GetAllCourse()
        {
            return _context.Courses.Select(c => new CourseDto
            {
                CourseId = c.CourseId,
                Title = c.Title
            }).ToList();
        }

        public CourseDto? GetCourseById(int id)
        {
            var course =  _context.Courses.Find(id);
           
            var courseDto = new CourseDto
            {
                CourseId = course.CourseId,
                Title = course.Title
            };
            return courseDto;
        }

        public void AddCourse(CourseTitleDto courseDto)
        {
            var course = new Course
            {
                Title = courseDto.Title
            };
            _context.Courses.Add(course);
        }

        public void UpdateCourse(CourseDto course)
        {
            var existing = _context.Courses.FirstOrDefault(sc => sc.CourseId == course.CourseId);
            if (existing != null)
            {
                existing.Title = course.Title;
                _context.SaveChanges();
            }
            
        }

        public void DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(sc=>sc.CourseId==id);
            _context.Courses.Remove(course);
        }

        public void SaveCourse() => _context.SaveChanges();
    }
}

