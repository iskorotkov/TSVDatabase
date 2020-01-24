using System;

namespace TSVDatabase
{
    public class ConsoleReader : IReader
    {
        public int? NullableNumber(string hint)
        {
            Console.WriteLine(hint);
            var s = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            if (int.TryParse(s, out var result))
            {
                return result;
            }

            throw new InputFormatException("The string neither empty nor represents an integer.");
        }

        public int Number(string hint)
        {
            Console.WriteLine(hint);
            var s = Console.ReadLine();
            if (int.TryParse(s, out var result))
            {
                return result;
            }

            throw new InputFormatException("Input isn't an integer.");
        }

        public Tuple<int, char> NumberLetter(string hint)
        {
            Console.WriteLine(hint);
            var s = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new InputFormatException("Input string doesn't have any arguments");
            }

            var args = s.Split(' ');
            if (args.Length != 2)
            {
                throw new InputFormatException(
                    "The number of arguments isn't 2. Expected arguments are integer and letter.");
            }

            if (!int.TryParse(args[0], out var index))
            {
                throw new InputFormatException("The first argument isn't an integer.");
            }

            if (args[1].Length > 1)
            {
                throw new InputFormatException("The second argument isn't a single letter.");
            }

            var column = args[1][0];
            return new Tuple<int, char>(index, column);
        }

        public Record Record(string hint)
        {
            Console.WriteLine(hint);
            var s = Console.ReadLine();
            if (string.IsNullOrEmpty(s))
            {
                throw new InputFormatException("Input string is empty and doesn't represent a record.");
            }

            var parser = new Parser();
            return parser.ParseLine(s);
        }

        public Field Field(string hint)
        {
            Console.WriteLine(hint);
            var s = Console.ReadLine();
            if (string.IsNullOrEmpty(s))
            {
                throw new InputFormatException("Input string is empty and doesn't have a field value");
            }

            // TODO: ConsoleInput knows all Field possible types.
            return int.TryParse(s, out var result) ? new Field(result) : new Field(s);
        }
    }
}
