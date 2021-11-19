using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Methods
{
    [TestClass]
    public class Constructor
    {
        [TestMethod]
        public void Constructor_WithoutArguments_LengthShouldBeZero()
        {
            MyString str = new MyString();
            Assert.AreEqual(0, str.Length);
        }

        [TestMethod]
        public void Constructor_NullValue_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() => new MyString(null));
        }

        [TestMethod]
        public void Constructor_EmptyValue_LengthShouldBeZero()
        {
            MyString str = new MyString("");
            Assert.AreEqual(0, str.Length);
        }

        [TestMethod]
        public void Constructor_AliceValue_LengthShouldBeFive()
        {
            MyString str = new MyString("Alice");
            Assert.AreEqual(5, str.Length);
        }

    }
}
