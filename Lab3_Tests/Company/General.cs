using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab_3;

namespace Company
{
    [TestClass]
    public class General
    {
        [TestMethod]
        public void Constructor_Deafult_ShouldNotThrowException()
        {
            ManagementCompany obj = new ManagementCompany();
        }

        [TestMethod]
        public void Add_MultiTest_LivingBuilding()
        {
            ManagementCompany obj = new ManagementCompany();

            int numberOfPeople = 0;

            for (int i = 0; i < 10; i++)
            {
                // ManagementCompany must work with LivingBuilding type
                obj.Add(new LivingBuilding($"{i + 1} Bestcode st", 10 + i, 3 + i));

                numberOfPeople += Convert.ToInt32((10 + i) * (3 + i) * 1.3);

                // Counter must be updated in realtime
                Assert.AreEqual(numberOfPeople, obj.NumberOfPeople);
            }

            // Counter must be updated in realtime
            Assert.AreEqual(numberOfPeople, obj.NumberOfPeople);
        }

        [TestMethod]
        public void Add_MultiTest_NonLivingBuilding()
        {
            ManagementCompany obj = new ManagementCompany();

            int numberOfPeople = 0;

            for (int i = 0; i < 10; i++)
            {
                // ManagementCompany must work with NonLivingBuilding type
                obj.Add(new NonLivingBuilding($"{i + 1} Bestcode st", 10 + (i * 1.35)));

                numberOfPeople += Convert.ToInt32((10 + (i * 1.35)) * 0.2);

                // Counter must be updated in realtime
                Assert.AreEqual(numberOfPeople, obj.NumberOfPeople);
            }

            // Counter must be updated in realtime
            Assert.AreEqual(numberOfPeople, obj.NumberOfPeople);
        }

        [TestMethod]
        public void Add_MultiTest_MultiType()
        {
            ManagementCompany obj = new ManagementCompany();

            int numberOfPeople = 0;

            for (int i = 0; i < 10; i++)
            {
                // ManagementCompany must work with both LivingBuilding and NonLivingBuilding types
                obj.Add(new LivingBuilding($"{i + 1}-1 Bestcode st", 10 + i, 3 + i));
                obj.Add(new NonLivingBuilding($"{i + 1}-2 Bestcode st", 10 + (i * 1.35)));

                numberOfPeople += Convert.ToInt32((10 + i) * (3 + i) * 1.3);
                numberOfPeople += Convert.ToInt32((10 + (i * 1.35)) * 0.2);

                // Counter must be updated in realtime
                Assert.AreEqual(numberOfPeople, obj.NumberOfPeople);
            }

            // Counter must be updated in realtime
            Assert.AreEqual(numberOfPeople, obj.NumberOfPeople);
        }

        [TestMethod]
        public void GetBuildings_ShouldReturnCorrectIterator()
        {
            ManagementCompany obj = new ManagementCompany();

            for (int i = 0; i < 10; i++)
            {
                obj.Add(new LivingBuilding($"{i + 1}-1 Bestcode st", 10 + i, 3 + i));
                obj.Add(new NonLivingBuilding($"{i + 1}-2 Bestcode st", 10 + (i * 1.35)));
            }

            IEnumerable<Building> buildings = obj.GetBuildings();
            Assert.AreEqual(20, buildings.Count());
        }
    }
}
