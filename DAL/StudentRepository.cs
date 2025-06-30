using System.Collections.Generic;
using WebApplication7.model;
using WebApplication7.DTO;
using System.Linq;
using WebApplication7.Data;

namespace WebApplication7.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<StuDTOWithId> GetAll() =>
            _appDbContext.students.Select(s => new StuDTOWithId
            {
                StudentId = s.StudentId,
                FirstName = s.FirstName,
                LastName = s.LastName
            }).ToList();

        public StuDTOWithId GetById(int id)
        {
            var student = _appDbContext.students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return null;
            }

            return new StuDTOWithId
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }
        public void Add(StuDTO student)
        {
            var newEntry = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };
            _appDbContext.students.Add(newEntry);
        }
        public void Update(StuDTOWithId student)
        {
            var existingStudent = _appDbContext.students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if(existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                _appDbContext.students.Update(existingStudent);
                return;
            }
        }
        public void Delete(int id)
        {
            var student = _appDbContext.students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                _appDbContext.students.Remove(student);
            }
        }

        public void Save() => _appDbContext.SaveChanges();
    }
}
