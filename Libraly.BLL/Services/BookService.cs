﻿using System.Collections.Generic;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService( IUnitOfWork unitOfWork,IMapper mapper,IRepository<Book> boookRepo)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
            _boookRepo = boookRepo;
        }


        public async Task<List<Book>> GetBooks()
        {
           return await _boookRepo.GetElements();
       //    return null;
        }
        
        public async Task Creat(CreateBook model)
        {
            var book = _mapper.Map<BookViewModel>(model);
            
            await _boookRepo.Create(book);
           _unitOfWork.Save();
            // return null;
        }

     
        public async Task<BookViewModel> FindBook(long id)
        {
            var book=await _boookRepo.Find(id);
            var changedBook = _mapper.Map<BookViewModel>(book);
            return changedBook;
        }
        
        public EntityState UpdateBook(int idBook, UpdateBookViewModel updateBookViewModel)
        {
            var book = _mapper.Map<Book>(updateBookViewModel);
            return _boookRepo.Update(book);
        }
    }
}