using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Operators
{
    [TestClass]
    public class Greater
    {
        [TestMethod]
        public void Greater_BobToNull_ReturnsFalse()
        {
            MyString bob = new MyString("Bob");
            Assert.IsFalse(bob > null);
        }

        [TestMethod]
        public void Greater_AliceToBob_ReturnsTrue()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsTrue(alice > bob);
        }

        [TestMethod]
        public void Greater_BobToBob_ReturnsFalse()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("Bob");
            Assert.IsFalse(bob1 > bob2);
        }

        [TestMethod]
        public void Greater_bobToCob_ReturnsTrue()
        {
            MyString bob = new MyString("bob");
            MyString cob = new MyString("Cob");
            Assert.IsTrue(bob > cob);
        }

        [TestMethod]
        public void Greater_BobToAlice_ReturnsFalse()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsFalse(bob > alice);
        }
    }
}
