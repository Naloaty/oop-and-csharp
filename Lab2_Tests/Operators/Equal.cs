using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Operators
{
    [TestClass]
    public class Equal
    {
        [TestMethod]
        public void Equal_BobToNull_ThrowsArgumentNullException()
        {
            MyString bob = new MyString("Bob");
            Assert.ThrowsException<System.ArgumentNullException>(() => bob == null);
        }

        [TestMethod]
        public void Equal_AliceToBob_ReturnsFalse()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsFalse(alice == bob);
        }

        [TestMethod]
        public void Equal_BobToBob_ReturnsTrue()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("Bob");
            Assert.IsTrue(bob1 == bob2);
        }

        [TestMethod]
        public void Equal_BobTobob_ReturnsFalse()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("bob");
            Assert.IsFalse(bob1 == bob2);
        }
    }
}
