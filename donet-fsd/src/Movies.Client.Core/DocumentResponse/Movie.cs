using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Client.Core.DocumentResponse
{
   public class Movie
    {
       
        public int MovieID { get; set; }

       
        public string Title { get; set; }

        
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public string Cast { get; set; }

        public string Genre { get; set; }
    }
}
