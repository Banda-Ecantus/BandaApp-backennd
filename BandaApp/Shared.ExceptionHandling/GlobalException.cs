namespace Shared.ExceptionHandling
{
    public abstract class GlobalException : Exception
    {
        protected GlobalException(string message) : base(message) { }
    }
}
