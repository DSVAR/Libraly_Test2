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
        [Route("CreteBook")]
        public async Task<IActionResult> Create(CreateBook model)
        {
            if (ModelState.IsValid)
            {
                await _service.Creat(model);
                var json = DJP.DefJsnP(200,  "Item's added");
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

        [HttpPost]
        [Route("FindBook")]
        public async Task<IActionResult> FindBook(BookViewModel book)
        {
            var json = DJP.DefJsnP(200, "Found", await _service.FindBook(book.Id));
            return Ok(json);
        }
    }
}