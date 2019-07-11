using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieReviewApp.Data;

namespace MovieReviewApp.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<Models.Movie> movies = new List<Models.Movie>();
            var db = new MovieReviewEntities();
            db.Movies.AsNoTracking().ToList().ForEach(x =>
            {
                Models.Movie movie = new Models.Movie();
                movie.Id = x.Id;
                movie.Code = x.Code;
                movie.Name = x.Name;
                movie.ReleaseDate = x.ReleaseDate;
                movie.Synopsis = x.Synopsis;
                movies.Add(movie);
            });
            //return Content("Movie");
            return View(movies);
        }

        //[ChildActionOnly]
        public ActionResult Message()
        {
            return View("Error");
            //return Content("asdf");
        }
    }
}