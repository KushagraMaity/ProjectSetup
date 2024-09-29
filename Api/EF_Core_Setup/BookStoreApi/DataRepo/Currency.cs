using BookStoreApi.Migrations;
using BookStoreApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.DataRepo
{
    public class Currency:ICurrency
    {
        private BookDbContext _bookDbContext;
        public Currency(BookDbContext bookDbContext) 
        {
            this._bookDbContext = bookDbContext;
        }
        #region without async
        public ICollection<T_CurrencyType> GeAllCurrencies()
        {
            //var result = this._bookDbContext.T_CurrencyTypes.ToList();
            var result = (from currencis in this._bookDbContext.T_CurrencyTypes select currencis).ToList();
            return result;
        }
        #endregion

        #region with async
        #nullable disable
        public async Task<ICollection<T_CurrencyType>> GeAllCurrenciesAsync()
        {
            try
            {
                //var result = await this._bookDbContext.T_CurrencyTypes.ToListAsync();
                var result = await (from currencis in this._bookDbContext.T_CurrencyTypes select currencis).ToListAsync();
                
                return result;
            }catch(Exception ex)
            {
                throw ex; 
            }
            
        }

        public async Task<T_CurrencyType> GetCurrencyByIdAsync(int id)
        {
            return await _bookDbContext.T_CurrencyTypes.FindAsync(id);
        }

        public async Task<T_CurrencyType> GetCurrencyByNameAsync(string name)
        {
            //IQueryable<T_CurrencyType> t_CurrencyTypes = _bookDbContext.T_CurrencyTypes;
            //return await t_CurrencyTypes.Where(x=> x.TITLE == name).FirstOrDefaultAsync();

            //IQueryable<T_CurrencyType> t_CurrencyTypes = _bookDbContext.T_CurrencyTypes;
            //return await t_CurrencyTypes.FirstOrDefaultAsync(x => x.TITLE == name);

            //return await _bookDbContext.T_CurrencyTypes.Where(x => x.TITLE == name).FirstOrDefaultAsync();
            return await _bookDbContext.T_CurrencyTypes.FirstOrDefaultAsync(x => x.TITLE == name);
        }

        public async Task<string> InsertCurrency(string title,string description)
        {
            string save = string.Empty;
            try
            {
                await _bookDbContext.T_CurrencyTypes.AddAsync(new T_CurrencyType
                {
                    TITLE = title,
                    DESCRIPTION = description
                });

                bool isSave = await _bookDbContext.SaveChangesAsync()>0;
                save = isSave ? "Added successfully" : "Failed to added";
            }catch (Exception ex)
            {
                throw ex;
            }
            return save;
        }

        public async Task<string> UpdateCurrency(int id, string title, string description)
        {
            string save = string.Empty;
            try
            {
                var updateData =  await _bookDbContext.T_CurrencyTypes.Where(x=> x.ID == id).FirstOrDefaultAsync();
                updateData.TITLE = title;
                updateData.DESCRIPTION = description;

                bool isSave = await _bookDbContext.SaveChangesAsync() > 0;
                save = isSave ? "Updated successfully" : "Failed to update";
            }
            catch (Exception ex)
            {
                throw ;
            }
            return save;
        }

        public async Task<string> DeleteCurrency(int id)
        {
            string save = string.Empty;
            try
            {
                var deleteData = await _bookDbContext.T_CurrencyTypes.Where(x => x.ID == id).FirstOrDefaultAsync();
                

                _bookDbContext.T_CurrencyTypes.Remove(deleteData);
                bool isSave = await _bookDbContext.SaveChangesAsync() > 0;
                save = isSave ? "Deleted successfully" : "Failed to delete";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return save;
        }
        public void getName()
        {
            ///fdsfdsfsfs
        }
       
        #endregion
    }
}
