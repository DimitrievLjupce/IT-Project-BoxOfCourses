using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoxOfCourses.Models
{
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Category { get; set; }
        public List<string> Categories { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public int ReviewValue { get; set; }

        public string CurrentDate { get; set; }
    }
}