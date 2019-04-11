using System;

namespace Lab02Khomenko.Exceptions
{
    class FutureBirthdayException : Exception
    {
        public FutureBirthdayException(DateTime birthDate)
            : base($"Ви вже народились? - {birthDate:dd.MM.yyy} ")
        { }
    }
}
