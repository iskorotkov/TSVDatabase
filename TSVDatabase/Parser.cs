using System.Linq;

namespace TSVDatabase
{
    public class Parser
    {
        public Table ParseText(string s)
        {
            var lines = s.Split('\n').Select(e => e.Trim()).Where(e => e.Any());
            var d = new Table();
            foreach (var line in lines)
            {
                d.Add(ParseLine(line));
            }

            return d;
        }

        public Record ParseLine(string s)
        {
            var values = s.Split('\t').Select<string, dynamic>(e =>
            {
                if (int.TryParse(e, out var i))
                {
                    return i;
                }

                return e;
            });
            return new Record(values);
        }
    }
}
