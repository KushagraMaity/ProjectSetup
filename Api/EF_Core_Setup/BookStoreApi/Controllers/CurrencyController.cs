using BookStoreApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private BookDbContext _bookDbContext;
        public CurrencyController(BookDbContext bookDbContext)
        {
            this._bookDbContext = bookDbContext;
        }

        [HttpGet("GeAllCurrenciesWithOutAsync")]
        public IActionResult GeAllCurrenciesWithOutAsync()
        {
            //var result = this._bookDbContext.T_CurrencyTypes.ToList();
            var result = (from currencis in this._bookDbContext.T_CurrencyTypes select currencis).ToList();
            return Ok(result);
        }

        [HttpGet("GeAllCurrenciesWithAsync")]
        public async Task<IActionResult> GeAllCurrenciesWithAsync()
        {
            //var result = await this._bookDbContext.T_CurrencyTypes.ToListAsync();
            var result = await (from currencis in this._bookDbContext.T_CurrencyTypes select currencis).ToListAsync();
            return Ok(result);
        }
    }
}
