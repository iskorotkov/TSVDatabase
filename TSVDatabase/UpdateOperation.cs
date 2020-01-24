using System;

namespace TSVDatabase
{
    public class UpdateOperation : IOperation
    {
        private readonly Table _t;
        private readonly IReader _reader;

        public UpdateOperation(Table t, IReader reader)
        {
            _t = t;
            _reader = reader;
        }
        
        public void Execute()
        {
            var (row, column) = _reader.NumberLetter(OperationHints.Update_AskForRowAndColumn);
            var value = _reader.Field(OperationHints.Update_AskForFieldValue);
            _t[row, column] = value;
        }
    }
}
