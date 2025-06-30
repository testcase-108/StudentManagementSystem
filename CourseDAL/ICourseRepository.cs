using System.Collections.Generic;
using WebApplication7.model;
using System.Linq;
using WebApplication7.DTO;

namespace WebApplication7.CourseDAL
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course? GetById(int id);
        void Add(CoursetitleDTO course);
        void Update(CourseDTO course);
        void Delete(int id);
        void Save();
    }
}
