using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SunMoon.Blog.DataAccess.EntityFramework;
using SunMoon.Blog.Mvc3Razor.Models;

namespace SunMoon.Blog.Mvc3Razor.Controllers {

    public class HomeController : BaseController {

        public ActionResult Index1(string userid) {
            ViewBag.Message = "欢迎使用 ASP.NET MVC!";

            IndexModel model = new IndexModel();

            model.Passport = base.Passport;
            using (blogEntities en = new blogEntities()) {
                model.Topics = en.Topics.Where(t => t.Author.Equals(userid))
                    .OrderByDescending(t => t.CreateTime).ToList();
                if (en.Users.Count(u => u.UserID.Equals(userid)) > 0) {
                    model.Author = en.Users.Where(u => u.UserID.Equals(userid)).First();
                    //model.Firends = model.Author.Friends.Select<Friend,User>()
                }
            }

            return View(model);
        }

        public ActionResult Index() {
            using (blogEntities ct = new blogEntities()) {
                History h = new History();

                h.CreateTime = DateTime.Now;
                h.Guest = "guest";
                h.Url = "/";
                h.IP = Request.UserHostAddress;

                ct.Histories.Add(h);
                ct.SaveChanges();
            }

            IndexModel model = new IndexModel();

            if (IsLogin) {
                model.Passport = base.Passport;
                using (blogEntities en = new blogEntities()) {
                    var users = en.Friends.Where(f => f.Self.Equals(Passport.AccountID)).Select(f => f.FriendID).ToList();

                    model.Topics =
                        (from t in en.Topics.Include("Comments")
                         where t.Author.Equals(Passport.AccountID)
                         || users.Contains(t.Author)
                         orderby t.CreateTime descending
                         select t
                             ).ToList();

                    //en.Topics
                    //.Where(
                    //    t =>
                    //        t.Author.Equals(Passport.AccountID)
                    //        || users.Contains(t.Author)
                    //)
                    //.OrderByDescending(t => t.CreateTime)

                    //.ToList();

                    if (en.Users.Count(u => u.UserID.Equals(Passport.AccountID)) > 0) {
                        model.Author = en.Users.Where(u => u.UserID.Equals(Passport.AccountID)).First();
                    }
                }
            }
            else {
                return Redirect("~/Account/LogOn");
            }

          

            return View(model);

            //return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(string title, string desc) {
            using (blogEntities en = new blogEntities()) {
                Topic t = new Topic();

                t.Title = title;
                t.Description = desc;
                t.CreateTime = t.UpdateTime = DateTime.Now;
                t.Author = base.Passport.AccountID;
                t.ID = Guid.NewGuid();

                en.Topics.Add(t);

                en.SaveChanges();
            }

            return RedirectToAction("index");
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult TopicDetailsPartial(Topic model) {
            return View(model);
        }

        public ActionResult GetTopicsView(int? id) {
            if (!IsLogin) {
                return View();
            }

            TopicsPartial model = new TopicsPartial();
            if (id != null)
                model.BeginIndex = id;

            using (blogEntities ct = new blogEntities()) {
                var users = ct.Friends.Where(f => f.Self.Equals(Passport.AccountID)).Select(f => f.FriendID).ToList();

                var lists = from t in ct.Topics.Include("Comments")
                            where t.Author.Equals(Passport.AccountID)
                            || users.Contains(t.Author)
                            orderby t.CreateTime descending
                            select t;
                model.Topics = lists.Skip(model.BeginIndex.Value).Take(model.Count).ToList();

                model.BeginIndex += model.Count;

                if (lists.Count() > model.BeginIndex)
                    model.HaveNextRecord = true;
                else
                    model.HaveNextRecord = false;
            }

            return View(model);
        }
    }
}