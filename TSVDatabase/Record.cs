using System.Collections.Generic;
using System.Linq;

namespace TSVDatabase
{
    public class Record
    {
        private readonly SortedDictionary<char, Field> _fields = new SortedDictionary<char, Field>();

        public Record(IEnumerable<dynamic> list)
        {
            Initialize(list);
        }

        public Record(IEnumerable<int> list)
        {
            Initialize(list.Select(e => (dynamic) e));
        }

        public Record(IEnumerable<string> list)
        {
            Initialize(list.Select(e => (dynamic) e));
        }

        public Record(params dynamic[] list)
        {
            Initialize(list);
        }

        public Field this[char key]
        {
            get => _fields[key];
            set => _fields[key] = value;
        }

        private void Initialize(IEnumerable<dynamic> list)
        {
            var key = 'A';
            foreach (var item in list)
            {
                if (key > 'Z')
                {
                    throw new RecordOverflowException();
                }

                _fields[key] = item switch
                {
                    int i => new Field(i),
                    string s => new Field(s),
                    _ => throw new UnsupportedRecordTypeException(item.GetType())
                };

                ++key;
            }
        }

        public override string ToString()
        {
            var s = _fields.Aggregate("", (current, field) => current + (field.Value.ToString() + '\t'));
            return s.Trim();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Record r)
            {
                return Equals(r);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _fields != null ? _fields.GetHashCode() : 0;
        }

        public bool Equals(Record r)
        {
            return _fields.Zip(r._fields).All(pair => pair.First.Equals(pair.Second));
        }
    }
}
