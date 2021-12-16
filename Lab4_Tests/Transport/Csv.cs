using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Lab4;
using System;
using System.IO;
using System.Text;

namespace Transport
{
    [TestClass]
    public class Csv
    {
        private static readonly string[] m_addresses =
        {
            "454080, г. Челябинск, пр. Ленина, 87",
            "454080, г. Челябинск, пр. Ленина, 86"
        };

        private static readonly string[] m_numbers =
        {
            "8(351)267-92-76",
            "7(351)267-90-94"
        };

        private static readonly List<TargetItem> m_testData = new()
        {
            new TargetItem()
            {
                Uri = new Uri("https://susu.ru/1"),
                Title = "Title 1",
                Depth = 0,
                Values = m_addresses,
                Type = typeof(AddressTarget)
            },
            new TargetItem()
            {
                Uri = new Uri("https://susu.ru/1/1"),
                Title = "Subtitle 1",
                Depth = 1,
                Values = m_addresses,
                Type = typeof(AddressTarget)
            },
            new TargetItem()
            {
                Uri = new Uri("https://susu.ru/1/1/1"),
                Title = "Subsubtitle 1",
                Depth = 2,
                Values = m_numbers,
                Type = typeof(PhoneTarget)
            },
            new TargetItem()
            {
                Uri = new Uri("https://susu.ru/2"),
                Title = "Title 2",
                Depth = 0,
                Values = m_numbers,
                Type = typeof(PhoneTarget)
            }
        };

        [TestMethod]
        public void Constructor_NullFilename()
        {
            using (WebScanner scanner = new())
            {
                Assert.ThrowsException<ArgumentNullException>(() => new CsvTransport(null));
            }
        }

        [TestMethod]
        public void SaveTest_DefaultSettings()
        {
            CsvTransport transport = new("test.csv");

            foreach (var item in m_testData)
                transport.ProcessTargetItem(item);

            transport.WorkDone();

            string[] actual = File.ReadAllLines("test.csv", Encoding.UTF8);
            string[] expected =
            {
                "URL,Name,Depth,Value",
                "\"https://susu.ru/1\",\"Title 1\",0,\"454080, г. Челябинск, пр. Ленина, 87\"",
                "\"https://susu.ru/1\",\"Title 1\",0,\"454080, г. Челябинск, пр. Ленина, 86\"",
                "\"https://susu.ru/1/1\",\"Subtitle 1\",1,\"454080, г. Челябинск, пр. Ленина, 87\"",
                "\"https://susu.ru/1/1\",\"Subtitle 1\",1,\"454080, г. Челябинск, пр. Ленина, 86\"",
                "\"https://susu.ru/1/1/1\",\"Subsubtitle 1\",2,\"8(351)267-92-76\"",
                "\"https://susu.ru/1/1/1\",\"Subsubtitle 1\",2,\"7(351)267-90-94\"",
                "\"https://susu.ru/2\",\"Title 2\",0,\"8(351)267-92-76\"",
                "\"https://susu.ru/2\",\"Title 2\",0,\"7(351)267-90-94\""
            };

            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        public void SaveTest_SaveTitleAsTree()
        {
            CsvTransport transport = new("test.csv", true);

            foreach (var item in m_testData)
                transport.ProcessTargetItem(item);

            transport.WorkDone();

            string[] actual = File.ReadAllLines("test.csv", Encoding.UTF8);
            string[] expected =
            {
                "URL,Name,Depth,Value",
                "\"https://susu.ru/1\",\"Title 1\",0,\"454080, г. Челябинск, пр. Ленина, 87\"",
                "\"https://susu.ru/1\",\"Title 1\",0,\"454080, г. Челябинск, пр. Ленина, 86\"",
                "\"https://susu.ru/1/1\",\"|--Subtitle 1\",1,\"454080, г. Челябинск, пр. Ленина, 87\"",
                "\"https://susu.ru/1/1\",\"|--Subtitle 1\",1,\"454080, г. Челябинск, пр. Ленина, 86\"",
                "\"https://susu.ru/1/1/1\",\"|--|--Subsubtitle 1\",2,\"8(351)267-92-76\"",
                "\"https://susu.ru/1/1/1\",\"|--|--Subsubtitle 1\",2,\"7(351)267-90-94\"",
                "\"https://susu.ru/2\",\"Title 2\",0,\"8(351)267-92-76\"",
                "\"https://susu.ru/2\",\"Title 2\",0,\"7(351)267-90-94\""
            };

            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
