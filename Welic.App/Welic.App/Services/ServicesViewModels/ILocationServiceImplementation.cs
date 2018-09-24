using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Welic.App.Models.Location;

namespace Welic.App.Services.ServicesViewModels
{
    public interface ILocationServiceImplementation
    {
        double DesiredAccuracy { get; set; }
        bool IsGeolocationAvailable { get; }
        bool IsGeolocationEnabled { get; }

        Task<Position> GetPositionAsync(TimeSpan? timeout = null, CancellationToken? token = null);
    }
}
