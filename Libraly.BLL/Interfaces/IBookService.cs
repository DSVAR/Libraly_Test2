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
        Task<List<Book>> GetBooks();
        Task Creat(CreateBook model);
        Task<BookViewModel> FindBook(long id);
        Task<Book> DeleteBook(long id);
        EntityState UpdateBook(int idBook, UpdateBookViewModel updateBookViewModel);
        
    }
}