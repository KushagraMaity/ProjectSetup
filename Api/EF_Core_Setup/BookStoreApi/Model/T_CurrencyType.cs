namespace BookStoreApi.Model
{
    public class T_CurrencyType
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
        public string DESCRIPTION{ get; set; }

        public ICollection<T_BookPrice> T_BookPrices { get; set; }
    }
}
