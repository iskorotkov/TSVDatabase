namespace TSVDatabase
{
    public class RemoveOperation : IOperation
    {
        private readonly Table _t;
        private readonly IReader _reader;

        public RemoveOperation(Table t, IReader reader)
        {
            _t = t;
            _reader = reader;
        }

        public void Execute()
        {
            var index = _reader.Number(OperationHints.Remove_AskForRow);
            _t.Remove(index);
        }
    }
}
