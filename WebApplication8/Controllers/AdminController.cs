using WebApplication8.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication8.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private ApplicationUser _user;
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _usermanager;
        public AdminController()
        {
            _user = new ApplicationUser();
            _context = new ApplicationDbContext();
            _usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        // GET: Admin
        public ActionResult Index()
        {
            var displayuser = _usermanager.Users.Where(t => t.Roles.Any(m => m.RoleId == "2" || m.RoleId == "3") == true).ToList();
            return View(displayuser);
        }

        public ActionResult StaffView()
        {
            var staff = _context.Users.Where(t => t.Roles.Any(m => m.RoleId == "2")).ToList();
            return View(staff);
        }

        public ActionResult TrainerView()
        {
            var trainer = _context.Users.Where(t => t.Roles.Any(m => m.RoleId == "3")).ToList();
            return View(trainer);
        }

        public ActionResult Delete(string id)
        {
            var removeUser = _context.Users.SingleOrDefault(t => t.Id == id);
            _context.Users.Remove(removeUser);
            _context.SaveChanges();
            return RedirectToAction("");
        }

    }
}