using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SunMoon.Blog.DataAccess.EntityFramework;

namespace SunMoon.Blog.Mvc3Razor.Models {

    public class Messages  {

        public Message this[int index] {
            get {
                return this.Store.Skip(index).First();
            }
        }

        public List<Message> Store { get; set; }        

        public Messages()
            : base() {
            this.Store = new List<Message>();
        }
    }
}