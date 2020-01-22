using NUnit.Framework;

namespace TSVDatabase.Tests
{
    public class ParserTests
    {
        [Test]
        public void OneRecord()
        {
            var p = new Parser();
            var s = "2\t3\t4\t5\t6\t7\t8";
            var d = p.ParseText(s);
            var r = d[1];
            Assert.AreEqual(1, d.Count);
            Assert.AreEqual(2, r['A'].Num);
            Assert.AreEqual(3, r['B'].Num);
            Assert.AreEqual(4, r['C'].Num);
            Assert.AreEqual(5, r['D'].Num);
            Assert.AreEqual(6, r['E'].Num);
            Assert.AreEqual(7, r['F'].Num);
            Assert.AreEqual(8, r['G'].Num);

            r = p.ParseLine(s);
            Assert.AreEqual(1, d.Count);
            Assert.AreEqual(2, r['A'].Num);
            Assert.AreEqual(3, r['B'].Num);
            Assert.AreEqual(4, r['C'].Num);
            Assert.AreEqual(5, r['D'].Num);
            Assert.AreEqual(6, r['E'].Num);
            Assert.AreEqual(7, r['F'].Num);
            Assert.AreEqual(8, r['G'].Num);
        }

        [Test]
        public void OneMixedRecord()
        {
            var p = new Parser();
            var s = "2\tab\t4\tcd\t6\t7\txyz";
            var d = p.ParseText(s);
            var r = d[1];
            Assert.AreEqual(1, d.Count);
            Assert.AreEqual(2, r['A'].Num);
            Assert.AreEqual("ab", r['B'].Str);
            Assert.AreEqual(4, r['C'].Num);
            Assert.AreEqual("cd", r['D'].Str);
            Assert.AreEqual(6, r['E'].Num);
            Assert.AreEqual(7, r['F'].Num);
            Assert.AreEqual("xyz", r['G'].Str);

            r = p.ParseLine(s);
            Assert.AreEqual(1, d.Count);
            Assert.AreEqual(2, r['A'].Num);
            Assert.AreEqual("ab", r['B'].Str);
            Assert.AreEqual(4, r['C'].Num);
            Assert.AreEqual("cd", r['D'].Str);
            Assert.AreEqual(6, r['E'].Num);
            Assert.AreEqual(7, r['F'].Num);
            Assert.AreEqual("xyz", r['G'].Str);
        }

        [Test]
        public void Text()
        {
            var p = new Parser();
            var s = "1\t2\t3\t4\t5\t6\t7" + "\n" + "a\tab\tabc\tabcd\tabcde\tabcdef\tabcdefg";
            var d = p.ParseText(s);
            Assert.AreEqual(2, d.Count);
            Assert.AreEqual(5, d[1]['E'].Num);
            Assert.AreEqual("abcd", d[2]['D'].Str);
        }

        [Test]
        public void EmptyLines()
        {
            var p = new Parser();
            var s = "\n\n  \n\n1\t2\t3\n      \n\n";
            var d = p.ParseText(s);
            Assert.AreEqual(1, d.Count);
            Assert.AreEqual(2, d[1]['B'].Num);
            Assert.AreEqual(3, d[1]['C'].Num);
        }
    }
}
