using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Lab_3
{
    public class ManagementCompany
    {
        private List<Building> m_buildings = new();

        public int NumberOfPeople { get; private set; }

        public void Add(Building building)
        {
            m_buildings.Add(building);
            NumberOfPeople += building.NumberOfPeople;
        }

        public IEnumerable<Building> GetBuildings()
        {
            return m_buildings;
        }

        public void Sort()
        {
            m_buildings = m_buildings
                .OrderByDescending(b => b, new ByNumberOfPeople())
                .ThenBy(b => b, new ByType())
                .ThenBy(b => b, new ByAddress())
                .ToList();
        }

        public void SaveToXml(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Building>));

            using var stream = File.OpenWrite(fileName);
            serializer.Serialize(stream, m_buildings);
            stream.Flush();
        }

        public static ManagementCompany LoadFromXml(string fileName)
        {
            var company = new ManagementCompany();
            var serializer = new XmlSerializer(typeof(List<Building>));

            using var stream = File.OpenRead(fileName);

            if (serializer.Deserialize(stream) is IEnumerable<Building> buildings)
            {
                foreach (var building in buildings)
                    company.Add(building);
            }

            return company;
        }

        private class ByNumberOfPeople : IComparer<Building>
        {
            public int Compare(Building x, Building y)
            {
                return x.NumberOfPeople.CompareTo(y.NumberOfPeople);
            }
        }


        private class ByAddress : IComparer<Building>
        {
            public int Compare(Building x, Building y)
            {
                return string.Compare(x.Address, y.Address,
                        StringComparison.CurrentCulture);
            }
        }

        private class ByType : IComparer<Building>
        {
            public int Compare(Building x, Building y)
            {
                int xIndex = x is LivingBuilding ? 0 : 1;
                int yIndex = y is LivingBuilding ? 0 : 1;

                return xIndex.CompareTo(yIndex);
            }
        }
    }
}
