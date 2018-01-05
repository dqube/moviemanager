using Movies.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Api.Data
{
    public interface IMoviesRepository
    {
        Task<int> AddAsync(Movie movie);
        Task DeleteAsync(int movieId);
        Task<Movie> GetAsync(int movieId);
        //Task<IEnumerable<Movie>> GetMoviesAsync(string filter, int pageSize, int pageCount);
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> UpdateAsync(Movie Movie);
    }
}
