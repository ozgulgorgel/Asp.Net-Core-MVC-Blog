using blog.business.Repositories;
using blog.data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.business.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly blogcontext _context;
        public Repository(blogcontext context)
        {
            _context = context;
   

        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                RollBack();


            }
           
        }

        public void Delete(int Id)
        {
            var entity = _context.Find<T>(Id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public T GetByID(int Id)
        {
            return _context.Find<T>(Id);
        }

        public void RollBack()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
