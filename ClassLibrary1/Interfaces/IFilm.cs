using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Interfaces
{
    public interface IFilm
    {
        string title { get; set; }
        string episode_id { get; set; }
        string opening_crawl { get; set; }
        string director { get; set; }
        string producer { get; set; }
        DateTime release_date { get; set; }
        string url { get; set; }
        string created { get; set; }
        string edited { get; set; }
    }
}
