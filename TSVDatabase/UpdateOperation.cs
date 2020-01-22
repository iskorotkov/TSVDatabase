using System;

namespace TSVDatabase
{
    public class UpdateOperation : IOperation
    {
        private Table _t;
        private IReader _reader;

        public UpdateOperation(Table t, IReader reader)
        {
            _t = t;
            _reader = reader;
        }
        
        public void Execute()
        {
            // TODO: Add hint string
            var (row, column) = _reader.NumberLetter("");
            var value = _reader.Field("");
            _t[row, column] = value;
        }
    }
}
