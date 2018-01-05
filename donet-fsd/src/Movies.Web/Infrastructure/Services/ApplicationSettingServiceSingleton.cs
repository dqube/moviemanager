using Movies.Client.Core.Infrastructure.Abstractions.Repositories;
using Movies.Client.Core.Infrastructure.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Infrastructure.Services
{
    public class ApplicationSettingServiceSingleton : IApplicationSettingServiceSingleton
    {
        // Services
        private readonly IApplicationDataRepository _applicationDataRepository;

        private const string UrlPrefixKey = "URLPREFIXKEY";
        private const string DefaultUrlPrefixValue = "http://YOUR_SITE.azurewebsites.net/";
        private string _urlPrefix;

        public ApplicationSettingServiceSingleton(
           IApplicationDataRepository applicationDataRepository)
        {
            if (applicationDataRepository == null)
            {
                throw new ArgumentNullException("applicationDataRepository");
            }
            _applicationDataRepository = applicationDataRepository;
        }

        public string UrlPrefix
        {
            get
            {
                if (string.IsNullOrEmpty(_urlPrefix))
                {
                    _urlPrefix = _applicationDataRepository.GetStringFromApplicationData(UrlPrefixKey, DefaultUrlPrefixValue);
                }

                return _urlPrefix;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == _urlPrefix)
                {
                    return;
                }

                _applicationDataRepository.SetStringToApplicationData(UrlPrefixKey, value);
                _urlPrefix = value;
            }
        }

        public void Refresh()
        {
            _urlPrefix = null;
        }
    }
}
