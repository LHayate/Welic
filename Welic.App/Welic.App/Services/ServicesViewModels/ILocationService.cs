using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Location;

namespace Welic.App.Services.ServicesViewModels
{
    public interface ILocationService
    {
        Task UpdateUserLocation(Location newLocReq, string token);
    }
}
