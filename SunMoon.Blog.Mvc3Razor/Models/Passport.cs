using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunMoon.Blog.Mvc3Razor.Models {

    public class Passport {

        public string AccountID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime LoginTime { get; set; }

        public string IP { get; set; }

        public List<SunMoon.Blog.DataAccess.EntityFramework.User> Friends { get; set; }

        public static Passport CurrentUser {
            get {
                //object obj = sess
                return null;
            }
        }
    }
}