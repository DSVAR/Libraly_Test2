using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Libraly.BLL.Interfaces;
using Libraly.BLL.Models.BookDTO;
using Libraly.Data.Entities;
using Libraly.Data.Interfaces;
using Libraly.Data.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Libraly.BLL.Services
{
    public class BookService:IBookService
    {
        private readonly IRepository<Book> _boookRepo;
        private readonly IUnitOfWork<Book> _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork<Book> unitOfWork,IMapper mapper,IRepository<Book> boookRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _boookRepo = boookRepo;
        }


        public IQueryable GetBooks()
        {
           return _boookRepo.GetElements();
       //    return null;
        }

        public async Task<EntityEntry<Book>> Creat(CreateBook model)
        {
            var book = _mapper.Map<BookViewModel>(model);
            var resultState=await _boookRepo.Create(book);
            _unitOfWork.Save();
            return resultState;
            // return null;
        }

     
        public async Task<Book> FindBook(long id)
        {
            return await _boookRepo.Find(id);
        }
        
        public EntityState UpdateBook(int idBook, UpdateBookViewModel updateBookViewModel)
        {
            var book = _mapper.Map<Book>(updateBookViewModel);
            return _boookRepo.Update(book);
        }
    }
}