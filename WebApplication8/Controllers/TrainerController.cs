using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;
using System.Data.Entity;

namespace WebApplication8.Controllers
{
    [Authorize(Roles ="trainer")]
    public class TrainerController : Controller
    {
        private ApplicationUser _user;
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _usermanager;
        public TrainerController()
        {
            _user = new ApplicationUser();
            _context = new ApplicationDbContext();
            _usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        // GET: Trainer
        public ActionResult Index()
        {
            var ftrainerId = User.Identity.GetUserId();
            var trainer = _context.Users.OfType<Trainer>().SingleOrDefault(t=>t.Id == ftrainerId);
            return View(trainer);
        }
        public ActionResult EditTrainer()
        {
            var ftrainerId = User.Identity.GetUserId();
            var trainer = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.Id == ftrainerId);
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
        public ActionResult EditTrainer(Trainer detailsTrainer)
        {
            var ftrainerId = User.Identity.GetUserId();
            var trainer = _context.Users.OfType<Trainer>().SingleOrDefault(t => t.Id == ftrainerId);
            trainer.UserName = detailsTrainer.UserName;
            trainer.Education = detailsTrainer.Education;
            trainer.WorkPlace = detailsTrainer.WorkPlace;
            trainer.Telephone = detailsTrainer.Telephone;
            trainer.Type = detailsTrainer.Type;
            _context.SaveChanges();
            return RedirectToAction("Index","Trainer");
        }
        public ActionResult CourseAssign()
        {
            var ftrainerId = User.Identity.GetUserId();
            var courseAssign = _context.TrainerCourses
                .Where(t => t.TrainerId == ftrainerId)
                .Select(t => t.Course)
                .Include(t => t.Category)
                .ToList();
            return View(courseAssign);
        }
    }
}