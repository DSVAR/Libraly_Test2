using System;
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
        private readonly IUnitOfWork<T> _iuow;
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _dabSet;
        private IRepository<T> _repositoryImplementation;

        public Repository(ApplicationContext context,IUnitOfWork<T> iuow)
        {
            _context = context;
            _dabSet = context.Set<T>();
            _iuow=iuow;
            
        }
        public IQueryable<T> GetElements()
        {
            return  _dabSet.AsQueryable();    
        }

        public async Task<EntityEntry<T>> Create(T obj)
        {
            var result= await _context.AddAsync(obj);
            return result;
        }

       
        public EntityEntry<T> Delete(T obj)
        {
            return _context.Remove(obj);
        }

        public async Task<T> Find(long id)
        {
            return await _dabSet.FindAsync(id);
        }

        public EntityState Update(T obj)
        {
            return _iuow.Context.Entry(obj).State = EntityState.Modified;
        }
    }
}