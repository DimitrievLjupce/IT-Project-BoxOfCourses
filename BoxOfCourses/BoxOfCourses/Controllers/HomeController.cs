using BoxOfCourses.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BoxOfCourses.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Email client from here
        
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(Email model)
        {
            string To = "boxofcourses@gmail.com";
            using (MailMessage mm = new MailMessage(model.EmailFrom, To))
            {
                mm.Subject = model.Subject;
                mm.Body = model.Body;

                if (model.Attachment != null && model.Attachment.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(model.Attachment.FileName);
                    mm.Attachments.Add(new Attachment(model.Attachment.InputStream, fileName));
                }

                    mm.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential cred = new NetworkCredential(model.EmailFrom, model.Password);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = cred;
                        smtp.Port = 587;
                        try
                        {
                            smtp.Send(mm);
                            ViewBag.Message = "Your email has been sent!";
                        }
                        catch (Exception e)
                        {
                            var msg = "Something went wrong, make sure you entered valid google email!";
                            ViewBag.errorMsg = msg;
                        }
                    }
                }
            return View();
        }
    }
}