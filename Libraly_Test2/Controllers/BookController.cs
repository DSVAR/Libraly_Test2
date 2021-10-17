using System.Threading.Tasks;
using Libraly.BLL.Interfaces;
using Libraly.BLL.Models.BookDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Libraly_Test2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookC : Controller
    {
        private readonly IBookService _service;
        private readonly IDefaultJsonPattern _djp;

        public BookC(IBookService service, IDefaultJsonPattern djp, IHttpContextAccessor accessor)
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
                var json = await _djp.DeffPatternAnswer(201, "succeeded");
                return Created(HttpContext.Request.Host.Value, json);
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
            var result = await _service.GetBooks();
            if (result != null)
            {
                var json = await _djp.DeffPatternAnswer(200, "", result);
                return Ok(json);
                // return Created(HttpContext.Request.Host.Value,json);
            }
            else return NoContent();
        }

        [HttpGet]
        [Route("FindBook/{bookId}")]
        public async Task<IActionResult> FindBook(int bookId)
        {
            var result = await _service.FindBook(bookId);
            if (result != null)
            {
                return Ok(await _djp.DeffPatternAnswer(200, "Found", result));
            }
            else
                return NoContent();
        }

        [HttpDelete]
        [Route("DeleteBook/{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var book = await _service.DeleteBook(bookId);
            return Ok(await _djp.DeffPatternAnswer(200, "succeeded", book));
        }

        [HttpPost]
        [Route("BookUpdate")]
        public async Task<IActionResult> UpdateBook(UpdateBookViewModel book)
        {
            await _service.UpdateBook(book);
            return Ok(await _djp.DeffPatternAnswer(200, "succeeded"));
        }
    }
}