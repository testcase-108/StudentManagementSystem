using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.Models;
using StudentManagementSystem.Data;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.DAL.StudentDAL
{
    public class StudentRepository : IStudent
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentDto> GetAllStu()
        {
            return _context.Students
                .Select(s => new StudentDto
                {
                    StudentId = s.StudentId,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                  
                }).ToList();;
        }

        public StudentDto? GetById(int id)
        {
            var student = _context.Students.FirstOrDefault(st => st.StudentId == id);
            
            return new StudentDto
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }
        public void AddStudent(StudentAddDto stuAddDto)
        {
            var stu = new Student
            {
                FirstName = stuAddDto.FirstName,
                LastName = stuAddDto.LastName
            };
            _context.Students.Add(stu);
        }

        public void UpdateStudent(StudentDto stu)
        {
            var existing = _context.Students.FirstOrDefault(st => st.StudentId == stu.StudentId);

            if (existing != null)
            {
                existing.FirstName = stu.FirstName;
                existing.LastName = stu.LastName;
                _context.SaveChanges();  
            }
        }


        public void DeleteStudent(int id)
        {
            var exists = _context.Students.FirstOrDefault(st => st.StudentId == id);
            _context.Students.Remove(exists);
        }
        public void SaveStudent() => _context.SaveChanges();
    }
}