using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Location;
using Welic.App.Services.ServicesViewModels;

namespace Welic.App.Services.ServiceViews
{
    public class LocationService : ILocationService
    {
        private readonly IRequestProvider _requestProvider;

        public LocationService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task UpdateUserLocation(Location newLocReq, string token)
        {
            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.BaseEndpoint);
            builder.Path = "/mobilemarketingapigw/api/v1/l/locations";
            string uri = builder.ToString();
            await _requestProvider.PostAsync(uri, newLocReq, token);
        }
    }
}
