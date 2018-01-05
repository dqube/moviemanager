using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Client.Core.ServiceAgents.Interfaces
{
    public interface IUpdatableUrl
    {
        string UrlPrefix { get; set; }
    }
}
