using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunMoon.Blog.Mvc3Razor.Models {

    public class PageInfo {

        public PageInfo()
            : this(10, 0) {
        }

        public PageInfo(int pageSize, int recordCount) {
            this.PageSize = PageSize;
            this.RecordCount = recordCount;
            this.CurrentPageIndex = 1;
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPageIndex { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 页总数
        /// </summary>
        public int PageCount {
            get {
                if (PageSize > 0) {
                    if (RecordCount % PageSize == 0)
                        return RecordCount / PageSize;
                    else
                        return RecordCount / PageSize + 1;
                }

                return 0;
            }
        }
    }
}