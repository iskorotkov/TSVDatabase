using System;

namespace TSVDatabase
{
    public class UnsupportedRecordTypeException : Exception
    {
        public UnsupportedRecordTypeException(Type type) : base($"Records do not support type {type}")
        {
        }
    }
}
