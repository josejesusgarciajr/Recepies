using System;
using System.Web.Mvc;

namespace PersonalPlayGround.Filters
{
    public class GlobalExceptionHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            // Log the exception (you can use a logging library like Serilog, NLog, or log4net)
            LogException(filterContext.Exception);

            // Set the result for graceful error handling
            filterContext.Result = new ViewResult
            {
                ViewName = "Error"
            };

            filterContext.ExceptionHandled = true;
        }

        private void LogException(Exception exception)
        {
            //System.IO.File.AppendAllText(@"C:\Logs\GlobalExceptions.txt",
            //    $"{DateTime.Now}: {exception.Message}{Environment.NewLine}{exception.StackTrace}{Environment.NewLine}");
        }
    }
}