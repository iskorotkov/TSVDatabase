using System;

namespace TSVDatabase
{
    public class Field
    {
        private int _num;
        private string _str;

        public Field(int num)
        {
            Type = FieldType.Num;
            _num = num;
        }

        public Field(string str)
        {
            Type = FieldType.Str;
            _str = str;
        }

        public FieldType Type { get; private set; }

        public string Str
        {
            get
            {
                if (Type != FieldType.Str)
                {
                    throw new FieldTypeException(FieldType.Str, Type);
                }

                return _str;
            }
            set
            {
                _str = value;
                Type = FieldType.Str;
            }
        }

        public int Num
        {
            get
            {
                if (Type != FieldType.Num)
                {
                    throw new FieldTypeException(FieldType.Num, Type);
                }

                return _num;
            }
            set
            {
                _num = value;
                Type = FieldType.Num;
            }
        }

        public override string ToString()
        {
            return Type switch
            {
                FieldType.Num => Num.ToString(),
                FieldType.Str => Str,
                _ => throw new NotImplementedException()
            };
        }

        public override bool Equals(object? obj)
        {
            if (obj is Field f)
            {
                return Equals(f);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_num, _str, (int) Type);
        }

        public bool Equals(Field other)
        {
            if (Type != other.Type) return false;
            return Type == FieldType.Num && Num == other.Num
                   || Type == FieldType.Str && Str == other.Str;
        }
    }
}
