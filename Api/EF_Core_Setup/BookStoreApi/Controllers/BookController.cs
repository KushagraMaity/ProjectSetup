
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("Nilesh/Cookies")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBook book;
        public BookController(IConfiguration config) {
            book = new Book(config);
        }

        [HttpGet("GetBookList")]
        public IActionResult GetBooks() => Ok(book.ShowBooks());

        [HttpGet("GetName/{fn}/{ln:int}")]
        public IActionResult GetName(string fn, int ln)
        {
            return Ok(fn+ln);
        }
    }
}
