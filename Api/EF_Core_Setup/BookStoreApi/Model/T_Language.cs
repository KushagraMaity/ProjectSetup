namespace BookStoreApi.Model
{
    public class T_Language
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }


        //create table relation for forgine key
        public ICollection<T_BOOK> Books { get; set; }
    }
}
