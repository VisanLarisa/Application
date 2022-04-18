using Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Base
{
    public class RepositoryMake : IMakeRepository
    {
        private readonly ApplicationDbContext _context;
        public RepositoryMake() => _context = new ApplicationDbContext();   //?
        public RepositoryMake(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Guid MakeId)
        {
            Make make = _context.Makes.Find(MakeId);
            _context.Makes.Remove(make);
        }

        public IEnumerable<Make> GetAll()
        {
            return _context.Makes.ToList();
        }

        public Make GetById(Guid MakeId)
        {
            return _context.Makes.Find(MakeId);
        }

        public void Insert(Make make)
        {
            _context.Makes.Add(make);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Make make)
        {
           // _context.Entry(make).State = MakeState.Modified;
        }

        private bool disposed = false;
        protected virtual void Dispose (bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    _context.Dispose();
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
