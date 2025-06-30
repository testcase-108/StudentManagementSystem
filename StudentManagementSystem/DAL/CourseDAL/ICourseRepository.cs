using System.Collections.Generic;
using StudentManagementSystem.Models;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.DAL
{
    public interface ICourse
    {
        IEnumerable<CourseDto> GetAllCourse();
        CourseDto? GetCourseById(int id);
        void AddCourse(CourseTitleDto course);
        void UpdateCourse(CourseDto course);
        void DeleteCourse(int id);
        void SaveCourse();
    }
}

