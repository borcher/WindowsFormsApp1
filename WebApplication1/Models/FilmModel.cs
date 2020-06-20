using Data.Entity;
using Domain.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FilmModel
    {
        private FilmDao dao = new FilmDao();
        internal List<Film> GetSearchResults(string film)
        {
            if (!string.IsNullOrEmpty(film))
            {
                return dao.GetResults(film);
            }
            return null;
        }

        internal Film GetFilInfo(int id)
        {
            return dao.GetFilInfo(id);
        }

        internal List<Film> GetLastVisited()
        {
            return dao.GetLastVisited();
        }
    }
}