using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunMoon.Blog.Mvc3Razor.Models
{
    public class AddFriend
    {

        public string Friend { get; set; }
    }

    public class Person
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public Person()
        {
            this.UserID = this.FirstName = this.LastName = this.Sex = string.Empty;
            this.Birthday = DateTime.Now;
        }
    }
    public class FriendInfo
    {
        public Person Self { get; set; }

        public Person Friend { get; set; }
        public DateTime CreateTime { get; set; }
        public string Circle { get; set; }
        public Guid CircleID { get; set; }

        public FriendInfo()
        {
            this.Self = new Person();
            this.Friend = new Person();

            this.CreateTime = DateTime.Now;
            this.Circle = string.Empty;
            this.CircleID = Guid.NewGuid();
        }
    }

    public class MyFriends
    {
        public List<FriendInfo> Friends { get; set; }
        public string SearchText { get; set; }
        public MyFriends()
        {
            this.Friends = new List<FriendInfo>();
            this.SearchText = string.Empty;
        }

    }
}