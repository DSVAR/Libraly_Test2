using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libraly.Data.Context;
using Libraly.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Libraly.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _iuow;
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dabSet;
      //  private IRepository<T> _repositoryImplementation;

        public Repository(ApplicationContext context,IUnitOfWork iuow)
        {
           
            _context = context;
            _dabSet = context.Set<T>();
            _iuow=iuow;
            
        }
        public async Task<List<T>> GetElements()
        {
            return  await _dabSet.ToListAsync();    
        }

        public async Task Create(T obj)
        {
        await _context.AddAsync(obj);
           
        }

       
        public async Task Delete(T obj)
        {
          //  _context.Remove(obj);
            _dabSet.Remove(obj);
        }

        public async Task<T> Find(long id)
        {
            return await _dabSet.FindAsync(id);
        }

        public async Task Update(T obj)
        {
            // _iuow.Context.Entry(obj).State = EntityState.Modified;
             _context.Update(obj);
             
        }

     
        public void Detach(T entity)
        {
            _iuow.Context.Entry(entity).State = EntityState.Detached;
        }
    }
}