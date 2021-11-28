using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IServiceRepositoryBase<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
        void Add(T entity);
    }
}
