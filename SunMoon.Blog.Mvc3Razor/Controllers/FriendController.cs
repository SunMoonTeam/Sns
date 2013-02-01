using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunMoon.Blog.DataAccess.EntityFramework;
using SunMoon.Blog.Mvc3Razor.Models;

namespace SunMoon.Blog.Mvc3Razor.Controllers {

    public class FriendController : BaseController {
        //
        // GET: /Friend/

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult AddFriend(AddFriend model) {
            model.Friend = model.Friend.Trim();
            using (var ct = new SunMoon.Blog.DataAccess.EntityFramework.blogEntities()) {
                var user = ct.Users.Single(u => u.UserID.Equals(Passport.AccountID));

                var friend = ct.Users.Single(u => u.UserID.Equals(model.Friend));

                SunMoon.Blog.DataAccess.EntityFramework.Friend f = new DataAccess.EntityFramework.Friend();

                f.Self = user.UserID;
                f.FriendID = model.Friend;
                f.CreateTime = DateTime.Now;

                ct.Friends.Add(f);
                Friend ff = new Friend();

                ff.Self = model.Friend;
                ff.FriendID = user.UserID;
                ff.CreateTime = DateTime.Now;

                ct.Friends.Add(ff);
                ct.SaveChanges();
            }
            return View();
        }

        public ActionResult MyFriends()
        {
            ValidationLogin();

            MyFriends model = new MyFriends();

            using (var ct = new SunMoon.Blog.DataAccess.EntityFramework.blogEntities())
            {
                var lists = ct.Friends.Where(f => f.Self.ToLower().Equals(Passport.AccountID.ToLower())).ToList();

                var results = new List<FriendInfo>();

                foreach (var ff in lists)
                {
                    FriendInfo friend = new FriendInfo();

                    friend.Friend.UserID = ff.FriendID;
                    friend.Friend.FirstName = ff.User.FirstName;
                    friend.Friend.LastName = ff.User.LastName;

                    results.Add(friend);
                }

                model.Friends = results;
            }
            return View(model);
        }
    }
}