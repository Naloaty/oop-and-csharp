using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Methods
{
    [TestClass]
    public class CompareTo
    {
        [TestMethod]
        public void CompareTo_AliceToNull_ReturnsPositive()
        {
            MyString str = new MyString("Alice");
            Assert.IsTrue(str.CompareTo(null) > 0);
        }

        [TestMethod]
        public void CompareTo_AliceToBob_ReturnsNegative()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsTrue(alice.CompareTo(bob) < 0);
        }

        [TestMethod]
        public void CompareTo_BobToAlice_ReturnsPositive()
        {
            MyString alice = new MyString("Alice");
            MyString bob = new MyString("Bob");
            Assert.IsTrue(bob.CompareTo(alice) > 0);
        }

        [TestMethod]
        public void CompareTo_BobToBob_ReturnsZero()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("Bob");
            Assert.AreEqual(0, bob1.CompareTo(bob2));
        }

        [TestMethod]
        public void CompareTo_BobToLeo_ReturnsNegative()
        {
            MyString bob = new MyString("Bob");
            MyString leo = new MyString("Leo");
            Assert.IsTrue(bob.CompareTo(leo) < 0);
        }

        [TestMethod]
        public void CompareTo_LeoToBob_ReturnsPositive()
        {
            MyString bob = new MyString("Bob");
            MyString leo = new MyString("Leo");
            Assert.IsTrue(leo.CompareTo(bob) > 0);
        }

        [TestMethod]
        public void CompareTo_LeonardoToLeo_ReturnsPositive()
        {
            MyString leonardo = new MyString("Leonardo");
            MyString leo = new MyString("Leo");
            Assert.IsTrue(leonardo.CompareTo(leo) > 0);
        }

        [TestMethod]
        public void CompareTo_LeoToLeonardo_ReturnsNegative()
        {
            MyString leonardo = new MyString("Leonardo");
            MyString leo = new MyString("Leo");
            Assert.IsTrue(leo.CompareTo(leonardo) < 0);
        }

        [TestMethod]
        public void CompareTo_BobTobob_ReturnsNegative()
        {
            MyString bob1 = new MyString("Bob");
            MyString bob2 = new MyString("bob");
            Assert.IsTrue(bob1.CompareTo(bob2) < 0);
        }
    }
}
