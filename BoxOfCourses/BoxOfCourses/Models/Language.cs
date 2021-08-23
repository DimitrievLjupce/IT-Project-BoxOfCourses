using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoxOfCourses.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}