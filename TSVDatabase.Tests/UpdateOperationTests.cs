using System;
using NUnit.Framework;

namespace TSVDatabase.Tests
{
    public class UpdateOperationTests
    {
        [Test]
        public void UpdateOpp()
        {
            var t = new Table();
            t.Add(new Record(1, 2, 3));
            t.Add(new Record("a", "b", 4));
            
            var reader = new TestReader(new Tuple<int, char>(1, 'A'), "xyz");
            var op = new UpdateOperation(t, reader);
            op.Execute();
            Assert.AreEqual("xyz", t[1, 'A'].Str);
            
            reader = new TestReader(new Tuple<int, char>(2, 'B'), 100);
            op = new UpdateOperation(t, reader);
            op.Execute();
            Assert.AreEqual(100, t[2, 'B'].Num);
        }
    }
}
