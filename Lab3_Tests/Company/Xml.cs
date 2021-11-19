using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Lab_3;

namespace Company
{
    [TestClass]
    public class Xml
    {
        [TestMethod]
        public void Xml_SaveLoadTest()
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

            List<Building> initial = obj.GetBuildings().ToList();

            // Save to XML file
            obj.SaveToXml("test.xml");

            // Rrestore from XML file
            ManagementCompany obj2 = ManagementCompany.LoadFromXml("test.xml");
            List<Building> restored = obj2.GetBuildings().ToList();

            for (int i = 0; i < 10; i++)
                Assert.IsTrue(initial[i].AreEqual(restored[i]));

            Assert.AreEqual(obj.NumberOfPeople, obj2.NumberOfPeople);
        }
    }
}
