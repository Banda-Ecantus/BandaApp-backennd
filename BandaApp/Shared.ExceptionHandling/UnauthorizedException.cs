namespace Shared.ExceptionHandling
{
    public class UnauthorizedException : GlobalException
    {
        public UnauthorizedException(string message) : base(message) { }
    }
}
