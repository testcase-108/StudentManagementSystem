using System.Collections.Generic;
using WebApplication7.model;
using System.Linq;
using WebApplication7.Data;
using WebApplication7.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplication7.CourseDAL
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<CourseDTO> GetAll() => _appDbContext.courses.Select(c => new CourseDTO
        {
            CourseId = c.CourseId,
            Title = c.Title
        }).ToList();

        public CourseDTO GetById(int id)
        {
            var exists = _appDbContext.courses.Where(c => c.CourseId == id).First();
            if(exists == null)
            {
                return null;
            }

            return new CourseDTO
            {
                CourseId = exists.CourseId,
                Title = exists.Title
            };
        }
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
            var course = _appDbContext.courses.FirstOrDefault(c => c.CourseId == courseDTO.CourseId);
            if (course != null)
            {
                course.Title = courseDTO.Title;
                _appDbContext.courses.Update(course);
                return ;
            }
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
