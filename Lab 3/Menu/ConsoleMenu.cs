using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anatoly.Menu
{
    public delegate void OnSelected();

    public class MenuOption
    {
        public string Title { get; set; }

        public OnSelected OnSelected { get; set; }
        
    }

    public class ConsoleMenu
    {
        private readonly List<MenuOption> m_options = new();

        public string Title { get; set; }

        public int OptionCount { get { return m_options.Count; } }

        public void AddOption(MenuOption option)
        {
            m_options.Add(option);
        }

        public int Prompt(string name)
        {
            Console.WriteLine($"====> {Title} <====");

            for (int i = 0; i < m_options.Count; i++)
                Console.WriteLine($"{i + 1}) {m_options[i].Title}");

            int option;

            while(true)
            {
                Console.WriteLine("");
                option = ReadInt(string.IsNullOrEmpty(name) ? "Option" : name);

                if (1 <= option && option <= m_options.Count)
                    break;

                Console.WriteLine($"Please enter an number from 1 to {m_options.Count}");
            }

            if (m_options[option - 1].OnSelected != null)
            {
                Console.WriteLine("");
                m_options[option - 1].OnSelected.Invoke();
                Console.WriteLine("");
            }

            return option;
        }

        public static int ReadInt(string name, bool repeatOnError = true)
        {
            while(true)
            {
                if (!string.IsNullOrEmpty(name))
                    Console.Write($"{name} > ");

                bool success = int.TryParse(Console.ReadLine(), out int result);

                if (success || !repeatOnError)
                    return result;

                Console.WriteLine("Ohh, do you really think it looks like an integer number? Try again!");
                Console.WriteLine("");
            }
        }

        public static double ReadDouble(string name, bool repeatOnError = true)
        {
            while (true)
            {
                if (!string.IsNullOrEmpty(name))
                    Console.Write($"{name} > ");

                bool success = double.TryParse(Console.ReadLine(), out double result);

                if (success || !repeatOnError)
                    return result;

                Console.WriteLine("Ohh, do you really think it looks like a decimal number? Try again!");
                Console.WriteLine("");
            }
        }

        public static string ReadLine(string name, bool emptyAllowed = true)
        {
            while (true)
            {
                if (!string.IsNullOrEmpty(name))
                    Console.Write($"{name} > ");

                string result = Console.ReadLine();

                if (!string.IsNullOrEmpty(result) || emptyAllowed)
                    return result;

                Console.WriteLine("No, no, no. Empty line is not allowed here. Try again!");
                Console.WriteLine("");
            }
        }

    }
}
