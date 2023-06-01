using Microsoft.EntityFrameworkCore;
using Tenta_Version6.Models;

namespace Tenta_Version6
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, AuthorName = "J.K Rolling" },
            new Author { Id = 2, AuthorName = "J.R.R. Tolkien" },
            new Author { Id = 3, AuthorName = "George Lucas" },
            new Author { Id = 4, AuthorName = "Stephen King" }
            );

            modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, GenreName = "Fantasy" },
            new Genre { Id = 2, GenreName = "Horror" },
            new Genre { Id = 3, GenreName = "Romance" },
            new Genre { Id = 4, GenreName = "Nonfiction" }

                );

            
            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Jonas", Address = "Kungsgatan 19k", PhoneNumber = 0733293812 },
            new User { Id = 2, Name = "Rune", Address = "Östraringgatan 23", PhoneNumber = 0783281934 },
            new User { Id = 3, Name = "Billy", Address = "Drottningsgatan 12", PhoneNumber = 0713782123},
            new User { Id = 4, Name = "Pille", Address = "Lunargatan 28", PhoneNumber = 0783726132}
                );


            modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Harry Potter and the Goblet of Fire", Description = "This book has this Description for now 1", ISBN = 23618, Quantity = 1 },
            new Book { Id = 2, Title = "Lord of the Rings: The Two Towers", Description = "This book has this Description for now 2", ISBN = 24672, Quantity = 1 },
            new Book { Id = 3, Title = "Star Wars Return of the Sith", Description = "This book has this Description for now 3", ISBN = 386518, Quantity = 1 },
            new Book { Id = 4, Title = "The Shining", Description = "This Book has this Description for now 4", ISBN = 92228, Quantity = 1 },
            new Book { Id = 5, Title = "Harry Potter and the Order of the Phoenix", Description = "This book has this Description for now 5", ISBN = 58240, Quantity = 1 },
            new Book { Id = 6, Title = "IT", Description = "This book has this Description for now 6", ISBN = 112649, Quantity = 1 }
                );

            modelBuilder.Entity("AuthorBook").HasData(
            new { AuthorsId = 1, BooksId = 1 },
            new { AuthorsId = 2, BooksId = 2 },
            new { AuthorsId = 3, BooksId = 3 },
            new { AuthorsId = 1, BooksId = 5 },
            new { AuthorsId = 4, BooksId = 4 },
            new { AuthorsId = 4, BooksId = 6 }
                );

            modelBuilder.Entity("BookGenre").HasData(
            new { GenresId = 1, BooksId = 1 },
            new { GenresId = 1, BooksId = 2 },
            new { GenresId = 1, BooksId = 3 },
            new { GenresId = 1, BooksId = 5 },
            new { GenresId = 2, BooksId = 4 },
            new { GenresId = 2, BooksId = 6 }
                );

            modelBuilder.Entity("BookUser").HasData(
            new { UsersId = 1, BooksId = 1}
                );

        }
    }
}
