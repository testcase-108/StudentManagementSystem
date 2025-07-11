using System.Collections.Generic;
using WebApplication7.model;
using WebApplication7.DTO;

namespace WebApplication7.DAL
{
    public interface IStudentRepository
    {
        IEnumerable<StuDTOWithId> GetAll();
        StuDTOWithId? GetById(int id);
        void Add(StuDTO student);
        void Update(StuDTOWithId student);
        void Delete(int id);

        void Save();
    }
}
