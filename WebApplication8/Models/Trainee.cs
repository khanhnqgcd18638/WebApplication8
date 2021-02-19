using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class Trainee : ApplicationUser
    {
        public int Age { get; set; }
        public string DateofBirth { get; set; }
        public string Education { get; set; }
        public string MainProgrammingLang { get; set; }
        public float ToeicScore { get; set; }
        public string ExpDetail { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
    }
}