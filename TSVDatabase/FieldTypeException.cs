using System;

namespace TSVDatabase
{
    public class FieldTypeException : Exception
    {
        public FieldTypeException(FieldType expected, FieldType actual) :
            base($"Expected field type {expected.ToString()} when the actual type was {actual.ToString()}.")
        {
            Expected = expected;
            Actual = actual;
        }

        public FieldType Expected { get; }
        public FieldType Actual { get; }
    }
}
