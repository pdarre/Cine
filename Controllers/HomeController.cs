using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Cine.Models;
using System.Web.Mvc;

namespace Cine.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MovieManteinance mm = new MovieManteinance();
            Movie movie = mm.getNowOnCinema();
            return View(movie);
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