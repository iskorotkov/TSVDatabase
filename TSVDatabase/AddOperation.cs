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
            // TODO: Add hint strings
            var row = _reader.NullableNumber("");
            var record = _reader.Record("");
            _t.InsertAfter(row, record);
        }
    }
}
