//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string opening_crawl { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string url { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> edited { get; set; }
        public Nullable<System.DateTime> releasedate { get; set; }
        public bool visited { get; set; }
    }
}
