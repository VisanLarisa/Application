using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(Guid id);
        void Delete(T obj);
        void Save();
    }
}
