using BookStoreApi.DataRepo;
using BookStoreApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Controllers
{
    [Route("api/currency")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        
        private ICurrency _currency;

        public CurrencyController(ICurrency currency,IConfiguration config)
        {
            _currency = currency;
            
        }


        //[HttpGet("GeAllCurrencies")]
        //public IActionResult GeAllCurrencies()=> Ok(_currency.GeAllCurrencies());

        [HttpGet("")]
        public async Task<IActionResult> GeAllCurrenciesAsync() => Ok(await _currency.GeAllCurrenciesAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencyByIdAsync([FromRoute] int id) => Ok(await _currency.GetCurrencyByIdAsync(id));//Ok(await _currency.GetCurrencyByIdAsync(id));

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyByNameAsync([FromRoute] string name) => Ok(await _currency.GetCurrencyByNameAsync(name));
        
        [HttpPost("InsertCurrency/{title}/{disc}")]
        public async Task<IActionResult> InsertCurrency([FromRoute] string title, [FromRoute] string disc) => Ok(await _currency.InsertCurrency(title,disc));
        
        [HttpPost("UpdateCurrency/{id:int}/{title}/{disc}")]
        public async Task<IActionResult> UpdateCurrency([FromRoute]int id,[FromRoute] string title, [FromRoute] string disc) => Ok(await _currency.UpdateCurrency(id,title,disc));
        
        [HttpPost("DeleteCurrency/{id}")]
        public async Task<IActionResult> DeleteCurrency([FromRoute]int id) => Ok(await _currency.DeleteCurrency(id));
    }
}
