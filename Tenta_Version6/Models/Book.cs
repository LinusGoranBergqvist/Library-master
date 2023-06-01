namespace Tenta_Version6.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ISBN { get; set; }
        public int Quantity { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
        public List<User> Users { get; set; }
        public List<BookItem> BookItems { get; set; }
        
    }
}
