using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ExceptionHandling
{
    public class GenericException :GlobalException
    {

        public string ErrorMessage { get; }

        public HttpStatusCode StatusCode { get; }

        public GenericException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            ErrorMessage = message;
            StatusCode = statusCode;
        }
    }
}
