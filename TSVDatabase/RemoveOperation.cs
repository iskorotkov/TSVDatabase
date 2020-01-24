namespace TSVDatabase
{
    public class RemoveOperation : IOperation

    {
        private Table _t;
        private IReader _reader;

        public RemoveOperation(Table t, IReader reader)
        {
            _t = t;
            _reader = reader;
        }

        public void Execute()
        {
            var index = _reader.Number(OperationHints.ResourceManager.GetString("Remove - ask for row"));
            _t.Remove(index);
        }
    }
}
