namespace BookStoreApi.Model
{
    public class T_BOOK
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? OnOfPage { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsActive { get; set; }

        //creating  forgine key
        public int LanguageId { get; set; }
        public T_Language T_Languages { get; set; }
    }
}
