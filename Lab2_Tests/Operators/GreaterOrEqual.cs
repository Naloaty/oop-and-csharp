using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Operators
{
    [TestClass]
    public class GreaterOrEqual
    {
        [TestMethod]
        public void GreaterOrEqual_BobToNull_ReturnsFalse()
        {
            MyString bob = new MyString("Bob");
            Assert.IsFalse(bob >= null);
        }

        [TestMethod]
        public void GreaterOrEqual_AliceToBob_ReturnsTrue()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsTrue(alice >= bob);
        }

        [TestMethod]
        public void GreaterOrEqual_BobToBob_ReturnsTrue()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("Bob");
            Assert.IsTrue(bob1 >= bob2);
        }

        [TestMethod]
        public void GreaterOrEqual_bobToCob_ReturnsTrue()
        {
            MyString bob = new MyString("bob");
            MyString cob = new MyString("Cob");
            Assert.IsTrue(bob >= cob);
        }

        [TestMethod]
        public void GreaterOrEqual_BobToAlice_ReturnsFalse()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsFalse(bob >= alice);
        }
    }
}
