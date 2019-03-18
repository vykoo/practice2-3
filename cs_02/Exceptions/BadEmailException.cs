using System;

namespace Practice4.Exceptions
{
    class BadEmailException : ArgumentException
    {
        public BadEmailException(string message)
            : base(message)
        { }
    }

    class TooOldException : ArgumentException
    {
        public TooOldException(string message)
            : base(message)
        { }
    }

    class BirthdayInFutureException : ArgumentException
    {
        public BirthdayInFutureException(string message)
            : base(message)
        { }
    }
}
