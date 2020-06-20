using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        FilmModel model = new FilmModel();
        public ActionResult Index(string film)
        {
            ViewBag.Message = "Please introduce a title to find";
            if (!string.IsNullOrEmpty(film))
            {
                var result = model.GetSearchResults(film);
                if (result == null || result.Count == 0)
                    ViewBag.Message = "Film not found";
                return View(result);
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(model.GetFilInfo(id));
        }

        [ChildActionOnly]
        public ActionResult LastVisited()
        {
            return View(model.GetLastVisited());
        }
    }
}