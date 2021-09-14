using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Libraly.Data.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IQueryable<T> GetElements();
        
        Task<EntityEntry<T>> Create(T obj);
        
        EntityEntry<T> Delete(T obj);
        
        Task<T> Find(long id);
        
        EntityState Update(T obj);
    }
}