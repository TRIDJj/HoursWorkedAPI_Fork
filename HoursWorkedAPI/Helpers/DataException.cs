using System;
using System.Globalization;

namespace HoursWorkedAPI.Helpers
{
    public class DataException : Exception
    {
        public DataException() : base() { }

        public DataException(string message) : base(message) { }

        public DataException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}