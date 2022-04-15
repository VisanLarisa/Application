using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IMakeRepository
    {
        IEnumerable<Make> GetAll();
        Make GetById(Guid MakeId);
        void Insert(Make make);
        void Update(Make make);
        void Delete(Guid makeId);
        void Save();
    }
}
