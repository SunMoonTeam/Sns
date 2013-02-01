using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunMoon.Blog.DataAccess.EntityFramework;
using SunMoon.Blog.Mvc3Razor.Models;

namespace SunMoon.Blog.Mvc3Razor.Controllers {

    public class QueryController : BaseController {
        //
        // GET: /Query/

        public ActionResult Index() {
            return View();
        }

        public ActionResult QueryPerson() {
            base.ValidationLogin();

            QueryPerson model = new QueryPerson();

            using (blogEntities en = new blogEntities()) {
                var result = from user in en.Users
                             select new PersonInfo() {
                                 Age = 20,
                                 DisplayName = user.FirstName + user.LastName,
                                 Name = user.UserID,
                                 Sex = user.Sex
                             };

                model.LoginUser = base.Passport;

                model.Persons = result.ToList();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult QueryPerson(QueryPerson model) {
            if (!IsLogin) {
                return View();
            }
            using (blogEntities en = new blogEntities()) {
                var result = from user in en.Users
                             where
                             !Passport.AccountID.Equals(user.UserID)
                             && user.UserID.Contains(model.Keyword)
                             || user.FirstName.Contains(model.Keyword)
                             || user.LastName.Equals(model.Keyword)
                             || user.FirstNamePy.Equals(model.Keyword)
                             || user.LastNamePy.Equals(model.Keyword)
                             select new PersonInfo() {
                                 Age = 20,
                                 DisplayName = user.FirstName + user.LastName,
                                 Name = user.UserID,
                                 Sex = user.Sex
                             };

                model.Persons = result.ToList();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddFriend(AddFriend model) {
            //if (!IsLogin) {
            //    return View();
            //}
            using (blogEntities ct = new blogEntities()) {
                //SunMoon.Blog.DataAccess.EntityFramework.Friend f = new DataAccess.EntityFramework.Friend();

                //f.CreateTime = DateTime.Now;
                //f.FriendID = model.Friend;
                //f.Self = base.Passport.AccountID;

                //ct.Friends.Add(f);

                SunMoon.Blog.DataAccess.EntityFramework.Message msg = new Message();

                msg.ID = Guid.NewGuid();
                msg.Author = Passport.AccountID;
                msg.CreateTime = DateTime.Now;
                msg.Description = "{'type':'addfriend'}";
                msg.Owner = model.Friend;

                ct.Messages.Add(msg);
                ct.SaveChanges();

                return RedirectToAction("queryperson");
            }
        }
    }
}