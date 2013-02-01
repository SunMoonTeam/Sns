using System;

namespace SunMoon.Blog.Models.DataModel {

    public class User {

        public string UserID { get; set; }

        public string Password { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string FirstNamePy { get; set; }

        public string LastNamePy { get; set; }

        public DateTime CreateTime { get; set; }

        public string Mail { get; set; }

        public string QQ { get; set; }

        public string MobilePhone { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Sex { get; set; }

        public Guid GroupID { get; set; }

        public string RegisterIp { get; set; }
    }
}