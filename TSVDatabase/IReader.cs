using System;

namespace TSVDatabase
{
    public interface IReader
    {
        public int? NullableNumber(string hint);
        public int Number(string hint);
        public Tuple<int, char> NumberLetter(string hint);
        public Record Record(string hint);
        public Field Field(string hint);
    }
}
