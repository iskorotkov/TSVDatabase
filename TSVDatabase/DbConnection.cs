using System.IO;

namespace TSVDatabase
{
    public class DbConnection
    {
        private readonly string _filename;

        public DbConnection(string filename)
        {
            _filename = filename;
        }
        
        public Table Read()
        {
            using var reader = new StreamReader(_filename);
            var p = new Parser();
            return p.ParseText(reader.ReadToEnd());
        }

        public void Write(Table t)
        {
            using var writer = new StreamWriter(_filename);
            writer.Write(t.ToString());
        }
    }
}
