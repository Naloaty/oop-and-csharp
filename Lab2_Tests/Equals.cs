using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Methods
{
    [TestClass]
    public class Equals
    {
        [TestMethod]
        public void Equals_AliceToBob_ReturnsFalse()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsFalse(alice.Equals(bob));
        }

        [TestMethod]
        public void Equals_BobToBob_ReturnsTrue()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("Bob");
            Assert.IsTrue(bob1.Equals(bob2));
        }

        [TestMethod]
        public void Equals_BobTobob_ReturnsFalse()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("bob");
            Assert.IsFalse(bob1.Equals(bob2));
        }

        [TestMethod]
        public void Equals_LeoToBob_ReturnsFalse()
        {
            MyString leo = new MyString("Leo");
            MyString bob = new MyString("Bob");
            Assert.IsFalse(leo.Equals(bob));
        }

        [TestMethod]
        public void Equals_LeoToLeonardo_ReturnsFalse()
        {
            MyString leo = new MyString("Leo");
            MyString leonardo = new MyString("Leonardo");
            Assert.IsFalse(leo.Equals(leonardo));
        }
    }
}
