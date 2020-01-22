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
            // TODO: Add hint string
            var index = _reader.Number("");
            _t.Remove(index);
        }
    }
}
