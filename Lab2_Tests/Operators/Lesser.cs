using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Operators
{
    [TestClass]
    public class Lesser
    {
        [TestMethod]
        public void Lesser_BobToNull_ReturnsTrue()
        {
            MyString bob = new MyString("Bob");
            Assert.IsTrue(bob < null);
        }

        [TestMethod]
        public void Lesser_AliceToBob_ReturnsFalse()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsFalse(alice < bob);
        }

        [TestMethod]
        public void Lesser_BobToBob_ReturnsFalse()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("Bob");
            Assert.IsFalse(bob1 < bob2);
        }

        [TestMethod]
        public void Lesser_bobToCob_ReturnsFalse()
        {
            MyString bob = new MyString("bob");
            MyString cob = new MyString("Cob");
            Assert.IsFalse(bob < cob);
        }

        [TestMethod]
        public void Lesser_BobToAlice_ReturnsTrue()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsTrue(bob < alice);
        }
    }
}
