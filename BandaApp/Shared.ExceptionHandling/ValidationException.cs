namespace Shared.ExceptionHandling
{
    public class ValidationException : GlobalException
    {
        public ValidationException(string message) : base(message) { }
    }
}
