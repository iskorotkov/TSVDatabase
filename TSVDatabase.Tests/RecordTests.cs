using System.Collections.Generic;
using NUnit.Framework;

namespace TSVDatabase.Tests
{
    public class RecordTests
    {
        [Test]
        public void NumRecord()
        {
            var record = new Record(1, 2, 3, 4, 5, 6, 7);
            Assert.AreEqual(1, record['A'].Num);
            Assert.AreEqual(2, record['B'].Num);
            Assert.AreEqual(3, record['C'].Num);
            Assert.AreEqual(4, record['D'].Num);
            Assert.AreEqual(5, record['E'].Num);
            Assert.AreEqual(6, record['F'].Num);
            Assert.AreEqual(7, record['G'].Num);

            record['A'].Num = 10;
            record['B'].Num = 11;
            record['C'].Num = 12;
            record['D'].Num = 13;
            record['E'].Num = 100;
            record['F'].Num = 200;
            record['G'].Num = -1;

            Assert.AreEqual(10, record['A'].Num);
            Assert.AreEqual(11, record['B'].Num);
            Assert.AreEqual(12, record['C'].Num);
            Assert.AreEqual(13, record['D'].Num);
            Assert.AreEqual(100, record['E'].Num);
            Assert.AreEqual(200, record['F'].Num);
            Assert.AreEqual(-1, record['G'].Num);
        }

        [Test]
        public void RecordOverflow()
        {
            var record = new Record(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23,
                24, 25, 26);

            Assert.Throws<RecordOverflowException>(() =>
            {
                var record2 = new Record(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22,
                    23, 24, 25, 26, 27);
            });
        }

        [Test]
        public void ListRecordOverflow()
        {
            var list = new List<dynamic>();
            for (var i = 0; i < 26; i++)
            {
                list.Add(i);
            }

            var record = new Record(list);

            list.Add(26);
            Assert.Throws<RecordOverflowException>(() =>
            {
                var record2 = new Record(list);
            });

            var record3 = new Record(new List<string> {"a", "ab", "abc"});
            var record4 = new Record(new List<int> {5, 6, 7, 8});
        }

        [Test]
        public void UnsupportedRecordType()
        {
            Assert.Throws<UnsupportedRecordTypeException>(() =>
            {
                var record = new Record('c');
            });
        }

        [Test]
        public void ToStr()
        {
            var r = new Record(1, 2, 3, 4);
            Assert.AreEqual("1\t2\t3\t4", r.ToString());

            r = new Record("a", "bc", "d");
            Assert.AreEqual("a\tbc\td", r.ToString());

            r = new Record(1, "abc", 2, 3, "xyz");
            Assert.AreEqual("1\tabc\t2\t3\txyz", r.ToString());
        }

        [Test]
        public void Equality()
        {
            Assert.AreEqual(new Record(1, 2, 3), new Record(1, 2, 3));
            Assert.AreEqual(new Record(1, "a"), new Record(1, "a"));
            Assert.AreNotEqual(new Record(1, 2, "a"), new Record(1, "a", 2));
        }
    }
}
