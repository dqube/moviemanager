namespace Movies.Client.Core.ServiceAgents
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DocumentResponse;
    using Web;
    using System.Globalization;

    internal class MoviesService : BaseRequest, IMoviesService
    {
        public MoviesService(string urlPrefix)
            : base(urlPrefix)
        {

        }

        public async Task DeleteAsync(int movieId)
        {
            string url = String.Format(CultureInfo.InvariantCulture
               , "{0}movies/{1}", _urlPrefix, movieId);

            await base.DeleteAsync(url);
        }

        public async Task<Movie> GetAsync(int movieId)
        {
            string url = String.Format(CultureInfo.InvariantCulture
               , "{0}movies/{1}", _urlPrefix, movieId);

            return await base.GetAsync<Movie>(url);
        }

        public async Task<IEnumerable<Movie>> GetAsync()
        {
            string url = String.Format(CultureInfo.InvariantCulture
             , "{0}movies", _urlPrefix);

            return await base.GetIEnumerableAsync<Movie>(url);
        }

        public async Task<int> PostAsync(Movie movie)
        {
            string url = String.Format(CultureInfo.InvariantCulture
              , "{0}movies", _urlPrefix);

            return await base.PostAsync<int, Movie>(url, movie);
        }
        public async Task PutAsync(Movie movie)
        {
            string url = String.Format(CultureInfo.InvariantCulture
                , "{0}movies", _urlPrefix);

            await base.PutAsync<Movie>(url, movie);
        }
    }
}
