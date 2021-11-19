using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Operators
{
    [TestClass]
    public class LesserOrEqual
    {
        [TestMethod]
        public void LesserOrEqual_BobToNull_ReturnsTrue()
        {
            MyString bob = new MyString("Bob");
            Assert.IsTrue(bob <= null);
        }

        [TestMethod]
        public void LesserOrEqual_AliceToBob_ReturnsFalse()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsFalse(alice <= bob);
        }

        [TestMethod]
        public void LesserOrEqual_BobToBob_ReturnsTrue()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("Bob");
            Assert.IsTrue(bob1 <= bob2);
        }

        [TestMethod]
        public void LesserOrEqual_bobToCob_ReturnsFalse()
        {
            MyString bob = new MyString("bob");
            MyString cob = new MyString("Cob");
            Assert.IsFalse(bob <= cob);
        }

        [TestMethod]
        public void LesserOrEqual_BobToAlice_ReturnsTrue()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsTrue(bob <= alice);
        }

    }
}
