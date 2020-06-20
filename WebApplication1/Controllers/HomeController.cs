using Data.Entity;
using Domain.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private FilmDao dao = new FilmDao();
        public ActionResult Index(string film)
        {
            ViewBag.Message = "";
            List<Film> value = null;
            ViewBag.Message = "Please introduce a title to find";
            if (!string.IsNullOrEmpty(film))
            {
                value = dao.GetResults(film);
                if (value == null || value.Count==0)
                    ViewBag.Message = "Film not found";
            }
            return View(value);
        }

        public ActionResult Details(int id)
        {
            return View(dao.GetFilInfo(id));
        }


        [ChildActionOnly]
        public ActionResult LastVisited()
        {
            
            return View(dao.GetLastVisited());
        }
    }
}