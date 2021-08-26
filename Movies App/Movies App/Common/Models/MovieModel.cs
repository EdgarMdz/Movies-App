using System;
using System.Collections.Generic;
using System.Text;

namespace Movies_App
{
    public class MovieModel
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }

        public MovieModel(string title, string posterUrl, string year, string imdbID)
        {
            Title = title;
            ImageUrl = posterUrl;
            Year = year;
            ImdbID = imdbID;
        }
    }
}
