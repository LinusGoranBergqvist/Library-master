using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tenta_Version6.Models;

namespace Tenta_Version6.Controllers
{
    public class LoansController : Controller
    {
        private readonly ApplicationContext Context;

        public LoansController(ApplicationContext _context)
        {
            Context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserLoan()
        {


            return View();
        }


        public IActionResult LoanBook()
        {
            List<Genre> AuthorsProductsGenres = Context.Genres.Include(x => x.Books).ThenInclude(x => x.Authors).ToList();

            return View(AuthorsProductsGenres);
        }

        [HttpPost]
        public IActionResult LoanBookPage(int Id)
        {
            Book CurrentBook = Context.Books.
                Where(x => x.Id == Id).FirstOrDefault();
            return View(CurrentBook);
        }
    }
}
