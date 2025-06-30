using System.Collections.Generic;
using WebApplication7.model;
using System.Linq;
using WebApplication7.Data;
using WebApplication7.DTO;

namespace WebApplication7.CourseDAL
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Course> GetAll() => _appDbContext.courses.Select(c => new Course
        {
            CourseId = c.CourseId,
            Title = c.Title
        }).ToList();

        public Course GetById(int id) => _appDbContext.courses.Where(c => c.CourseId == id).First();
        public void Add(CoursetitleDTO courseDTO)
        {
            var course = new Course
            {
                //CourseId = courseDTO.CourseId,
                Title = courseDTO.Title
            };
            _appDbContext.courses.Add(course);
        }
        public void Update(CourseDTO courseDTO)
        {
            var course = new Course
            {
                Title = courseDTO.Title
            };
            _appDbContext.courses.Update(course);
        }
        public void Delete(int id)
        {
            var course = _appDbContext.courses.FirstOrDefault(c => c.CourseId == id);
            if (course != null)
            {
                _appDbContext.courses.Remove(course);
            }
        }

        public void Save() => _appDbContext.SaveChanges();
    }
}
