using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SunMoon.Blog.DataAccess.EntityFramework;

namespace SunMoon.Blog.Mvc3Razor.Models {

    public class QueryPerson {

        /// <summary>
        /// 当前登录的用户
        /// </summary>
        public Passport LoginUser { get; set; }

        List<PersonInfo> persons;

        /// <summary>
        /// 搜索结果
        /// </summary>
        public List<PersonInfo> Persons {
            get {
                if (persons == null)
                    persons = new List<PersonInfo>();

                return this.persons;
            }
            set {
                persons = value;

                this.Pager.RecordCount = Persons.Count;
            }
        }

        /// <summary>
        /// 搜索文本
        /// </summary>
        [DisplayName("关键字")]
        public string Keyword { get; set; }

        public PageInfo Pager { get; set; }

        public QueryPerson() {
            this.Pager = new PageInfo(20, 0);
            this.Persons = new List<PersonInfo>();
            this.Keyword = string.Empty;

            //this.LoginUser = .
        }
    }

    public class PersonInfo {

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 花名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public Image Avatar { get; set; }

        /// <summary>
        /// 头像路径
        /// </summary>
        public string AvatarPath { get; set; }
    }
}