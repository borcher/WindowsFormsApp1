using ClassLibrary1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Objects
{
    public class Films : IFilm
    {
        public string title { get;set; }
        public string episode_id { get;set; }
        public string opening_crawl { get;set; }
        public string director { get;set; }
        public string producer { get;set; }
        public DateTime release_date { get;set; }
        public string url { get;set; }
        public string created { get;set; }
        public string edited { get;set; }
    }
}
