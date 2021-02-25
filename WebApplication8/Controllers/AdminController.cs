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
        public ActionResult UpdateStaff(string id)
        {
            var staff = _context.Users
                .OfType<Staff>()
                .SingleOrDefault(t => t.Id == id);
            var updateStaff = new Staff()
            {
                Id = staff.Id,
                Email = staff.Email,
                UserName = staff.UserName,

            };
            return View(updateStaff);
        }
        [HttpPost]
        public ActionResult UpdateStaff(Staff detailStaff)
        {
            var staffID = _context.Users.OfType<Staff>().FirstOrDefault(t => t.Id == detailStaff.Id);
            staffID.UserName = detailStaff.UserName;
            _context.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
        public ActionResult UpdateTrainer(string id)
        {
            var trainer = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.Id == id);
            var updateTrainerView = new Trainer()
            {
                Id = trainer.Id,
                Email = trainer.Email,
                UserName = trainer.UserName,
                Education = trainer.Education,
                WorkPlace = trainer.WorkPlace,
                Telephone = trainer.Telephone,
                Type = trainer.Type
            };
            return View(updateTrainerView);
        }
        [HttpPost]
        public ActionResult UpdateTrainer(Trainer detailsTrainer)
        {
            var trainer = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.Id == detailsTrainer.Id);
            trainer.UserName = detailsTrainer.UserName;
            trainer.Education = detailsTrainer.Education;
            trainer.WorkPlace = detailsTrainer.WorkPlace;
            trainer.Telephone = detailsTrainer.Telephone;
            trainer.Type = detailsTrainer.Type;
            _context.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
    }
}