using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Libraly.Data.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetElements();
        
        Task Create(T obj);
        
        Task Delete(T obj);
        
        Task<T> Find(long id);
        
        EntityState Update(T obj);
    }
}