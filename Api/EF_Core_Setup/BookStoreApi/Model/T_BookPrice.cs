namespace BookStoreApi.Model
{
    public class T_BookPrice
    {
        public int ID { get; set; }
        public int BOOK_ID { get; set; }
        public string CURRENCY_ID { get; set; }
        public decimal AMOUNT { get; set; }

        public T_BOOK T_BOOKS { get; set; }
        public T_CurrencyType T_CurrencyTypes { get; set; }
    }
}
