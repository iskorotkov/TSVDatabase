using System;

namespace TSVDatabase
{
    public class Activity
    {
        private readonly Table _table;
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly DbConnection _connection;

        public Activity(string filename, IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;

            _connection = new DbConnection(filename);
            _table = _connection.Read();
        }

        public void ProcessInput()
        {
            OnHelp();
            while (true)
            {
                var input = Console.ReadLine();
                switch (input)
                {
                    case "add":
                        OnAdd();
                        break;
                    case "read":
                        OnRead();
                        break;
                    case "remove":
                        OnRemove();
                        break;
                    case "update":
                        OnUpdate();
                        break;
                    case "stats":
                        OnStats();
                        break;
                    case "help":
                        OnHelp();
                        break;
                    case "exit":
                        OnExit();
                        return;
                    default:
                        OnDefault();
                        break;
                }

                OnOperationFinished();
            }
        }

        private void OnOperationFinished()
        {
            _writer.Write(OperationHints.OnOperationFinished);
        }

        private void OnDefault()
        {
            _writer.Write(OperationHints.On_default);
        }

        private void OnExit()
        {
            _connection.Write(_table);
        }

        private void OnHelp()
        {
            _writer.Write(OperationHints.OnHelp);
        }

        private void OnStats()
        {
        }

        private void OnUpdate()
        {
            new UpdateOperation(_table, _reader).Execute();
        }

        private void OnRemove()
        {
            new RemoveOperation(_table, _reader).Execute();
        }

        private void OnRead()
        {
            new ReadOperation(_table, _reader, _writer).Execute();
        }

        private void OnAdd()
        {
            new AddOperation(_table, _reader).Execute();
        }
    }
}
