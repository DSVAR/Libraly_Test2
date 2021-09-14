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
                var result=await _service.Creat(model);
                var json = DJP.DefJsnP(200, model, result.State, "nice Fat cock");
                var jsonAnswer = JsonConvert.SerializeObject(new {Book = result, sw = 1});
                return Ok(json);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("GetBooks")]
        public IQueryable GetBooks()
        {
           
            return _service.GetBooks();
        }
    }
}