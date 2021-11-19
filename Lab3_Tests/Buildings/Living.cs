using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab_3;

namespace Buildings
{
    [TestClass]
    public class Living
    {
        [TestMethod]
        public void Constructor_Deafult_ShouldNotThrowException()
        {
            LivingBuilding obj = new LivingBuilding();
        }

        [TestMethod]
        public void Constructor_AcceptableArgs_ShouldNotThrowException()
        {
            LivingBuilding obj = new LivingBuilding("Bestcode st", 10, 3);

            Assert.AreEqual("Bestcode st", obj.Address);
            Assert.AreEqual(10, obj.Apartments);
            Assert.AreEqual(3, obj.Rooms);
        }

        [TestMethod]
        public void Constructor_NullAddress_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new LivingBuilding(null, 10, 3));
        }

        [TestMethod]
        public void Constructor_EmptyAddress_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new LivingBuilding("", 10, 3));
        }

        [TestMethod]
        public void Constructor_NegativeApartments_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new LivingBuilding("Bestcode st", -10, 3));
        }

        [TestMethod]
        public void Constructor_NegativeRooms_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new LivingBuilding("Bestcode st", 10, -3));
        }

        [TestMethod]
        public void Property_AcceptableAddress()
        {
            LivingBuilding obj = new LivingBuilding();
            obj.Address = "Bestcode st";

            Assert.AreEqual("Bestcode st", obj.Address);
        }

        [TestMethod]
        public void Property_AcceptableApartments()
        {
            LivingBuilding obj = new LivingBuilding();
            obj.Apartments = 10;

            Assert.AreEqual(10, obj.Apartments);
        }

        [TestMethod]
        public void Property_AcceptableRooms()
        {
            LivingBuilding obj = new LivingBuilding();
            obj.Rooms = 3;

            Assert.AreEqual(3, obj.Rooms);
        }

        [TestMethod]
        public void Property_NullAddress_ThrowsArgumentException()
        {
            LivingBuilding obj = new LivingBuilding();
            Assert.ThrowsException<ArgumentException>(() => obj.Address = null);
        }

        [TestMethod]
        public void Property_EmptyAddress_ThrowsArgumentException()
        {
            LivingBuilding obj = new LivingBuilding();
            Assert.ThrowsException<ArgumentException>(() => obj.Address = "");
        }

        [TestMethod]
        public void Property_NegativeApartments_ThrowsArgumentException()
        {
            LivingBuilding obj = new LivingBuilding();
            Assert.ThrowsException<ArgumentException>(() => obj.Apartments = -10);
        }

        [TestMethod]
        public void Property_NegativeRooms_ThrowsArgumentException()
        {
            LivingBuilding obj = new LivingBuilding();
            Assert.ThrowsException<ArgumentException>(() => obj.Rooms = -3);
        }

        [TestMethod]
        public void Method_NumberOfPeople_Test1()
        {
            LivingBuilding obj = new LivingBuilding("Bestcode st", 10, 3);
            Assert.AreEqual(Convert.ToInt32(10 * 3 * 1.3), obj.NumberOfPeople);
        }

        [TestMethod]
        public void Method_NumberOfPeople_Test2()
        {
            LivingBuilding obj = new LivingBuilding("Bestcode st", 15, 5);
            Assert.AreEqual(Convert.ToInt32(15 * 5 * 1.3), obj.NumberOfPeople);
        }

        [TestMethod]
        public void Method_NumberOfPeople_Test3()
        {
            LivingBuilding obj = new LivingBuilding("Bestcode st", 0, 0);
            Assert.AreEqual(Convert.ToInt32(0 * 0 * 1.3), obj.NumberOfPeople);
        }

        [TestMethod]
        public void Method_NumberOfPeople_Test4()
        {
            LivingBuilding obj = new LivingBuilding("Bestcode st", 1, 1);
            Assert.AreEqual(Convert.ToInt32(1 * 1 * 1.3), obj.NumberOfPeople);
        }

        [TestMethod]
        public void Method_NumberOfPeople_Test5()
        {
            LivingBuilding obj = new LivingBuilding("Bestcode st", 150, 3);
            Assert.AreEqual(Convert.ToInt32(150 * 3 * 1.3), obj.NumberOfPeople);
        }
    }
}
