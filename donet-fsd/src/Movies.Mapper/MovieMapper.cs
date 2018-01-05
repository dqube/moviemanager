using Movies.Mapper.Interfaces;
using Movies.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using MovieResponse = Movies.Client.Core.DocumentResponse.Movie;

namespace Movies.Mapper
{
    public class MovieMapper : IMovieMapper
    {
        public IEnumerable<Movie> MapSearchViewModel(IEnumerable<MovieResponse> movies)
        {
            return movies.Select(m => new Movie()
            {
                MovieID = m.MovieID,
                Title = m.Title,
                Description = m.Description,
                ReleaseDate = m.ReleaseDate,
                Director = m.Director,
                Cast = m.Cast,
                Genre=m.Genre
            });
        }

        public MovieResponse MapToResponse(Movie movie)
        {
            return new MovieResponse
            {
                MovieID = movie.MovieID,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Director = movie.Director,
                Cast = movie.Cast,
               Genre = movie.Genre
            };
        }

        public Movie MapToViewModel(MovieResponse movie)
        {
            return new Movie
            {
                MovieID = movie.MovieID,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Director = movie.Director,
                Cast = movie.Cast,
               Genre = movie.Genre
            };
        }
    }
}
