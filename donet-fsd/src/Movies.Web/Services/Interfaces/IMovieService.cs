using Movies.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Services.Interfaces
{
  public  interface IMovieService
    {
        Task<int> AddAsync(Movie movie);
        Task DeleteAsync(int movieId);
        Task<Movie> GetAsync(int movieId);
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task UpdateAsync(Movie movie);
    }
}
