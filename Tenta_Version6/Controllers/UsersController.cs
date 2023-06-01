using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tenta_Version6.Models;

namespace Tenta_Version6.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationContext Context;

        public UsersController(ApplicationContext _context)
        {
            Context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult DeleteUser(int removeUserId)
        {
            User RemoveUser = Context.Users.FirstOrDefault(x => x.Id == removeUserId);
            Context.Users.Remove(RemoveUser);
            Context.SaveChanges();

            return RedirectToAction("ListOfUsers");
        }

        public IActionResult EditUser(int Id)
        {

            User EditUser = Context.Users.FirstOrDefault(x => x.Id == Id);
            return View(EditUser);
        }


        [HttpPost]
        public IActionResult EditUser(int Id, string UserName, string UserAddress, int UserPhoneNumber)
        {
            User EditedUser = Context.Users.FirstOrDefault(x => x.Id == Id);
            if (EditedUser == null)
            {
                return NotFound(); // return a 404 Not Found error
            }
            EditedUser.Name = UserName;
            EditedUser.Address = UserAddress;
            EditedUser.PhoneNumber = UserPhoneNumber;
            Context.Users.Update(EditedUser);
            Context.SaveChanges();
            return RedirectToAction("ListOfUsers");
        }




        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(string UserName, string UserAddress, int UserPhoneNumber)
        {
            User newUser = new User()
            {
                Name = UserName,
                Address = UserAddress,
                PhoneNumber = UserPhoneNumber
            };
            Context.Users.Add(newUser);
            Context.SaveChanges();
            return View();
        }

        public IActionResult ListOfUsers()
        { 
            List<User> ListUsers = Context.Users.Include(x => x.Books).ToList();
            return View(ListUsers);
        }
    }
}
