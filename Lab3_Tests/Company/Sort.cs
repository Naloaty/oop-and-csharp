using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Lab_3;

namespace Company
{
    [TestClass]
    public class Sort
    {
        [TestMethod]
        public void Sort_EmptyList_ShouldNotThrowException()
        {
            ManagementCompany obj = new ManagementCompany();
            obj.Sort();
        }

        [TestMethod]
        public void Sort_DefaultOrder()
        {
            ManagementCompany obj = new ManagementCompany();

            /*
             *  Type:              Address:        Number of people:
             *  =====================================================
             *  LivingBuilding,    1 Bestcode st,  39
             *  NonLivingBuilding, 2 Bestcode st,  2
             *  LivingBuilding,    3 Bestcode st,  78
             *  NonLivingBuilding, 4 Bestcode st,  3
             *  LivingBuilding,    5 Bestcode st,  127
             *  NonLivingBuilding, 6 Bestcode st,  3
             *  LivingBuilding,    7 Bestcode st,  187
             *  NonLivingBuilding, 8 Bestcode st,  4
             *  LivingBuilding,    9 Bestcode st,  257
             *  NonLivingBuilding, 10 Bestcode st, 4
             */

            for (int i = 0; i < 10; i += 2)
            {
                obj.Add(new LivingBuilding($"{i + 1} Bestcode st", 10 + i, 3 + i));
                obj.Add(new NonLivingBuilding($"{i + 2} Bestcode st", 10 + (i * 1.35)));
            }

            // The buildings should appear in the order in which they were added

            int j = 0;
            foreach (var building in obj.GetBuildings())
            {
                Assert.AreEqual($"{j + 1} Bestcode st", building.Address);
                j++;
            }
        }

        [TestMethod]
        public void Sort_NumberOfPeople_Type_Address()
        {
            ManagementCompany obj = new ManagementCompany();

            /*
             *  Type:              Address:          Number of people:
             *  ================   ===============   ================
             *  LivingBuilding,    1-D Bestcode st,  0
             *  LivingBuilding,    1-C Bestcode st,  0
             *  NonLivingBuilding, 1-B Bestcode st,  0
             *  NonLivingBuilding, 1-A Bestcode st,  0
             *  LivingBuilding,    2-D Bestcode st,  6
             *  LivingBuilding,    2-C Bestcode st,  6
             *  NonLivingBuilding, 2-B Bestcode st,  6
             *  NonLivingBuilding, 2-A Bestcode st,  6
             *  LivingBuilding,    3-D Bestcode st,  26
             *  LivingBuilding,    3-C Bestcode st,  26
             *  NonLivingBuilding, 3-B Bestcode st,  26
             *  NonLivingBuilding, 3-A Bestcode st,  26
             */

            obj.Add(new LivingBuilding("1-D Bestcode st", 0, 0));
            obj.Add(new LivingBuilding("1-C Bestcode st", 0, 0));
            obj.Add(new NonLivingBuilding("1-B Bestcode st", 0));
            obj.Add(new NonLivingBuilding("1-A Bestcode st", 0));

            obj.Add(new LivingBuilding("2-D Bestcode st", 1, 1 * 5));
            obj.Add(new LivingBuilding("2-C Bestcode st", 1, 1 * 5));
            obj.Add(new NonLivingBuilding("2-B Bestcode st", 1 * 5 * 6.5));
            obj.Add(new NonLivingBuilding("2-A Bestcode st", 1 * 5 * 6.5));

            obj.Add(new LivingBuilding("3-D Bestcode st", 2, 2 * 5));
            obj.Add(new LivingBuilding("3-C Bestcode st", 2, 2 * 5));
            obj.Add(new NonLivingBuilding("3-B Bestcode st", 4 * 5 * 6.5));
            obj.Add(new NonLivingBuilding("3-A Bestcode st", 4 * 5 * 6.5));

            obj.Sort();

            /*
             *  Type:              Address:          Number of people:
             *  ================   ===============   =================
             *  LivingBuilding,    3-C Bestcode st,  26
             *  LivingBuilding,    3-D Bestcode st,  26
             *  NonLivingBuilding, 3-A Bestcode st,  26
             *  NonLivingBuilding, 3-B Bestcode st,  26
             *  LivingBuilding,    2-C Bestcode st,  6
             *  LivingBuilding,    2-D Bestcode st,  6
             *  NonLivingBuilding, 2-A Bestcode st,  6
             *  NonLivingBuilding, 2-B Bestcode st,  6
             *  LivingBuilding,    1-C Bestcode st,  0
             *  LivingBuilding,    1-D Bestcode st,  0
             *  NonLivingBuilding, 1-A Bestcode st,  0
             *  NonLivingBuilding, 1-B Bestcode st,  0
             */

            List<Building> buildings = obj.GetBuildings().ToList();

            Assert.IsTrue(buildings[0].AreEqual(new LivingBuilding("3-C Bestcode st", 2, 2 * 5)));
            Assert.IsTrue(buildings[1].AreEqual(new LivingBuilding("3-D Bestcode st", 2, 2 * 5)));
            Assert.IsTrue(buildings[2].AreEqual(new NonLivingBuilding("3-A Bestcode st", 4 * 5 * 6.5)));
            Assert.IsTrue(buildings[3].AreEqual(new NonLivingBuilding("3-B Bestcode st", 4 * 5 * 6.5)));

            Assert.IsTrue(buildings[4].AreEqual(new LivingBuilding("2-C Bestcode st", 1, 1 * 5)));
            Assert.IsTrue(buildings[5].AreEqual(new LivingBuilding("2-D Bestcode st", 1, 1 * 5)));
            Assert.IsTrue(buildings[6].AreEqual(new NonLivingBuilding("2-A Bestcode st", 1 * 5 * 6.5)));
            Assert.IsTrue(buildings[7].AreEqual(new NonLivingBuilding("2-B Bestcode st", 1 * 5 * 6.5)));

            Assert.IsTrue(buildings[8].AreEqual(new LivingBuilding("1-C Bestcode st", 0, 0)));
            Assert.IsTrue(buildings[9].AreEqual(new LivingBuilding("1-D Bestcode st", 0, 0)));
            Assert.IsTrue(buildings[10].AreEqual(new NonLivingBuilding("1-A Bestcode st", 0)));
            Assert.IsTrue(buildings[11].AreEqual(new NonLivingBuilding("1-B Bestcode st", 0)));
        }
    }
}
