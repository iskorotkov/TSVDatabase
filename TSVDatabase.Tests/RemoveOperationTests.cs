using NUnit.Framework;

namespace TSVDatabase.Tests
{
    public class DeleteOperationTests
    {
        [Test]
        public void RemoveOp()
        {
            var t = new Table();
            t.Add(new Record(1, 2, 3));
            t.Add(new Record(4, 5, 6));
            t.Add(new Record(7, 8, 9));
            
            var reader = new TestReader(1);
            var op = new RemoveOperation(t, reader);
            op.Execute();
            Assert.AreEqual(2, t.Count);
            Assert.AreEqual(new Record(4,5,6), t[1]);
            Assert.AreEqual(new Record(7,8,9), t[2]);
            
            reader = new TestReader(2);
            op = new RemoveOperation(t, reader);
            op.Execute();
            Assert.AreEqual(1, t.Count);
            Assert.AreEqual(new Record(4, 5, 6), t[1]);
            
            reader = new TestReader(1);
            op = new RemoveOperation(t, reader);
            op.Execute();
            Assert.AreEqual(0, t.Count);
        }
    }
}
