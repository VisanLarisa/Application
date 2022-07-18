using Application.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Base
{
    public class Repository <T> : IRepository <T> where T:Entity
    {
        private readonly ApplicationDbContext _context;
        public Repository() => _context = new ApplicationDbContext();   //?
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            T model = _context.Set<T>().Find(id);

            //T model = _context.Make.Find(id);
            _context.Set<T>().Remove(model);
        }
        public void Delete(T model)
        {
            _context.Set<T>().Remove(model);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T model)
        {
            _context.Set<T>().Add(model);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
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
