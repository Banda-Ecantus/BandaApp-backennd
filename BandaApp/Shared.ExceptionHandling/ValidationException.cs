using System.Net;

namespace Shared.ExceptionHandling
{
    public class ValidationException : GlobalException
    {

        public string ErrorMessage { get; }

        public HttpStatusCode StatusCode { get; }

        public ValidationException(string message, HttpStatusCode statusCode = HttpStatusCode.MethodNotAllowed)
            : base(message)
        {
            ErrorMessage = message;
            StatusCode = statusCode;
        }
    }
}
