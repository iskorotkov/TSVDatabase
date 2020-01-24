namespace TSVDatabase
{
    public class AddOperation : IOperation
    {
        private readonly IReader _reader;
        private readonly Table _t;

        public AddOperation(Table t, IReader reader)
        {
            _t = t;
            _reader = reader;
        }
        
        public void Execute()
        {
            var row = _reader.NullableNumber(OperationHints.Add_AskForRow);
            var record = _reader.Record(OperationHints.Add_AskForRecord);
            _t.InsertAfter(row, record);
        }
    }
}
