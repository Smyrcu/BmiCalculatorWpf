using System;

namespace WpfApp1.Exceptions
{
    public class BadValueException : Exception
    {
        public BadValueException() : base("Wrong value has been provided.")
        {
            
        }
    }
}
