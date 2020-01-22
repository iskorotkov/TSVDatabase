using System;
using System.Collections.Generic;

namespace TSVDatabase.Tests
{
    public class TestReader : IReader
    {
        private readonly dynamic[] _args;
        public readonly List<string> Hints = new List<string>();
        private int _index;

        public TestReader(params dynamic[] args)
        {
            _args = args;
        }

        public int? NullableNumber(string hint)
        {
            Hints.Add(hint);
            return _args[_index++];
        }

        public int Number(string hint)
        {
            Hints.Add(hint);
            return _args[_index++];
        }

        public Tuple<int, char> NumberLetter(string hint)
        {
            Hints.Add(hint);
            return _args[_index++];
        }

        public Record Record(string hint)
        {
            Hints.Add(hint);
            return _args[_index++];
        }

        public Field Field(string hint)
        {
            Hints.Add(hint);
            return new Field(_args[_index++]);
        }
    }
}
