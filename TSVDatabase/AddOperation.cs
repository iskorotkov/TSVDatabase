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
            var row = _reader.NullableNumber(OperationHints.ResourceManager.GetString("Add - ask for row"));
            var record = _reader.Record(OperationHints.ResourceManager.GetString("Add - ask for record"));
            _t.InsertAfter(row, record);
        }
    }
}
