using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.business.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);  
        void Delete(int Id);
        T GetByID(int Id);
        IEnumerable<T> GetAll();
        void RollBack();
        int Save();

    }
}
