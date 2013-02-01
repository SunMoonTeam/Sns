using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunMoon.Blog.DataAccess.EntityFramework;

namespace SunMoon.Blog.Mvc3Razor.Controllers {

    public class CommentController : BaseController {
        //
        // GET: /Comment/

        public ActionResult Index() {
            return View();
        }

        //
        // GET: /Comment/Details/5

        public ActionResult Details(int id) {
            return View();
        }

        //
        // GET: /Comment/Create

        public ActionResult Create() {
            return View();
        }

        //
        // POST: /Comment/Create

        [HttpPost]
        public ActionResult Create(string topicID, string commentID, string description) {
            try {
                // TODO: Add insert logic here
                using (blogEntities ct = new blogEntities()) {
                    Comment c = new Comment();

                    c.Author = base.Passport.AccountID;
                    c.CreateTime = DateTime.Now;
                    c.Description = description;
                    c.ID = Guid.NewGuid();
                    c.IP = Request.UserHostAddress;

                    if (!string.IsNullOrWhiteSpace(commentID))
                        c.ParentId = Guid.Parse(commentID);
                    c.TopicID = Guid.Parse(topicID);

                    ct.Comments.Add(c);
                    ct.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }
            catch {
                return View();
            }
        }

        //
        // GET: /Comment/Edit/5

        public ActionResult Edit(int id) {
            return View();
        }

        //
        // POST: /Comment/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        //
        // GET: /Comment/Delete/5

        public ActionResult Delete(int id) {
            return View();
        }

        //
        // POST: /Comment/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        public ActionResult AddComment() {
            Comment c = new Comment();

            c.Description = "asdfasdf";

            return View(c);
        }

        [HttpPost]
        public ActionResult AddComment(string description, Guid topicId) {
            using (blogEntities ct = new blogEntities()) {
                Comment comment = new Comment();

                comment.ID = Guid.NewGuid();
                comment.CreateTime = DateTime.Now;
                comment.Author = base.Passport.AccountID;
                comment.IP = Request.UserHostAddress;
                comment.Description = description;
                comment.TopicID = topicId;

                ct.Comments.Add(comment);

                ct.SaveChanges();

                return View(comment);
            }

            //return RedirectToAction("index", "home");
        }
    }
}