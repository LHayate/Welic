﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AppCenter;

namespace Welic.App.Services.ServiceViews
{
    class HttpRequestExceptionEx : HttpRequestException
    {
        public System.Net.HttpStatusCode HttpCode { get; }
        public HttpRequestExceptionEx(System.Net.HttpStatusCode code) : this(code, null, null)
        {
        }

        public HttpRequestExceptionEx(System.Net.HttpStatusCode code, string message) : this(code, message, null)
        {
        }

        public HttpRequestExceptionEx(System.Net.HttpStatusCode code, string message, System.Exception  inner) 
            : base(message,
            inner)
        {
            HttpCode = code;
        }
    }
}
