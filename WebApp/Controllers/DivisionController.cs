﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DivisionController : Controller
    {
        MyContext myContext;

        public DivisionController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        
        // GET ALL
        public IActionResult Index()
        {
            // Untuk Authorize
            /*
            var role = HttpContext.Session.GetString("Role");
            if(role == "Admin")
            {
                var data = myContext.Divisions.ToList();
                return View(data);
            }
            else if (role == null)
            {
                return RedirectToAction("UnAuthorized", "ErrorPage");
            }
            return RedirectToAction("Forbidden", "ErrorPage");
            */

            return View();
        }
        
        // GET BY ID
        public IActionResult Details(int id)
        {
            var data = myContext.Divisions.Find(id);
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
        public IActionResult Create(Division division)
        {
            division.CreatedBy = HttpContext.Session.GetString("FullName");
            division.CreateDate = DateTime.Now.ToLocalTime();
            myContext.Divisions.Add(division);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Division");
            return View();
        }
        // UPDATE - GET POST
        
        public IActionResult Edit(int id)
        {
            var data = myContext.Divisions.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Division division)
        {
            var data = myContext.Divisions.Find(id);
            if (data != null)
            {
                data.Name = division.Name;
                myContext.Entry(data).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index", "Division");
            }
            return View();
        }
        

        // DELETE - GET POST
        public IActionResult Delete(int id)
        {
            var data = myContext.Divisions.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Division division)
        {
            myContext.Divisions.Remove(division);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Division");
            return View();
        }
    }
}
