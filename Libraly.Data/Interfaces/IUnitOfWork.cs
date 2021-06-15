using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraly.Data.Interfaces
{
    public interface  IUnitOfWork<T> where T:class
    {
        Task Create(T obj);
        IQueryable<T> GetElements();
        void Update(T obj);
        void Delete(T obj);
        void Save();
    }
}