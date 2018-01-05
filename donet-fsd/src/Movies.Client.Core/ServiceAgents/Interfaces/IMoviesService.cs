
using Movies.Client.Core.DocumentResponse;
using Movies.Client.Core.ServiceAgents.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Client.Core.ServiceAgents
{
    public interface IMoviesService : IUpdatableUrl
    {
        Task<Movie> GetAsync(int movieId);

        Task<IEnumerable<Movie>> GetAsync();
        Task<int> PostAsync(Movie movie);

        Task PutAsync(Movie movie);

        Task DeleteAsync(int movieId);

    }
}
