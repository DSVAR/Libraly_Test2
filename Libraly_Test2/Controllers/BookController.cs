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
        private readonly IDefaultJsonPattern _djp;
        public BookC(IBookService service, IDefaultJsonPattern djp)
        {
            _service = service;
            _djp = djp;
        }

        [HttpPost]
        [Route("CreateBook")]
        public async Task<IActionResult> Create(CreateBook model)
        {
            if (ModelState.IsValid)
            {
                await _service.Creat(model);
                var json = _djp.DeffPatternAnswer(200,  "succeeded");
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
            var json = await _djp.DeffPatternAnswer(200, "Found",  await _service.GetBooks());
            return Ok(json);
        }

        [HttpGet]
        [Route("FindBook/{bookId}")]
        public async Task<IActionResult> FindBook(int bookId)
        {
            var json = _djp.DeffPatternAnswer(200, "Found", await _service.FindBook(bookId));
            return Ok(json);
        }

        [HttpDelete]
        [Route("DeleteBook/{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            try
            {
             var book=   await _service.DeleteBook(bookId);
                return Ok(_djp.DeffPatternAnswer(200, "succeeded",book));
            }
            catch(Exception ex)
            {
                return BadRequest(_djp.DeffPatternAnswer(400, ex.Message));
            }

        }

        [HttpPost]
        [Route("BookUpdate")]
        public async Task<IActionResult> UpdateBook(UpdateBookViewModel book)
        {
            try
            {
               await _service.UpdateBook(book);
                return Ok(_djp.DeffPatternAnswer(200, "succeeded"));
            }
            catch (Exception ex)
            {
                return BadRequest(_djp.DeffPatternAnswer(400, ex.Message));
            }
        }
    }
}