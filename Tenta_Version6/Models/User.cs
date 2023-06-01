namespace Tenta_Version6.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public List<Book> Books { get; set; }
    }
}
