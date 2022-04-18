using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid MakeId);
        void Insert(T make);
        void Update(T make);
        void Delete(Guid makeId);
        void Delete(T make);
        void Save();
    }
}
