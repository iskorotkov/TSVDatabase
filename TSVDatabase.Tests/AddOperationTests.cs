using NUnit.Framework;

namespace TSVDatabase.Tests
{
    public class OperationsTests
    {
        [Test]
        public void AddOpp()
        {
            var t = new Table();
            var reader = new TestReader(null, new Record(1, 2, 3, 4, 5, 6, 7));
            var add = new AddOperation(t, reader);
            add.Execute();

            Assert.AreEqual(1, t.Count);
            Assert.AreEqual(new Record(1, 2, 3, 4, 5, 6, 7), t[1]);

            reader = new TestReader(null, new Record("abc", "def", 11, 12, 13, 14, 15));
            add = new AddOperation(t, reader);
            add.Execute();

            Assert.AreEqual(2, t.Count);
            Assert.AreEqual(new Record(1, 2, 3, 4, 5, 6, 7), t[1]);
            Assert.AreEqual(new Record("abc", "def", 11, 12, 13, 14, 15), t[2]);
            // TODO: Check hints sent to reader

            reader = new TestReader(1, new Record("x", "y", "z", 100, 101, 102, 103, "www"));
            add = new AddOperation(t, reader);
            add.Execute();

            Assert.AreEqual(3, t.Count);
            Assert.AreEqual(new Record(1, 2, 3, 4, 5, 6, 7), t[1]);
            Assert.AreEqual(new Record("x", "y", "z", 100, 101, 102, 103, "www"), t[2]);
            Assert.AreEqual(new Record("abc", "def", 11, 12, 13, 14, 15), t[3]);
        }
    }
}
