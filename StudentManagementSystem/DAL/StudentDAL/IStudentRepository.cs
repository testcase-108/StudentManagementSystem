using System.Collections.Generic;
using StudentManagementSystem.Models;
using StudentManagementSystem.DTO;

namespace StudentManagementSystem.DAL.StudentDAL
{
    public interface IStudent
    {
        IEnumerable<StudentDto> GetAllStu();

        StudentDto? GetById(int id);
        void AddStudent(StudentAddDto stu);
        void UpdateStudent(StudentDto stu);
        void DeleteStudent(int id);
        void SaveStudent();
    }
}