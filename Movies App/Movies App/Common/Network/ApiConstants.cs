using System;
using System.Collections.Generic;
using System.Text;

namespace Movies_App
{
    public static class ApiConstants
    {
        public static string GetMoviesUri(string searchTerm)
        {
            return $"https://www.omdbapi.com/?apikey=11cfba5a&s={searchTerm}";
        }

        public static string GetMovieByID(string imdbID)
        {
            return $"https://www.omdbapi.com/?apikey=11cfba5a&i={imdbID}";
        }
    }
}