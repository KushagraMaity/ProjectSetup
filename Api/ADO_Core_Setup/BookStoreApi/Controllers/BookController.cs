using BookLibAdo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBook book;
        public BookController()
        {
            book = new Book();
        }

        [HttpGet("GetBookList")]
        public IActionResult GetBooks() => Ok(book.ShowBooks());

        [HttpGet("CheckDBConnection")]
        public IActionResult GetBDbConnect() => Ok(book.GetBDbConnect());
    }
}
