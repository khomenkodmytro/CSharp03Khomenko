using System;

namespace Lab02Khomenko.Exceptions
{
    class DistantPastBirthdayException :Exception
    {
        public DistantPastBirthdayException(DateTime birthDate)
            : base($"Ви справді живите так довго? - {birthDate:dd.MM.yyy} ")
        { }
    }
}
