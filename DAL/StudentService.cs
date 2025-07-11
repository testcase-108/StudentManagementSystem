using System.Collections.Generic;
using WebApplication7.model;
using System.Linq;
using WebApplication7.Data;
using WebApplication7.DTO;


namespace WebApplication7.DAL
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<StuDTOWithId> GetAllStudents()
        {
            return _repository.GetAll();
        }

        public StuDTOWithId GetStudentById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddStudent(StuDTO student)
        {
            _repository.Add(student);
            _repository.Save();
        }
        public void UpdateStudent(StuDTOWithId student)
        {
            _repository.Update(student);
            _repository.Save();
        }
        public void DeleteStudent(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
        public void SaveChanges()
        {
            _repository.Save();
        }
    }
}
