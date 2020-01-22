using NUnit.Framework;

namespace TSVDatabase.Tests
{
    public class ReadOperationTests
    {
        private Table _t;

        [SetUp]
        public void Setup()
        {
            _t = new Table();
            _t.Add(new Record(1, 2, 3));
            _t.Add(new Record(3, 4, "abc"));
            _t.Add(new Record("abc", "xyz", 1));
        }

        [Test]
        public void ReadOpp()
        {
            var reader = new TestReader(1);
            var writer = new TestWriter();
            var opp = new ReadOperation(_t, reader, writer);
            opp.Execute();
            Assert.AreEqual(new Record(1, 2, 3), writer.Output);
        }

        [Test]
        public void ReadTable()
        {
            // TODO: TestReader(null) creates a reader with empty arguments list
            var reader = new TestReader(null, null);
            var writer = new TestWriter();
            var opp = new ReadOperation(_t, reader, writer);
            opp.Execute();
            Assert.AreEqual(_t, writer.Output);
        }
    }
}
