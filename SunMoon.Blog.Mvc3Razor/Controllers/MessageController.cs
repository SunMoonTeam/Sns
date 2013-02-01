using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunMoon.Blog.DataAccess.EntityFramework;

namespace SunMoon.Blog.Mvc3Razor.Controllers
{
    public class MessageController : BaseController
    {
        //
        // GET: /Message/

        public ActionResult Index() {
            return View();
        }

        public ActionResult GetMessages() {
            using (blogEntities ct = new blogEntities()) {
                var lists = ct.Messages.Where(m => m.Owner.Equals(Passport.AccountID)).ToList();

                Models.Messages model = new Models.Messages();

                model.Store = lists;

                return View(model);
            }
        }
    }
}
