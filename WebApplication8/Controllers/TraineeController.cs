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
    [Authorize(Roles = "trainee")]
    public class TraineeController : Controller
    {
        // GET: Trainee
        private ApplicationUser _user;
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _usermanager;
        public TraineeController()
        {
            _user = new ApplicationUser();
            _context = new ApplicationDbContext();
            _usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        // GET: Trainer
        public ActionResult Index()
        {
            var ftraineeId = User.Identity.GetUserId();
            var trainee = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.Id == ftraineeId);
            return View(trainee);
        }
        public ActionResult AllCourse(string searchString)
        {
            var allCourse = _context.Courses.Include(t=>t.Category).ToList();
            if (!String.IsNullOrWhiteSpace(searchString))
            {
                allCourse = _context.Courses
                .Where(t => t.CourseName.Contains(searchString))
                .Include(t => t.Category)
                .ToList();
            }
            return View(allCourse);
        }
        public ActionResult CourseAssign()
        {
            var ftraineeId = User.Identity.GetUserId();
            var courseAssign = _context.TraineeCourses
                .Where(t => t.TraineeID == ftraineeId)
                .Select(t => t.Course)
                .Include(t => t.Category)
                .ToList();
            return View(courseAssign);
        }
    }
}