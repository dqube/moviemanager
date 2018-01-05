namespace Movies.Client.Core.ServiceAgents.Interfaces
{
    public interface IMovieClient
    {
        IMoviesService MoviesService { get; }
    }
}
