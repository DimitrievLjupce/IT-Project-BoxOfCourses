using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoxOfCourses.Models
{
    public class Email
    {
        public string Subject { get; set; }
        [Required(ErrorMessage = "The body field is required!")]
        [Display(Name = "Message")]
        public string Body { get; set; }
        public HttpPostedFileBase Attachment { get; set; }
        [Required(ErrorMessage = "Please enter your email.")]
        [Display(Name ="Your email")]
        public string EmailFrom { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
    }
}