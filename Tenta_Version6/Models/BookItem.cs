namespace Tenta_Version6.Models
{
    public class BookItem
    {
        public int Id { get; set; }
        public bool InHouse { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
