using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4;
using System.Text;
using System.Linq;

namespace Target
{
    [TestClass]
    public class Address
    {
        [TestMethod]
        public void SingleAddressOnPage()
        {
            StringBuilder testHtml = new();
            testHtml.AppendLine(@"<p>Адрес: 454080, г. Челябинск, пр. Ленина, 87<br>");
            testHtml.AppendLine(@"Аудитория 492 корпуса 3А<br>");
            testHtml.AppendLine(@"Телефон: (351) 267-90-94<br>");
            testHtml.AppendLine("E-mail: <a href=\"mailto: eecs @susu.ru\" target=\"_blank\" processed=\"processed\">eecs@susu.ru</a><br>");
            testHtml.AppendLine("Сайт: &nbsp;< a href = \"http://eecs.susu.ru/\" target = \"_blank\" > http://eecs.susu.ru/</a><br>");
            testHtml.AppendLine("Группа ВК:&nbsp;< a href = \"https://vk.com/susu_eecs\" target = \"_blank\" rel = \"nofollow\" > https://vk.com/susu_eecs</a></p>");

            AddressTarget target = new();
            string[] addresses = target.MatchAll(testHtml.ToString()).ToArray();

            Assert.AreEqual(1, addresses.Length);
            Assert.AreEqual("454080, г. Челябинск, пр. Ленина, 87", addresses[0]);
        }

        [TestMethod]
        public void FewAddressesOnPage()
        {
            StringBuilder testHtml = new();
            testHtml.AppendLine("<p> Адрес: 454080, г.Челябинск, ул.Сони Кривой, 60 <br>");
            testHtml.AppendLine("Телефон: (351) 267-98-49<br>");
            testHtml.AppendLine("Телефон для абитуриентов: (351) 267-92-76 <br>");
            testHtml.AppendLine("<p>Адрес: 454080, г. Челябинск, пр. Ленина, 87<br>");
            testHtml.AppendLine("Аудитория 492 корпуса 3А<br>");
            testHtml.AppendLine("Телефон: (351) 267-90-94<br>");
            testHtml.AppendLine("E-mail: <a href=\"mailto: eecs @susu.ru\" target=\"_blank\" processed=\"processed\">eecs@susu.ru</a><br>");
            testHtml.AppendLine("Сайт: &nbsp;< a href = \"http://eecs.susu.ru/\" target = \"_blank\" > http://eecs.susu.ru/</a><br>");
            testHtml.AppendLine("Группа ВК:&nbsp;< a href = \"https://vk.com/susu_eecs\" target = \"_blank\" rel = \"nofollow\" > https://vk.com/susu_eecs</a></p>");

            AddressTarget target = new();
            string[] addresses = target.MatchAll(testHtml.ToString()).ToArray();

            Assert.AreEqual(2, addresses.Length);
            Assert.AreEqual("454080, г.Челябинск, ул.Сони Кривой, 60", addresses[0]);
            Assert.AreEqual("454080, г. Челябинск, пр. Ленина, 87", addresses[1]);
        }
    }
}
