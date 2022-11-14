namespace Backend.ExceptionHandlers
{

    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }

    public class UnauthorizedException : DomainException
    {
        public UnauthorizedException(string message) : base(message) { }
    }

    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class AlreadyExistsException : DomainException
    {
        public AlreadyExistsException(string message) : base(message) { }
    }

}

