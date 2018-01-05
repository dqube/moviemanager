using Movies.Client.Core.ServiceAgents.Interfaces;
using Movies.Mapper.Interfaces;
using Movies.ViewModel;
using Movies.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Services
{
    public class MovieService : IMovieService
    {
        IMovieClient _client;
        IMovieMapper _mapper;
        public MovieService(IMovieClient client, IMovieMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }
        public async Task<int> AddAsync(Movie movie)
        {
            return await _client.MoviesService.PostAsync(_mapper.MapToResponse(movie));
        }

        public async Task DeleteAsync(int movieId)
        {
            await _client.MoviesService.DeleteAsync(movieId);
        }

        public async Task<Movie> GetAsync(int movieId)
        {
            return _mapper.MapToViewModel(await _client.MoviesService.GetAsync(movieId));
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return _mapper.MapSearchViewModel(await _client.MoviesService.GetAsync());
        }

        public async Task UpdateAsync(Movie movie)
        {
            await _client.MoviesService.PutAsync(_mapper.MapToResponse(movie));
        }
    }
}
