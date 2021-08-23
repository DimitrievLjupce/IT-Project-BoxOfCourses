using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoxOfCourses.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }
        public List<string> Categories { get; set; }

        public string Level { get; set; }
        public List<string> Levels { get; set; }

        [Display(Name="Image")]
        public string ImageURL { get; set; }
        [Display(Name = "Video")]
        public string VideoURL { get; set; }

        public string Type { get; set; }
        public List<string> Types { get; set; }

        public int LanguageId { get; set; }

        [NotMapped]
        public List<Language> Languages{ get; set; }
    }
}