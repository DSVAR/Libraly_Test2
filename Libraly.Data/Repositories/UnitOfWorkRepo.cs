using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Libraly.Data.Context;
using Libraly.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Libraly.Data.Repositories
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        public ApplicationContext Context { get; }

        public UnitOfWorkRepo(ApplicationContext context)
        {
            this.Context = context;
        }

       

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}