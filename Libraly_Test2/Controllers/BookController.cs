using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Libraly.BLL.Interfaces;
using Libraly.BLL.JsonPatterns;
using Libraly.BLL.Models.BookDTO;
using Libraly.BLL.Services;
using Libraly.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Libraly_Test2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookC : Controller
    {
        private readonly IBookService _service;
        private DefaultJsonPattern DJP=new DefaultJsonPattern();
        public BookC(IBookService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateBook")]
        public async Task<IActionResult> Create(CreateBook model)
        {
            if (ModelState.IsValid)
            {
                await _service.Creat(model);
                var json = DJP.DefJsnP(200,  "succeeded");
                return Ok(json);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var json = DJP.DefJsnP(200, "Found",  await _service.GetBooks());
            return Ok(json);
        }

        [HttpGet]
        [Route("FindBook/{bookId}")]
        public async Task<IActionResult> FindBook(int bookId)
        {
            var json = DJP.DefJsnP(200, "Found", await _service.FindBook(bookId));
            return Ok(json);
        }

        [HttpDelete]
        [Route("DeleteBook/{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            try
            {
             var book=   await _service.DeleteBook(bookId);
                return Ok(DJP.DefJsnP(200, "succeeded",book));
            }
            catch(Exception ex)
            {
                return BadRequest(DJP.DefJsnP(400, ex.Message));
            }

        }
    }
}