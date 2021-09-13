using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoxOfCourses.Models;

namespace BoxOfCourses.Controllers
{
    public class ViewModel
    {
        public Course Model { get; set; }
        public SelectList ListItems { get; set; }
    }

    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        public ActionResult RecentlyAddedCourses()
        {
            List<Course> listOfCourses = db.Courses.ToList();
            listOfCourses.Reverse();
            List<Course> finallist = new List<Course>();

            foreach(var item in listOfCourses)
            {
                finallist.Add(new Course
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = item.Category,
                    Level = item.Level,
                    ImageURL = item.ImageURL,
                    VideoURL = item.VideoURL,
                    Type = item.Type
                });
            }
            return PartialView(finallist);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            course.Languages = db.Languages.ToList();
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Courses/Create
        public ActionResult Create()
        {
            Course model = new Course();
            model.Types = new System.Collections.Generic.List<string>();
            model.Types.Add("Youtube course");
            model.Types.Add("PluralSight course");
            model.Types.Add("Other platform");

            model.Levels = new System.Collections.Generic.List<string>();
            model.Levels.Add("Beginner");
            model.Levels.Add("Intermediate");
            model.Levels.Add("Advanced");

            model.Categories = new System.Collections.Generic.List<string>();
            model.Categories.Add("Back-End Development");
            model.Categories.Add("Front-End Development");
            model.Categories.Add("Android Development");
            model.Categories.Add("IOS Development");
            model.Categories.Add("Web Development");
            model.Categories.Add("SQA");

            return View(model);
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Category,Level,ImageURL,VideoURL,Type")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            /*course.Languages = db.Languages.ToList();
            var res = db.Languages.ToList().Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Name
                                  });*/
            if (course == null)
            {
                return HttpNotFound();
            }

           /* var selectList = new SelectList(res);
            var vm = new ViewModel
            {
                Model = course,
                ListItems = selectList
            };*/
            return View(course);
        }


        [Authorize(Roles = "Administrator")]
        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Category,Level,ImageURL,VideoURL,Type")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        /*// GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }*/

        /*// POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]*/
        public ActionResult Delete(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
