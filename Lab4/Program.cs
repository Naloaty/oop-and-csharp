using System;
using System.Text;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            using (WebScanner scanner = new WebScanner(100, 10))
            {
                scanner.AddTarget(new PhoneTarget(true, true, true));
                scanner.AddTarget(new AddressTarget());

                scanner.AddTransport(new ConsoleTransport());
                scanner.AddTransport(new CsvTransport(@"D:\test.csv", false));

                scanner.Scan(new Uri("https://www.susu.ru/ru/structure"));
            }
        }
    }
}
