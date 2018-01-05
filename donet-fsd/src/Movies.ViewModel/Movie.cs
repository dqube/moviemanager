namespace Movies.ViewModel
{
    using Movies.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieID { get; set; }

        [Required]
        [MinLength(WebConstants.MovieTitleMinLenght)]
        [MaxLength(WebConstants.MovieTitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MinLength(WebConstants.MovieDescriptionMinLenght)]
        public string Description { get; set; }
       
        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public string Cast { get; set; }

        public string Genre { get; set; }      

        //[Required]
        //[MaxLength(DataConstants.MovieThumbnailUrlMaxLenght)]
        //public string ThumbnailUrl { get; set; }

    }
}