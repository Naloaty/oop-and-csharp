using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Methods
{
    [TestClass]
    public class Get
    {
        [TestMethod]
        public void Get_AliceValue_ReturnsThirdChar()
        {
            MyString str = new MyString("Alice");
            Assert.AreEqual('i', str.Get(2));
        }

        [TestMethod]
        public void Get_AliceValue_ReturnsFirstChar()
        {
            MyString str = new MyString("Alice");
            Assert.AreEqual('A', str.Get(0));
        }

        [TestMethod]
        public void Get_AliceValue_ReturnsLastChar()
        {
            MyString str = new MyString("Alice");
            Assert.AreEqual('e', str.Get(4));
        }

        [TestMethod]
        public void Get_IndexBelowZero_ShouldThrowIndexOutOfRangeException()
        {
            MyString str = new MyString("Alice");
            Assert.ThrowsException<System.IndexOutOfRangeException>(() => str.Get(-1));
        }

        [TestMethod]
        public void Get_IndexBeyondBoundry_ShouldThrowIndexOutOfRangeException()
        {
            MyString str = new MyString("Alice");
            Assert.ThrowsException<System.IndexOutOfRangeException>(() => str.Get(5));
        }
    }
}
