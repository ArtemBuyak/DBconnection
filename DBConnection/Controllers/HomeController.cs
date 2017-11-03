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
        public ActionResult EditingStudent(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Student student = _context.Stud.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        public ViewResult EditingStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                Student stud = _context.Stud.Find(student.id_student);
                stud.f_name = student.f_name;
                stud.l_name = student.l_name;
                stud.age = student.age;
                stud.course = student.course;
                _context.SaveChanges();
                return View("Index");

            }
            else
            {
                Student stud = _context.Stud.Find(student.id_student);
                return View(stud);
            }
        }

        [HttpGet]
        public ActionResult EditingUser(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            User user = _context.Usr.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ViewResult EditingUser(User user)
        {
            if (ModelState.IsValid)
            {
                User us = _context.Usr.Find(user.id_user);
                us.login = user.login;
                us.password = user.password;
                us.role = user.role;
                _context.SaveChanges();
                return View("User");

            }
            else
            {
                User us = _context.Usr.Find(user.id_user);
                return View(us);
            }
        }

    }
}