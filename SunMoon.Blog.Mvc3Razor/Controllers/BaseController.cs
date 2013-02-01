using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunMoon.Blog.Mvc3Razor.Models;

namespace SunMoon.Blog.Mvc3Razor.Controllers {

    public class BaseController : Controller {

        /// <summary>
        /// 当前用户
        /// </summary>
        public Passport Passport {
            get {
                if (Session["passport"] != null) {
                    return Session["passport"] as Passport;
                }

                return null;
            }
        }

        protected bool IsLogin {
            get {
                if (this.Passport == null) {
                    return false;
                }
                return true;
            }
        }

        protected void ValidationLogin()
        {
            if (!IsLogin)
            {
                throw new Exception("Log in error.");
            }
        }
    }
}