namespace TSVDatabase
{
    public class ReadOperation : IOperation
    {
        private readonly Table _t;
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public ReadOperation(Table t, IReader reader, IWriter writer)
        {
            _t = t;
            _reader = reader;
            _writer = writer;
        }
        
        public void Execute()
        {
            var index = _reader.NullableNumber(OperationHints.ResourceManager.GetString("Read - ask for nullable int"));
            if (index == null)
            {
                _writer.Write(_t);
            }
            else
            {
                var i = (int) index;
                _writer.Write(_t[i]);
            }
        }
    }
}
