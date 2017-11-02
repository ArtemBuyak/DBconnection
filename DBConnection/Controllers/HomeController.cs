using PgDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBConnection.Controllers
{
    public class HomeController : Controller
    {
        PGDbContext _context;
        public HomeController()
        {
            _context = new PGDbContext();
        }
        public ActionResult Index()
        {
            return View(_context.Usr.ToList());
        }

    }
}