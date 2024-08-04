using BookStoreApi.Model;

namespace BookStoreApi.DataRepo
{
    public interface ICurrency
    {
        ICollection<T_CurrencyType> GeAllCurrencies();
        Task<ICollection<T_CurrencyType>> GeAllCurrenciesAsync();
        Task<T_CurrencyType> GetCurrencyByIdAsync(int id);
        Task<T_CurrencyType> GetCurrencyByNameAsync(string name);
        Task<string> InsertCurrency(string title, string description);
        Task<string> UpdateCurrency(int id, string title, string description);
        Task<string> DeleteCurrency(int id);
    }
}
