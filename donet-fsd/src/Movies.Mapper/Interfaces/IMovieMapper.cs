using System.Collections.Generic;
using Movies.ViewModel;
using MovieResponse = Movies.Client.Core.DocumentResponse.Movie;

namespace Movies.Mapper.Interfaces
{
  public interface IMovieMapper
    {
        Movie MapToViewModel(MovieResponse movie);
        MovieResponse MapToResponse(Movie movie);

        IEnumerable<Movie> MapSearchViewModel(IEnumerable<MovieResponse> movies);
    }
}
