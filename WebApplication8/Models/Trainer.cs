using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class Trainer : ApplicationUser
    {
        public string Education { get; set; }
        public string WorkPlace { get; set; }
        public string Telephone { get; set; }
        public string Type { get; set; }
    }
}