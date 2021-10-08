using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libraly.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Libraly.Data.Interfaces
{
    public interface  IUnitOfWork
    {
       ApplicationContext Context { get; }
       void Save();
       void Dispose();
    }
}