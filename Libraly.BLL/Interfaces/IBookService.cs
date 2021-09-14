using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Libraly.BLL.Models.BookDTO;
using Libraly.BLL.Models.UserDTO;
using Libraly.Data.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Libraly.BLL.Interfaces
{
    public interface IBookService
    {
        IQueryable GetBooks();
        Task<EntityEntry<Book>> Creat(CreateBook model);
        Task<Book> FindBook(long id);
        EntityState UpdateBook(int idBook, UpdateBookViewModel updateBookViewModel);
    }
}