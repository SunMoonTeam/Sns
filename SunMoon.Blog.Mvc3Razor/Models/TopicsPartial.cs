using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SunMoon.Blog.DataAccess.EntityFramework;

namespace SunMoon.Blog.Mvc3Razor.Models {

    public class TopicsPartial {

        public int Count { get; set; }

        public int? BeginIndex { get; set; }

        public List<Topic> Topics { get; set; }

        public bool HaveNextRecord { get; set; }

        public TopicsPartial() {
            this.Count = 10;
            this.BeginIndex = 0;
            this.Topics = new List<Topic>();
            this.HaveNextRecord = true;
        }
    }
}