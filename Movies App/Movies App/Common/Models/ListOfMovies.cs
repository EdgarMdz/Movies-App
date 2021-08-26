using System;
using System.Collections.Generic;
using System.Text;

namespace Movies_App.Common.Models
{
    public class ListOfMovies
    {
        public List<BasicMovieInformation> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }
}
