using System;

namespace Lab02Khomenko.Exceptions
{
    class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email)
            : base($"не коректна пошта - {email}")
        { }
    }
}
