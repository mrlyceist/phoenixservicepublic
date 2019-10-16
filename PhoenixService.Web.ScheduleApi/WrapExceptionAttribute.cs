using PhoenixService.Domain.Exceptions;
using Serilog;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace PhoenixService.Web.ScheduleApi
{
    public class WrapExceptionAttribute : ActionFilterAttribute
    {
        private readonly Serilog.ILogger logger;

        public WrapExceptionAttribute()
        {
            this.logger = Log.Logger;
        }

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            if (context.Exception == null)
                return;

            var exception = context.Exception;

            logger.Error(exception, "Web exception");

            HttpStatusCode statusCode;
            string message;

            switch (exception)
            {
                case BadRequestException bre:
                    statusCode = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                case NotFoundException nfe:
                    statusCode = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Unexpected error occured";
                    break;
            }

            context.Exception = null;
            context.Response.StatusCode = statusCode;
            context.Response.Content = new StringContent(message);
        }
    }
}