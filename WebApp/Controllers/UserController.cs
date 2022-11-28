using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        MyContext myContext;

        public UserController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        // GET ALL
        public IActionResult Index()
        {
            var data = myContext.Users.ToList();
            return View(data);
        }

        // GET BY ID
        public IActionResult Details(int id)
        {
            var data = myContext.Users.Find(id);
            return View(data);
        }

        // INSERT - GET POST
        public IActionResult Create()
        {
            // get data disini
            // ex: dropdown data didapat dari database
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            myContext.Users.Add(user);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "User");
            return View();
        }
        // UPDATE - GET POST

        public IActionResult Edit(int id)
        {
            var data = myContext.Users.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {
            var data = myContext.Users.Find(id);
            if (data != null)
            {
                data.Password = user.Password;
                data.RoleId = user.RoleId;
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index", "User");
            }
            return View();
        }


        // DELETE - GET POST
        public IActionResult Delete(int id)
        {
            var data = myContext.Users.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(User user)
        {
            myContext.Users.Remove(user);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "User");
            return View();
        }
    }
}
