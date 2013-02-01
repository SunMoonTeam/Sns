using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunMoon.Blog.DataAccess.EntityFramework;
using SunMoon.Blog.Mvc3Razor.Models;

namespace SunMoon.Blog.Mvc3Razor.Controllers {

    public class TopicController : BaseController {
        //
        // GET: /Topic/

        public ActionResult Index() {
            return View();
        }

        public ActionResult AddTopic() {
            Topic t = new Topic();

            t.Description = "alsdjflasdjf";
            t.CreateTime = DateTime.Now;
            t.Author = "jjjj";

            //return Json(t, JsonRequestBehavior.AllowGet);
            return View(t);
        }

        [HttpPost]
        public ActionResult AddTopic(string title, string desc) {
            using (blogEntities en = new blogEntities()) {
                Topic t = new Topic();

                t.Title = title;
                t.Description = desc;
                t.CreateTime = t.UpdateTime = DateTime.Now;
                t.Author = base.Passport.AccountID;
                t.ID = Guid.NewGuid();

                en.Topics.Add(t);

                en.SaveChanges();

                return View(t);
            }
        }

        public ActionResult TopicDetailsPartial(Topic model) {
            return View(model);
        }
    }
}