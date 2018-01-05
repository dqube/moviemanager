using Movies.Client.Core.Infrastructure.Abstractions.Services;
using Movies.Client.Core.ServiceAgents.Interfaces;
using System;

namespace Movies.Client.Core.ServiceAgents
{
    public class MovieClient : IMovieClient
    {

        private readonly IApplicationSettingServiceSingleton _applicationSettingService;

        IMoviesService _moviesService;
        public IMoviesService MoviesService
        {
            get
            {
                return _moviesService ?? (_moviesService = new MoviesService(_applicationSettingService.UrlPrefix));
            }
        }

       

        public MovieClient(IApplicationSettingServiceSingleton applicationSettingService)
            
        {
            if (applicationSettingService == null)
            {
                throw new ArgumentNullException("applicationSettingService");
            }           
            _applicationSettingService = applicationSettingService;
            
        }

        // NOTE: In order to notify "child" _*Service on UrlPrefix
        // change, make 2 things:
        // 1) Add IUpdatableUrlPrefix to its base interface, and
        // 2) Add 'if' below code for such service
        public void Refresh()
        {
            _applicationSettingService.Refresh();
                    
            this.UpdateUrlPrefix(_moviesService);
           
        }

        private void UpdateUrlPrefix(IUpdatableUrl service)
        {
            if (service != null)
            {
                service.UrlPrefix = _applicationSettingService.UrlPrefix;
            }
        }
    }
}
