using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab_3;

namespace Buildings
{
    [TestClass]
    public class NonLiving
    {
        [TestMethod]
        public void Constructor_Deafult_ShouldNotThrowException()
        {
            NonLivingBuilding obj = new NonLivingBuilding();
        }

        [TestMethod]
        public void Constructor_AcceptableArgs()
        {
            NonLivingBuilding obj = new NonLivingBuilding("Bestcode st", 13.3);

            Assert.AreEqual("Bestcode st", obj.Address);
            Assert.AreEqual(13.3, obj.Square);
        }

        [TestMethod]
        public void Constructor_NullAddress_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new NonLivingBuilding(null, 13.3));
        }

        [TestMethod]
        public void Constructor_EmptyAddress_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new NonLivingBuilding("", 13.3));
        }

        [TestMethod]
        public void Constructor_NegativeSqaure_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new NonLivingBuilding("Bestcode st", -13.3));
        }

        [TestMethod]
        public void Property_AcceptableAddress()
        {
            NonLivingBuilding obj = new NonLivingBuilding();
            obj.Address = "Bestcode st";

            Assert.AreEqual("Bestcode st", obj.Address);
        }

        [TestMethod]
        public void Property_AcceptableSquare()
        {
            NonLivingBuilding obj = new NonLivingBuilding();
            obj.Square = 13.3;

            Assert.AreEqual(13.3, obj.Square);
        }

        [TestMethod]
        public void Property_NullAddress_ThrowsArgumentException()
        {
            NonLivingBuilding obj = new NonLivingBuilding();
            Assert.ThrowsException<ArgumentException>(() => obj.Address = null);
        }

        [TestMethod]
        public void Property_EmptyAddress_ThrowsArgumentException()
        {
            NonLivingBuilding obj = new NonLivingBuilding();
            Assert.ThrowsException<ArgumentException>(() => obj.Address = "");
        }

        [TestMethod]
        public void Property_NegativeSqaure_ThrowsArgumentException()
        {
            NonLivingBuilding obj = new NonLivingBuilding();
            Assert.ThrowsException<ArgumentException>(() => obj.Square = -13.3);
        }

        [TestMethod]
        public void Method_NumberOfPeople_Test1()
        {
            NonLivingBuilding obj = new NonLivingBuilding("Bestcode st", 13.3);
            Assert.AreEqual(Convert.ToInt32(13.3 * 0.2), obj.NumberOfPeople);
        }

        [TestMethod]
        public void Method_NumberOfPeople_Test2()
        {
            NonLivingBuilding obj = new NonLivingBuilding("Bestcode st", 0);
            Assert.AreEqual(Convert.ToInt32(0 * 0.2), obj.NumberOfPeople);
        }

        [TestMethod]
        public void Method_NumberOfPeople_Test3()
        {
            NonLivingBuilding obj = new NonLivingBuilding("Bestcode st", 150);
            Assert.AreEqual(Convert.ToInt32(150 * 0.2), obj.NumberOfPeople);
        }

        [TestMethod]
        public void Method_NumberOfPeople_Test4()
        {
            NonLivingBuilding obj = new NonLivingBuilding("Bestcode st", 1);
            Assert.AreEqual(Convert.ToInt32(1 * 0.2), obj.NumberOfPeople);
        }

        [TestMethod]
        public void Method_NumberOfPeople_Test5()
        {
            NonLivingBuilding obj = new NonLivingBuilding("Bestcode st", 10);
            Assert.AreEqual(Convert.ToInt32(10 * 0.2), obj.NumberOfPeople);
        }
    }
}
