using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tenta_Version6.Models;
using Tenta_Version6.Models.ViewModels;

namespace Tenta_Version6.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationContext Context;

        public BooksController(ApplicationContext _context)
        {
            Context = _context;
        }


        public IActionResult Index()
        {
            List<Genre> AuthorsProductsGenres = Context.Genres.Include(x => x.Books).ThenInclude(x => x.Authors).ToList();

            return View(AuthorsProductsGenres);
        }


        [HttpPost]
        public IActionResult DeleteBook(int removeId)
        {
            Book RemoveBook = Context.Books.FirstOrDefault(x => x.Id == removeId);
            Context.Books.Remove(RemoveBook);
            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditBooks()
        {
            List<Book> EditBookView = Context.Books.ToList();
            return View(EditBookView);
        }
        public IActionResult Edit(int Id)
        {

            Book EditBook = Context.Books.FirstOrDefault(x => x.Id == Id);
            return View(EditBook);
        }

        [HttpPost]
        public IActionResult Edit(int Id, string Title, string Description, int ISBN)
        {
            Book EditedBook = Context.Books.FirstOrDefault(x => x.Id == Id);
            if (EditedBook == null)
            {
                return NotFound(); // return a 404 Not Found error
            }
            EditedBook.Title = Title;
            EditedBook.Description = Description;
            EditedBook.ISBN = ISBN;
            Context.Books.Update(EditedBook);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult CreateBook()
        {
            AuthorGenre authorGenre = new AuthorGenre();
            authorGenre.Authors = Context.Authors.ToList();
            authorGenre.Genres = Context.Genres.ToList();
            return View(authorGenre);
        }

        [HttpPost]
        public IActionResult CreateBook(string BookTitle, string BookDescription, int BookISBN, List<string> BookAuthors, List<string> BookGenres) 
        {
            Book NewBook = new Book()
            {

                Title = BookTitle,
                Description = BookDescription,
                ISBN= BookISBN,
                Quantity = 1,
                Authors = new List<Author>(),
                Genres = new List<Genre>()

            };

            foreach(var p in BookAuthors)
            {
                var author = Context.Authors.FirstOrDefault(x => x.AuthorName == p);
                if (author != null)
                {
                    NewBook.Authors.Add(author);
                }
            }

            foreach (var p in BookGenres)
            {
                var genre = Context.Genres.FirstOrDefault(x => x.GenreName == p);
                if (genre != null)
                {
                    NewBook.Genres.Add(genre);
                }
            }

            Context.Books.Add(NewBook);
            Context.SaveChanges();

            return RedirectToAction ("CreateBook");
        }

        public IActionResult AddAuthor()
        {
            List<Author> EditAuthorView = Context.Authors.ToList();
            return View(EditAuthorView);
        }

        [HttpPost]
        public IActionResult AddAuthor(string authorName)
        {
            Author NewAuthor = new Author();

            NewAuthor.AuthorName = authorName;

            Context.Authors.Add(NewAuthor);
            Context.SaveChanges();

            return RedirectToAction("CreateBook");
        }


        public IActionResult AddGenre()
        {
            List<Genre> EditGenreView = Context.Genres.ToList();
            return View(EditGenreView);
        }

        [HttpPost]
        public IActionResult AddGenre(string genreName)
        {
            Genre NewGenre = new Genre();

            NewGenre.GenreName = genreName;

            Context.Genres.Add(NewGenre);
            Context.SaveChanges();

            return RedirectToAction("CreateBook");
        }
    }
}
