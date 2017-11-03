using PgDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace DBConnection.Controllers
{
    public class HomeController : Controller
    {
        PGDbContext _context;
        public HomeController()
        {
            _context = new PGDbContext();
        }
        public ViewResult Users()
        {
            return View("Users", _context.Usr.ToList());
        }
        public ViewResult Index()
        {
            var students = _context.Stud.Include(path => path.User);
            return View(students.ToList());
        }


        [HttpGet]
        public ViewResult EditingStudent(int? id)
        {
            Student team = _context.Stud.Find(id);
            return View(team);
        }

        [HttpPost]
        public ViewResult EditingStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", student);

            }
            else
            {
                return View();
            }
        }

    }
}