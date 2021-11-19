using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Operators
{
    [TestClass]
    public class NotEqual
    {

        [TestMethod]
        public void NotEqual_BobToNull_ThrowsArgumentNullException()
        {
            MyString bob = new MyString("Bob");
            Assert.ThrowsException<System.ArgumentNullException>(() => bob != null);
        }

        public void NotEqual_AliceToBob_ReturnsTrue()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsTrue(alice != bob);
        }

        [TestMethod]
        public void NotEqual_BobToBob_ReturnsFalse()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("Bob");
            Assert.IsFalse(bob1 != bob2);
        }

        [TestMethod]
        public void NotEqual_BobTobob_ReturnsTrue()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("bob");
            Assert.IsTrue(bob1 != bob2);
        }
    }
}
