using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Detail { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}