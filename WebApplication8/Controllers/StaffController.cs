using WebApplication8.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDeve.Controllers
{
    public class StaffController : Controller
    {
        private ApplicationUser _user;
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _usermanager;
        public StaffController()
        {
            _user = new ApplicationUser();
            _context = new ApplicationDbContext();
            _usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TraineeManagement(string searchString)
        {

            var trainee = _context.Users.Where(t => t.Roles.Any(r => r.RoleId == "4")).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                trainee = _context.Users
                    .Where(t => t.Roles.Any(r => r.RoleId == "4") && t.UserName.Contains(searchString) == true)
                    .ToList();
            }
            return View(trainee);
        }
        public ActionResult DeleteTrainee(string id)
        {
            var removeTrainee = _context.Users.SingleOrDefault(t => t.Id == id);
            _context.Users.Remove(removeTrainee);
            _context.SaveChanges();
            return RedirectToAction("TraineeManagement");
        }

        public ActionResult UpdateTrainee(string id)
        {
            var trainee = _context.Users
                .OfType<Trainee>()
                .SingleOrDefault(t => t.Id == id);
            var updateTrainee = new Trainee()
            {
                Id = trainee.Id,
                Email = trainee.Email,
                UserName = trainee.UserName,
                Age = trainee.Age,
                DateofBirth = trainee.DateofBirth,
                Education = trainee.Education,
                MainProgrammingLang = trainee.MainProgrammingLang,
                ToeicScore = trainee.ToeicScore,
                ExpDetail = trainee.ExpDetail,
                Department = trainee.Department,
                Location = trainee.Location

            };
            return View(updateTrainee);
        }
        [HttpPost]
        public ActionResult UpdateTrainee(Trainee detaisTrainee)
        {
            var traineesearch = _context.Users.OfType<Trainee>().FirstOrDefault(t => t.Id == detaisTrainee.Id);
            traineesearch.UserName = detaisTrainee.UserName;
            traineesearch.Age = detaisTrainee.Age;
            traineesearch.DateofBirth = detaisTrainee.DateofBirth;
            traineesearch.Education = detaisTrainee.Education;
            traineesearch.MainProgrammingLang = detaisTrainee.MainProgrammingLang;
            traineesearch.ToeicScore = detaisTrainee.ToeicScore;
            traineesearch.ExpDetail = detaisTrainee.ExpDetail;
            traineesearch.Department = detaisTrainee.Department;
            traineesearch.Location = detaisTrainee.Location;
            _context.SaveChanges();
            return RedirectToAction("TraineeManagement");
        }
        public ActionResult DetailsTrainee(string id)
        {
            var trainee = _context.Users.SingleOrDefault(t => t.Id == id);
            return View(trainee);
        }
        public ActionResult TrainerProfile(string searchString)
        {
            var trainer = _context.Users.Where(t => t.Roles.Any(r => r.RoleId == "3")).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {

                trainer = _context.Users
                    .Where(t => t.Roles.Any(r => r.RoleId == "3") && t.UserName.Contains(searchString) == true)
                    .ToList();
            }
            return View(trainer);
        }
        public ActionResult DetailsTrainer(string id)
        {
            var trainer = _context.Users.SingleOrDefault(t => t.Id == id);
            return View(trainer);
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
            return RedirectToAction("TrainerProfile");
        }
        public ActionResult CourseManagement(string searchString)
        {
            var courses = _context.Courses.Include(t => t.Category).ToList();
            if (!String.IsNullOrWhiteSpace(searchString))
            {
                courses = _context.Courses
                .Where(t => t.CourseName.Contains(searchString))
                .Include(t => t.Category)
                .ToList();
            }
            return View(courses);
        }
        public ActionResult CategoryView(string searchString)
        {
            var categories = _context.Categories.ToList();
            if (!String.IsNullOrWhiteSpace(searchString))
            {
                 categories = _context.Categories
                .Where(t => t.CategoryName.Contains(searchString))
                .ToList();
            }
            return View(categories);
        }
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            var create_category = new Category() { CategoryName = category.CategoryName };
            _context.Categories.Add(create_category);
            _context.SaveChanges();
            return RedirectToAction("CategoryView");
        }
        public ActionResult DeleteCategory(int id)
        {
            var removeCategory = _context.Categories.SingleOrDefault(t => t.Id == id);
            _context.Categories.Remove(removeCategory);
            _context.SaveChanges();
            return RedirectToAction("CategoryView");
        }
        public ActionResult CreateCourse()
        {
            var courseCategory = new CategoryCourseViewModel()
            {
                Categories = _context.Categories.ToList(),
            };
            return View(courseCategory);
        }
        [HttpPost]
        public ActionResult CreateCourse(CategoryCourseViewModel categoryCourseModel)
        {
            var new_course = new Course()
            {
                CourseName = categoryCourseModel.Course.CourseName,
                Detail = categoryCourseModel.Course.Detail,
                CategoryID = categoryCourseModel.Id
            };
            _context.Courses.Add(new_course);
            _context.SaveChanges();
            return RedirectToAction("CourseManagement");
        }
        public ActionResult DeleteCourse(int id)
        {
            var removeCourse = _context.Courses.SingleOrDefault(t => t.Id == id);
            _context.Courses.Remove(removeCourse);
            _context.SaveChanges();
            return RedirectToAction("CourseManagement");
        }
        public ActionResult EditCourse(int id)
        {
            var fcourse = _context.Courses.SingleOrDefault(t => t.Id == id);
            var dcourse = new CategoryCourseViewModel()
            {
                Id = id,
                Course = fcourse,
                Categories = _context.Categories.ToList()
            };
            return View(dcourse);
        }
        [HttpPost]
        public ActionResult EditCourse(CategoryCourseViewModel viewModel)
        {
            var course = _context.Courses.SingleOrDefault(t => t.Id == viewModel.Id);
            course.CourseName = viewModel.Course.CourseName;
            course.CategoryID = viewModel.Course.CategoryID;
            course.Detail = viewModel.Course.Detail;
            _context.SaveChanges();
            return RedirectToAction("CourseManagement", "Staff");
        }
        public ActionResult DetailCourse(int id)
        {
            var course = new CategoryCourseViewModel();
            course.Id = id;
            course.Course = _context.Courses.Include(t => t.Category).SingleOrDefault(t => t.Id == id);
            return View(course);
        }
        public ActionResult Assign(int id)
        {
            var assign = new AssignViewModel()
            {
                TraineeCourses = _context.TraineeCourses.Where(t=>t.CourseID==id).Include(t=>t.Trainee).ToList(),
                TrainerCourses = _context.TrainerCourses.Where(t => t.CourseId == id).Include(t=>t.Trainer).ToList(),
                Course = _context.Courses.FirstOrDefault(t => t.Id == id)
            };

            return View(assign);
        }
        public ActionResult AssignTrainee(int id)
        {
            var assignModel = new AssignViewModel()
            {
                Course = _context.Courses.SingleOrDefault(t=>t.Id == id),
                Trainees = _context.Users.OfType<Trainee>().ToList(),
            };

            return View(assignModel);
        }
        [HttpPost]
        public ActionResult AssignTrainee(AssignViewModel model)
        {
            var traineeCourse = new TraineeCourse()
            {
                TraineeID = model.TraineeId,
                CourseID = model.Course.Id,
            };
            if(_context.TraineeCourses.Any(t=>t.CourseID == model.Course.Id && t.TraineeID == model.TraineeId))
            {
                ModelState.AddModelError("Validation", "It's existed before");
                return View(model);
            }
            _context.TraineeCourses.Add(traineeCourse);
            _context.SaveChanges();
            return RedirectToAction("Assign","Staff",new { @id = model.Course.Id});
        }
        public ActionResult RemoveTrainee(int id)
        {
            var traineeCourse = _context.TraineeCourses.SingleOrDefault(t => t.Id == id);
            _context.TraineeCourses.Remove(traineeCourse);
            _context.SaveChanges();
            return RedirectToAction("Assign", "Staff", new { @id = traineeCourse.CourseID });
        }
        public ActionResult AssignTrainer(int id)
        {
            var assignModel = new AssignViewModel()
            {
                Course = _context.Courses.SingleOrDefault(t => t.Id == id),
                Trainers = _context.Users.OfType<Trainer>().ToList(),
            };

            return View(assignModel);
        }
        [HttpPost]
        public ActionResult AssignTrainer(AssignViewModel model)
        {
            var trainerCourse = new TrainerCourse()
            {
                TrainerId = model.TrainerId,
                CourseId = model.Course.Id,
            };
            if (_context.TrainerCourses.Any(t => t.CourseId == model.Course.Id && t.TrainerId == model.TrainerId))
            {
                ModelState.AddModelError("Validation", "It's existed before");
                return View(model);
            }
            _context.TrainerCourses.Add(trainerCourse);
            _context.SaveChanges();
            return RedirectToAction("Assign", "Staff", new { @id = model.Course.Id });
        }
        public ActionResult RemoveTrainer(int id)
        {
            var trainerCourse = _context.TrainerCourses.SingleOrDefault(t => t.Id == id);
            _context.TrainerCourses.Remove(trainerCourse);
            _context.SaveChanges();
            return RedirectToAction("Assign","Staff",new { @id = trainerCourse.CourseId });
        }
    }
}