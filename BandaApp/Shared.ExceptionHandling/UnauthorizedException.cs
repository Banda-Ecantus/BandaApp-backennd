using System.Net;

namespace Shared.ExceptionHandling
{
    public class UnauthorizedException : GlobalException
    {

        public string ErrorMessage { get; }

        public HttpStatusCode StatusCode { get; }

        public UnauthorizedException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            ErrorMessage = message;
            StatusCode = statusCode;
        }
    }
}
