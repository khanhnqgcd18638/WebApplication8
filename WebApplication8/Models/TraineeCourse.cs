using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class TraineeCourse
    {
        public int Id { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public string TraineeID { get; set; }
        public Trainee Trainee { get; set; }
    }
}