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
            var (row, column) = _reader.NumberLetter(OperationHints.ResourceManager.GetString("Update - ask for row and column"));
            var value = _reader.Field(OperationHints.ResourceManager.GetString("Update - ask for field value"));
            _t[row, column] = value;
        }
    }
}
