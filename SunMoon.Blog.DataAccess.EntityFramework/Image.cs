//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SunMoon.Blog.DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Image
    {
        public System.Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Data { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Owner { get; set; }
        public Nullable<bool> IsAvatar { get; set; }
        public Nullable<System.Guid> AlbumID { get; set; }
        public Nullable<bool> IsCover { get; set; }
        public string Path { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual User User { get; set; }
    }
}