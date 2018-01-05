using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Client.Core.Infrastructure.Abstractions.Services
{
    public interface IApplicationSettingServiceSingleton
    {
        string UrlPrefix { get; set; }
       
        void Refresh();
    }
}
