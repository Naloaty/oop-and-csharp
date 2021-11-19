using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Operators
{
    [TestClass]
    public class Addition
    {
        [TestMethod]
        public void Addition_AppendBToEmptyString()
        {
            MyString str = new MyString() + 'B';
            Assert.AreEqual('B', str.Get(0));
        }

        [TestMethod]
        public void Addition_AppendBToAlice()
        {
            MyString str = new MyString("Alice") + 'B';
            Assert.AreEqual('A', str.Get(0));
            Assert.AreEqual('l', str.Get(1));
            Assert.AreEqual('i', str.Get(2));
            Assert.AreEqual('c', str.Get(3));
            Assert.AreEqual('e', str.Get(4));
            Assert.AreEqual('B', str.Get(5));
            Assert.AreEqual(6, str.Length);
        }

        [TestMethod]
        public void Addition_AppendBobToAlice()
        {
            MyString str = new MyString("Alice") + 'B' + 'o' + 'b';
            Assert.AreEqual('A', str.Get(0));
            Assert.AreEqual('l', str.Get(1));
            Assert.AreEqual('i', str.Get(2));
            Assert.AreEqual('c', str.Get(3));
            Assert.AreEqual('e', str.Get(4));
            Assert.AreEqual('B', str.Get(5));
            Assert.AreEqual('o', str.Get(6));
            Assert.AreEqual('b', str.Get(7));
            Assert.AreEqual(8, str.Length);
        }

        [TestMethod]
        public void Addition_Dynamic_AppendBToAlice()
        {
            MyString str = new MyString("Alice", true) + 'B';
            Assert.AreEqual('A', str.Get(0));
            Assert.AreEqual('l', str.Get(1));
            Assert.AreEqual('i', str.Get(2));
            Assert.AreEqual('c', str.Get(3));
            Assert.AreEqual('e', str.Get(4));
            Assert.AreEqual('B', str.Get(5));
            Assert.AreEqual(6, str.Length);
        }

        [TestMethod]
        public void Addition_Dynamic_AppendBobToAlice()
        {
            MyString str = new MyString("Alice", true) + 'B' + 'o' + 'b';
            Assert.AreEqual('A', str.Get(0));
            Assert.AreEqual('l', str.Get(1));
            Assert.AreEqual('i', str.Get(2));
            Assert.AreEqual('c', str.Get(3));
            Assert.AreEqual('e', str.Get(4));
            Assert.AreEqual('B', str.Get(5));
            Assert.AreEqual('o', str.Get(6));
            Assert.AreEqual('b', str.Get(7));
            Assert.AreEqual(8, str.Length);
        }

        [TestMethod]
        public void Addition_AppendBToAlice_ShouldReturnReference()
        {
            MyString str = new MyString("Alice");
            MyString appended = str + 'B';
            Assert.IsTrue(object.ReferenceEquals(str, appended));
        }
    }
}
