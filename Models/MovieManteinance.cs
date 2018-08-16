using Cine.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Cine.Models
{
    public class MovieManteinance
    {

        public Movie getNowOnCinema()
        {
            var jsonUrl = "https://api.themoviedb.org/3/movie/now_playing?api_key=d45e7033a3e454230103db5acb153928&language=en-US&page=1";
            var json = new WebClient().DownloadString(jsonUrl);
            return JsonConvert.DeserializeObject<Movie>(json);
        }

        public Movie GetMovie(String title)
        {
            String url1 = "https://api.themoviedb.org/3/search/movie?api_key=d45e7033a3e454230103db5acb153928&language=en-US&query=";
            String url2 = "&page=1&include_adult=false";
            String urlCompleta = url1 + title + url2;
            var json = new WebClient().DownloadString(urlCompleta);
            var movie = JsonConvert.DeserializeObject<Movie>(json);
            if (movie.movieDetail.Count() > 0)
            {
                var movieDetailId = movie.movieDetail.FirstOrDefault().Id;
                movie.Cast = getCast(movieDetailId);
                movie.Crew = getCrew(movieDetailId);
            }
            return movie;
        }

        private List<Crew> getCrew(long? movieDetailId)
        {
            var urlCast1 = "https://api.themoviedb.org/3/movie/";
            var urlCast2 = "/credits?api_key=d45e7033a3e454230103db5acb153928";
            var urlCast = urlCast1 + movieDetailId + urlCast2;
            var jsonCast = new WebClient().DownloadString(urlCast);
            var jsonRes = JsonConvert.DeserializeObject<Movie>(jsonCast);
            List<Crew> listaCrew = new List<Crew>();
            foreach (var item in jsonRes.Crew)
            {
                listaCrew.Add(item);
            }
            return listaCrew;
        }

        public List<Cast> getCast(long? movieId)
        {
            var urlCast1 = "https://api.themoviedb.org/3/movie/";
            var urlCast2 = "/credits?api_key=d45e7033a3e454230103db5acb153928";
            var urlCast = urlCast1 + movieId + urlCast2;
            var jsonCast = new WebClient().DownloadString(urlCast);
            var jsonRes = JsonConvert.DeserializeObject<Movie>(jsonCast);
            List<Cast> listaCast = new List<Cast>();
            foreach (var item in jsonRes.Cast)
            {
                listaCast.Add(item);
            }
            return listaCast;
        }

        public Movie getMovieById(int? id)
        {
            var url1 = "http://api.themoviedb.org/3/movie/";
            var url2 = "?api_key=d45e7033a3e454230103db5acb153928";
            var url = url1 + id + url2;
            var json = new WebClient().DownloadString(url);
            var jsonRes = JsonConvert.DeserializeObject<MovieById>(json);
            Movie m = new Movie();
            m.movieById = jsonRes;
            //crea lista cast
            m.Cast = this.getCast(id);
            m.Crew = this.getCrew(id);
            var movieDetailId = jsonRes.Id;
            return m;
            //return jsonRes;
        }
    }
}