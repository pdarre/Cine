using Cine.Models;
using System;
using System.Web.Mvc;

namespace Cine.Controllers
{
    public class HomeController : Controller
    {
        MovieManteinance mm = new MovieManteinance();

        public ActionResult Index()
        {
            return View(mm.getNowOnCinema());
        }

        public ActionResult MovieDetails(String title)
        {
            MovieManteinance mm = new MovieManteinance();
            var movie = mm.GetMovie(title);
            ViewData["movie"] = movie;
            return View();
        }

        public ActionResult Search(String title)
        {
            MovieManteinance mm = new MovieManteinance();
            Movie movie = mm.GetMovie(title);
            ViewData["movie"] = movie;
            return View();
        }

        public ActionResult getMovieById(int id)
        {
            MovieManteinance mm = new MovieManteinance();
            ViewData["movie"] = mm.getMovieById(id);
            return View();
        }
    }
}