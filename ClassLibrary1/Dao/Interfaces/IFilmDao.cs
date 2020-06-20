using ClassLibrary1.Objects.Classes;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Dao.Interfaces
{
    public interface IFilmDao
    {
        List<Film> GetResults(String Title);
        Film GetFilInfo(int id);

        List<Film> GetLastVisited();
        void UpdateData();
    }
}
