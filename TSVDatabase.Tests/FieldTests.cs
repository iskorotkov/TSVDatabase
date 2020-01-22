using NUnit.Framework;

namespace TSVDatabase.Tests
{
    public class FieldTests
    {
        [Test]
        public void NumField()
        {
            var field = new Field(5);

            Assert.AreEqual(FieldType.Num, field.Type);
            Assert.AreEqual(5, field.Num);
            var e = Assert.Catch<FieldTypeException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var s = field.Str;
            });

            Assert.AreEqual(FieldType.Str, e.Expected);
            Assert.AreEqual(FieldType.Num, e.Actual);
        }

        [Test]
        public void StrField()
        {
            var field = new Field("abc");

            Assert.IsTrue(field.Type == FieldType.Str);
            Assert.AreEqual("abc", field.Str);
            var e = Assert.Catch<FieldTypeException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var n = field.Num;
            });

            Assert.AreEqual(FieldType.Num, e.Expected);
            Assert.AreEqual(FieldType.Str, e.Actual);
        }

        [Test]
        public void Change()
        {
            var f = new Field(5);

            Assert.AreEqual(FieldType.Num, f.Type);
            Assert.AreEqual(5, f.Num);
            Assert.Throws<FieldTypeException>(() =>
            {
                var s = f.Str;
            });

            f.Num = 1;
            Assert.AreEqual(FieldType.Num, f.Type);
            Assert.AreEqual(1, f.Num);
            Assert.Throws<FieldTypeException>(() =>
            {
                var s = f.Str;
            });

            f.Str = "aaaa";
            Assert.AreEqual(FieldType.Str, f.Type);
            Assert.AreEqual("aaaa", f.Str);
            Assert.Throws<FieldTypeException>(() =>
            {
                var n = f.Num;
            });

            f.Num = -100;
            Assert.AreEqual(FieldType.Num, f.Type);
            Assert.AreEqual(-100, f.Num);
            Assert.Throws<FieldTypeException>(() =>
            {
                var s = f.Str;
            });
        }

        [Test]
        public void ToStr()
        {
            var f = new Field(1);
            Assert.AreEqual("1", f.ToString());

            f = new Field("abc");
            Assert.AreEqual("abc", f.ToString());
        }

        [Test]
        public void Equality()
        {
            Assert.AreEqual(new Field(3), new Field(3));
            Assert.AreEqual(new Field("ac"),new Field("ac"));
            
            Assert.AreNotEqual(new Field(1),new Field(2));
            Assert.AreNotEqual(new Field("abc"),new Field("ab"));
            Assert.AreNotEqual(new Field(1),new Field("a"));
        }
    }
}
