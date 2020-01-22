namespace TSVDatabase.Tests
{
    public class TestWriter : IWriter
    {
        public object Output;
        public string Str;
        
        public void Write(object output)
        {
            Output = output;
        }

        public void Write(string s)
        {
            Str = s;
        }
    }
}
