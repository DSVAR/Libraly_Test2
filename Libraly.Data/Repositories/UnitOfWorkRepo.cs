using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Libraly.Data.Context;
using Libraly.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libraly.Data.Repositories
{
    public class UnitOfWorkRepo<T> : IUnitOfWork<T> where T: class
    {
        public ApplicationContext Context { get;}
        public DbSet<T> DabSet;

        public UnitOfWorkRepo(ApplicationContext context)
        {
            Context = context;
            DabSet = context.Set<T>();
        }

        public async Task Create(T obj)
        {
            await Context.AddAsync(obj);
        }

        public IQueryable<T> GetElements()
        {
            return  DabSet.AsQueryable();            
        }

        public  void Update(T obj)
        {
             Context.Update(obj);
        }

        public void Delete(T obj)
        {
            Context.Remove(obj);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}