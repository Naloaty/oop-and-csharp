using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4;
using System.Text;
using System.Linq;

namespace Target
{
    [TestClass]
    public class PhoneNumber
    {
        [TestMethod]
        public void SingleNumberOnPage_DefaultSettings()
        {
            StringBuilder testHtml = new();
            testHtml.AppendLine(@"<p>Адрес: 454080, г. Челябинск, пр. Ленина, 87<br>");
            testHtml.AppendLine(@"Аудитория 492 корпуса 3А<br>");
            testHtml.AppendLine(@"Телефон: (351) 267-90-94<br>");
            testHtml.AppendLine("E-mail: <a href=\"mailto: eecs @susu.ru\" target=\"_blank\" processed=\"processed\">eecs@susu.ru</a><br>");
            testHtml.AppendLine("Сайт: &nbsp;< a href = \"http://eecs.susu.ru/\" target = \"_blank\" > http://eecs.susu.ru/</a><br>");
            testHtml.AppendLine("Группа ВК:&nbsp;< a href = \"https://vk.com/susu_eecs\" target = \"_blank\" rel = \"nofollow\" > https://vk.com/susu_eecs</a></p>");

            PhoneTarget target = new();
            string[] numbers = target.MatchAll(testHtml.ToString()).ToArray();

            Assert.AreEqual(1, numbers.Length);
            Assert.AreEqual("(351) 267-90-94", numbers[0]);
        }

        [TestMethod]
        public void FewNumbersOnPage_ExtraSettingsOff()
        {
            StringBuilder testHtml = new();
            testHtml.AppendLine("<p> Адрес: 454080, г.Челябинск, ул.Сони Кривой, 60 <br>");
            testHtml.AppendLine("Телефон: +7(351)267-98-49<br>");
            testHtml.AppendLine("Телефон для абитуриентов: 8(351) 267-92-76 <br>");
            testHtml.AppendLine("<p>Адрес: 454080, г. Челябинск, пр. Ленина, 87<br>");
            testHtml.AppendLine("Аудитория 492 корпуса 3А<br>");
            testHtml.AppendLine("Телефон: (351) 267-90-94<br>");
            testHtml.AppendLine("E-mail: <a href=\"mailto: eecs @susu.ru\" target=\"_blank\" processed=\"processed\">eecs@susu.ru</a><br>");
            testHtml.AppendLine("Сайт: &nbsp;< a href = \"http://eecs.susu.ru/\" target = \"_blank\" > http://eecs.susu.ru/</a><br>");
            testHtml.AppendLine("Группа ВК:&nbsp;< a href = \"https://vk.com/susu_eecs\" target = \"_blank\" rel = \"nofollow\" > https://vk.com/susu_eecs</a></p>");

            PhoneTarget target = new();
            string[] numbers = target.MatchAll(testHtml.ToString()).ToArray();

            Assert.AreEqual(3, numbers.Length);
            Assert.AreEqual("+7(351)267-98-49", numbers[0]);
            Assert.AreEqual("8(351) 267-92-76", numbers[1]);
            Assert.AreEqual("(351) 267-90-94", numbers[2]);
        }

        [TestMethod]
        public void FewNumbersOnPage_FilterRepeats()
        {
            StringBuilder testHtml = new();
            testHtml.AppendLine("<p> Адрес: 454080, г.Челябинск, ул.Сони Кривой, 60 <br>");
            testHtml.AppendLine("Телефон: +7(351)267-98-49<br>");
            testHtml.AppendLine("Телефон для абитуриентов: 8(351) 267-92-76 <br>");
            testHtml.AppendLine("<p>Адрес: 454080, г. Челябинск, пр. Ленина, 87<br>");
            testHtml.AppendLine("Аудитория 492 корпуса 3А<br>");
            testHtml.AppendLine("Телефон: +7(351)267-98-49<br>");

            PhoneTarget target = new(true, false, false);
            string[] numbers = target.MatchAll(testHtml.ToString()).ToArray();

            Assert.AreEqual(2, numbers.Length);
            Assert.AreEqual("+7(351)267-98-49", numbers[0]);
            Assert.AreEqual("8(351) 267-92-76", numbers[1]);
        }

        [TestMethod]
        public void FewNumbersOnPage_ReformatNumbers()
        {
            StringBuilder testHtml = new();
            testHtml.AppendLine("<p> Адрес: 454080, г.Челябинск, ул.Сони Кривой, 60 <br>");
            testHtml.AppendLine("Телефон: +7(351)267-98-49<br>");
            testHtml.AppendLine("Телефон для абитуриентов: 8(351) 267-92-76 <br>");
            testHtml.AppendLine("<p>Адрес: 454080, г. Челябинск, пр. Ленина, 87<br>");
            testHtml.AppendLine("Аудитория 492 корпуса 3А<br>");
            testHtml.AppendLine("Телефон: (351) 267-90-94<br>");

            PhoneTarget target = new(false, true, false);
            string[] numbers = target.MatchAll(testHtml.ToString()).ToArray();

            Assert.AreEqual(3, numbers.Length);
            Assert.AreEqual("7(351)267-98-49", numbers[0]);
            Assert.AreEqual("8(351)267-92-76", numbers[1]);
            Assert.AreEqual("7(351)267-90-94", numbers[2]);
        }

        [TestMethod]
        public void FewNumbersOnPage_StrictValidation()
        {
            StringBuilder testHtml = new();
            testHtml.AppendLine("<p> Адрес: 454080, г.Челябинск, ул.Сони Кривой, 60 <br>");
            testHtml.AppendLine("Телефон: +73512679849<br>");
            testHtml.AppendLine("Телефон для абитуриентов: 8(351) 267-92-76 <br>");
            testHtml.AppendLine("<p>Адрес: 454080, г. Челябинск, пр. Ленина, 87<br>");
            testHtml.AppendLine("Аудитория 492 корпуса 3А<br>");
            testHtml.AppendLine("Телефон: (351) 267-90-94<br>");

            PhoneTarget target = new(false, false, true);
            string[] numbers = target.MatchAll(testHtml.ToString()).ToArray();

            Assert.AreEqual(2, numbers.Length);
            Assert.AreEqual("8(351) 267-92-76", numbers[0]);
            Assert.AreEqual("(351) 267-90-94", numbers[1]);
        }

        [TestMethod]
        public void FewNumbersOnPage_AllExtraSettingsOn()
        {
            StringBuilder testHtml = new();
            testHtml.AppendLine("<p> Адрес: 454080, г.Челябинск, ул.Сони Кривой, 60 <br>");
            testHtml.AppendLine("Телефон: +73512679849<br>");
            testHtml.AppendLine("Телефон для абитуриентов: 8(351) 267-92-76 <br>");
            testHtml.AppendLine("<p>Адрес: 454080, г. Челябинск, пр. Ленина, 87<br>");
            testHtml.AppendLine("Аудитория 492 корпуса 3А<br>");
            testHtml.AppendLine("Телефон: (351) 267-90-94<br>");
            testHtml.AppendLine("Телефон: (351)267-90-94<br>");
            testHtml.AppendLine("Телефон: (351)267-90-92<br>");

            PhoneTarget target = new(true, true, true);
            string[] numbers = target.MatchAll(testHtml.ToString()).ToArray();

            Assert.AreEqual(3, numbers.Length);
            Assert.AreEqual("8(351)267-92-76", numbers[0]);
            Assert.AreEqual("7(351)267-90-94", numbers[1]);
            Assert.AreEqual("7(351)267-90-92", numbers[2]);
        }
    }
}
