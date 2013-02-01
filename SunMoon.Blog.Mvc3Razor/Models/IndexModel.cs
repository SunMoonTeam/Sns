using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SunMoon.Blog.DataAccess.EntityFramework;

namespace SunMoon.Blog.Mvc3Razor.Models {

    public class IndexModel {

        public IndexModel() {
            this.Topics = new List<Topic>();
            this.Author = new User();
            this.Firends = new List<User>();
            this.LoginUser = new User();
        }

        public List<Topic> Topics { get; set; }

        public User Author { get; set; }

        public List<User> Firends { get; set; }

        public User LoginUser { get; set; }

        public Passport Passport { get; set; }
    }
}