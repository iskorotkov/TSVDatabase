using NUnit.Framework;

namespace TSVDatabase.Tests
{
    public class TableTests
    {
        [Test]
        public void Records()
        {
            var data = new Table();
            var r = new Record(1, 2, 3);
            data.Add(r);
            Assert.AreEqual(1, data.Count);
            Assert.AreEqual(r, data[1]);

            var r2 = new Record("a", "b", "c");
            data.Add(r2);
            Assert.AreEqual(2, data.Count);
            Assert.AreEqual(r, data[1]);
            Assert.AreEqual(r2, data[2]);

            var r3 = new Record(90, 89, 88);
            data[1] = r3;
            Assert.AreEqual(2, data.Count);
            Assert.AreEqual(r3, data[1]);
            Assert.AreEqual(r2, data[2]);

            data.Add(null);
            Assert.AreEqual(3, data.Count);
            Assert.AreEqual(r3, data[1]);
            Assert.AreEqual(r2, data[2]);
            Assert.AreEqual(null, data[3]);
        }

        [Test]
        public void MatrixStyleIndexing()
        {
            var data = new Table();
            data.Add(new Record(1, 2, 3));
            Assert.AreEqual(1, data.Count);
            Assert.AreEqual(1, data[1, 'A'].Num);
            Assert.AreEqual(2, data[1, 'B'].Num);
            Assert.AreEqual(3, data[1, 'C'].Num);
        }

        [Test]
        public void ToStr()
        {
            var t = new Table();
            t.Add(new Record(1, 2, 3));
            t.Add(new Record("abc", 100, "xyz"));
            Assert.AreEqual("1\t2\t3\nabc\t100\txyz", t.ToString());
        }

        [Test]
        public void Insertion()
        {
            var t = new Table();
            t.InsertAfter(null, new Record(1, 2, 3));
            Assert.AreEqual(1, t.Count);
            Assert.AreEqual(new Record(1, 2, 3), t[1]);

            t.InsertAfter(null, new Record(4, 2, 3));
            Assert.AreEqual(2, t.Count);
            Assert.AreEqual(new Record(1, 2, 3), t[1]);
            Assert.AreEqual(new Record(4, 2, 3), t[2]);

            t.InsertAfter(1, new Record(1, 3, 3));
            Assert.AreEqual(3, t.Count);
            Assert.AreEqual(new Record(1, 2, 3), t[1]);
            Assert.AreEqual(new Record(1, 3, 3), t[2]);
            Assert.AreEqual(new Record(4, 2, 3), t[3]);
        }

        [Test]
        public void Equality()
        {
            var t1 = new Table();
            var t2 = new Table();
            Assert.AreEqual(t1, t2);

            t1.Add(new Record(1, 2, 3));
            t2.Add(new Record(1, 2, 3));
            Assert.AreEqual(t1, t2);
        }

        [Test]
        public void RemovingElements()
        {
            var t = new Table();
            t.Add(new Record(1, 2, 3));
            t.Add(new Record(4, 5, 6));
            t.Add(new Record("a", "b", 1000));

            t.Remove(1);
            Assert.AreEqual(2, t.Count);
            Assert.AreEqual(new Record(4, 5, 6), t[1]);
            Assert.AreEqual(new Record("a", "b", 1000), t[2]);
            
            t.Remove(2);
            Assert.AreEqual(1, t.Count);
            Assert.AreEqual(new Record(4, 5, 6), t[1]);
            
            t.Remove(1);
            Assert.AreEqual(0, t.Count);
        }
    }
}
