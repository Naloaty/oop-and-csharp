using System;

namespace Lab0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! I am console app. What is your name?");
            Console.Write("> "); String name = Console.ReadLine();
            Console.WriteLine($"Nice to meet you, {name}!");
            Console.WriteLine("Hello world btw!");
        }
    }
}
