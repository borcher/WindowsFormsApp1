using ClassLibrary1.Dao.Interfaces;
using ClassLibrary1.Mapper;
using ClassLibrary1.Objects.Classes;
using Data.DataAccesExternal;
using Data.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace Domain.Objects.Dao
{
    public class FilmDao: IFilmDao
    {
        private ExternalData _dataAcces=new ExternalData();
        private CustomMapper<Films> _customMapper = new CustomMapper<Films>();

        public List<Film> GetResults(String Title)
        {
            using (StarWarsEntities1 ent = new StarWarsEntities1())
            {
                var List= ent.Film.Where(x => x.Title.ToLower().Contains(Title.ToLower())).ToList();
                if (List.Count > 0)
                {
                    foreach(var it in List){
                        var film = ent.Film.Where(x => x.Id == it.Id).FirstOrDefault();
                        film.edited = DateTime.Now;
                        film.visited = true;
                        
                    }
                }
                ent.SaveChanges();
                return List;
            }
        }

        public Film GetFilInfo(int id)
        {
            using (StarWarsEntities1 ent = new StarWarsEntities1())
            {
                return ent.Film.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public List<Film> GetLastVisited()
        {
            using (StarWarsEntities1 ent = new StarWarsEntities1())
            {
                return ent.Film.Where(x => x.visited).OrderByDescending(x=>x.edited).Take(2).ToList();
            }
        }

        public void UpdateData()
        {
            try
            {
                if (_dataAcces.CheckLastUpdate())
                {
                    string json = _dataAcces.GetData();
                    var data = MapData(json);
                    using (Data.Entity.StarWarsEntities1 ent = new StarWarsEntities1())
                    {
                        foreach (var item in data)
                        {
                            var id = int.Parse(item.episode_id);
                            var film = ent.Film.Where(x => x.Id == id).FirstOrDefault();
                            if (film != null)
                            {
                                film.opening_crawl = item.opening_crawl;
                                film.director = item.director;
                                film.producer = item.producer;
                                film.url = item.url;
                                film.Title = item.title;
                                film.edited = DateTime.Now;
                                film.releasedate = DateTime.Parse(item.release_date.Replace('-', '/'));
                                film.visited = false;
                            }
                            else
                            {
                                ent.Film.Add(new Film()
                                {
                                    Id = int.Parse(item.episode_id),
                                    opening_crawl = item.opening_crawl,
                                    director = item.director,
                                    producer = item.producer,
                                    url = item.url,
                                    Title = item.title,
                                    created = DateTime.Now,
                                    edited = DateTime.Now,
                                    releasedate = DateTime.Parse(item.release_date.Replace('-', '/'))
                                });
                            }

                        }
                        ent.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string mess = e.InnerException.ToString();
                }
            }
        }

        private List<Films> MapData(string json)
        {
            JObject json2 = JObject.Parse(json);
            var j = json2["results"];
            List<Films> films = new List<Films>();
            foreach (var item in j)
            {
                films.Add( _customMapper.Map(JObject.Parse(item.ToString())));
            }
            return films;
        }

    }
}
