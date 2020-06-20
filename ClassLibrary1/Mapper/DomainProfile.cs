using AutoMapper;
using ClassLibrary1.Objects.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Mapper
{
    public class DomainProfile:Profile
    {
        protected  void Configure()
        {
            CreateMap<JObject, Films>()
                .ForMember("title", cfg => { cfg.MapFrom(jo => jo["title"]); })
                .ForMember("episode_id", cfg => { cfg.MapFrom(jo => jo["episode_id"]); })
                .ForMember("opening_crawl", cfg => { cfg.MapFrom(jo => jo["opening_crawl"]); })
                .ForMember("release_date", cfg => { cfg.MapFrom(jo => jo["release_date"]); });
        }
    }
}
