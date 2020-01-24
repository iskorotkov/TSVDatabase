using System;

namespace TSVDatabase
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object output) => Write(output.ToString());

        public void Write(string s)
        {
            Console.WriteLine(s);
        }
    }
}
