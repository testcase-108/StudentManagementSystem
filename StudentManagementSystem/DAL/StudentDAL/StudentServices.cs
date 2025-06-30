using System.Collections.Generic;
using StudentManagementSystem.Data;
using System.Linq;
using StudentManagementSystem.DTO;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.DAL.StudentDAL
{
    public class StudentService
    {
        private readonly IStudent _studentRepository;

        public StudentService(IStudent studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<StudentDto> GetAllStudent() => _studentRepository.GetAllStu();

        public StudentDto? GetStudentById(int id) => _studentRepository.GetById(id);

        public void AddNewStudent(StudentAddDto stu)
        {
            _studentRepository.AddStudent(stu);
            _studentRepository.SaveStudent();
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
            _studentRepository.SaveStudent();
        }

        public void UpdateStudent(int id, StudentDto stu)
        {
            _studentRepository.UpdateStudent(stu);
            _studentRepository.SaveStudent();
        }
    }
}