﻿using System.Web.Mvc;

namespace WebApi.ActionFilters
{
    public class ElmahErrorMVCAttribute : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            //Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //http://stackoverflow.com/questions/766610/how-to-get-elmah-to-work-with-asp-net-mvc-handleerror-attribute
            // Log only handled exceptions, because all other will be caught by ELMAH anyway.
            //if (context.ExceptionHandled)

            Elmah.ErrorSignal.FromCurrentContext().Raise(context.Exception);            
        }
    }
}