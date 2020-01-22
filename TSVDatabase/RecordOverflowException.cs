using System;

namespace TSVDatabase
{
    public class RecordOverflowException : Exception
    {
        public RecordOverflowException() : base("Can't add that much columns to the record.")
        {
        }
    }
}
