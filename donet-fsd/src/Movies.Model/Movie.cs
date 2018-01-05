namespace Movies.Model
{
    using Movies.Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieID { get; set; }

        [Required]
        [MinLength(DataConstants.MovieTitleMinLenght)]
        [MaxLength(DataConstants.MovieTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.MovieDescriptionMinLenght)]
        public string Description { get; set; }
       
        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public string Cast { get; set; }

        public string Genre { get; set; }      
      

    }
}