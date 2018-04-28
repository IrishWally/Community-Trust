using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Community_Trust.Models;
using Community_Trust.ViewModels;
using System.Data.Entity;

namespace Community_Trust.Controllers
{
    public class AdminController : Controller
    {

        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin
        public ActionResult Index()
        {
            var adminusers = _context.AdminUsers.Include(c => c.AdminType).ToList();
            return View(adminusers);
        }
    }
}