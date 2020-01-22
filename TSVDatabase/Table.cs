using System.Collections.Generic;
using System.Linq;

namespace TSVDatabase
{
    public class Table
    {
        private readonly List<Record> _records = new List<Record>();

        public int Count => _records.Count;

        // TODO: Throw exception with meaningful message if index is out of bounds
        public Record this[int n]
        {
            get => _records[n - 1];
            set => _records[n - 1] = value;
        }

        public Field this[int n, char c]
        {
            get => _records[n - 1][c];
            set => _records[n - 1][c] = value;
        }

        public void Add(Record r)
        {
            _records.Add(r);
        }

        public override string ToString()
        {
            var s = _records.Aggregate("", (current, record) => current + (record.ToString() + '\n'));
            return s.Trim();
        }

        public void InsertAfter(int? index, Record r)
        {
            if (index == null)
            {
                Add(r);
            }

            else
            {
                var i = (int) index;
                _records.Insert(i, r);
            }
        }

        public void Remove(int index)
        {
            _records.RemoveAt(index - 1);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Table t)
            {
                return Equals(t);
            }

            return base.Equals(obj);
        }

        public bool Equals(Table t)
        {
            return _records.Zip(t._records).All(pair => pair.First.Equals(pair.Second));
        }
    }
}
