using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}