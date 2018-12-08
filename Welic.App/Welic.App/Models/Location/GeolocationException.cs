using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AppCenter;

namespace Welic.App.Models.Location
{
    public class GeolocationException : AppCenterException 
    {
        public GeolocationError Error { get; private set; }

        public GeolocationException(GeolocationError error)
            : base("A geolocation error occured: " + error)
        {
            if (!Enum.IsDefined(typeof(GeolocationError), error))
                throw new ArgumentException("error is not a valid GelocationError member", "error");

            Error = error;
        }

        public GeolocationException(GeolocationError error, System.Exception innerException)
            : base("A geolocation error occured: " + error, innerException)
        {
            if (!Enum.IsDefined(typeof(GeolocationError), error))
                throw new ArgumentException("error is not a valid GelocationError member", "error");

            Error = error;
        }
    }
}
