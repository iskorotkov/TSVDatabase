using System;

namespace TSVDatabase
{
    public class InputFormatException : Exception
    {
        public InputFormatException(string message) : base(message)
        {
        }
    }
}
