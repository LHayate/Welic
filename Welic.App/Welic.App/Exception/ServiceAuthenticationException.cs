using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AppCenter;

namespace Welic.App.Exception
{
    public class ServiceAuthenticationException : System.Exception
    {
        public string Content { get; }

        public ServiceAuthenticationException()
        {
        }

        public ServiceAuthenticationException(string content)
        {
            Content = content;
        }
        
    }
}
