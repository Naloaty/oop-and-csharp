using System;
using System.Linq;
using System.Collections.Generic;
using Anatoly.Menu;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" === Management Company 1.0 ===");
            Console.WriteLine("(C) Anatoly Mashkin, KE-204, Fall 2021.\n");

            ManagementCompany company = new();
            ConsoleMenu menu = new();

            menu.Title = "Select action";

            menu.AddOption(new MenuOption { 
                Title = "Add a building", 

                OnSelected = () => {
                    Building building = ReadBuilding();

                    if (building == null)
                        return;

                    company.Add(building);

                    Console.WriteLine("");
                    Console.WriteLine("Building successfully added!");
                    Console.WriteLine($"Total number of people: {company.NumberOfPeople}");
                }
            });

            menu.AddOption(new MenuOption { 
                Title = "Sort (people -> type -> address)",

                OnSelected = () => {
                    company.Sort();
                    Console.WriteLine("Buildings sorted successfully!");
                }
            });

            menu.AddOption(new MenuOption
            {
                Title = "Display first 3 buildings",

                OnSelected = () => {
                    List<Building> buildings = company.GetBuildings().ToList();

                    if (buildings.Count == 0)
                        Console.WriteLine("0 buildings");

                    for (int i = 0; i < 3; i++)
                    {
                        if (i >= buildings.Count)
                            break;

                        Console.WriteLine($"- {buildings[i]}");
                    }
                }
            });

            menu.AddOption(new MenuOption
            {
                Title = "Display last 4 addresses",

                OnSelected = () =>
                {
                    List<Building> buildings = company.GetBuildings().ToList();

                    if (buildings.Count == 0)
                        Console.WriteLine("0 buildings");

                    for (int i = buildings.Count - 4; i < buildings.Count; i++)
                    {
                        if (i < 0)
                            continue;

                        Console.WriteLine($"- {buildings[i].Address}");
                    }
                }
            });

            menu.AddOption(new MenuOption
            {
                Title = "Display total number of people",

                OnSelected = () =>
                {
                    Console.WriteLine($"Total number of people: {company.NumberOfPeople}");
                }
            });

            menu.AddOption(new MenuOption { 
                Title = "Display all",

                OnSelected = () => {
                    if (!company.GetBuildings().Any())
                        Console.WriteLine("0 buildings");

                    foreach (var bulding in company.GetBuildings())
                        Console.WriteLine(bulding);
                }
            });

            menu.AddOption(new MenuOption { 
                Title = "Save to XML",

                OnSelected = () => {
                    string filename = ConsoleMenu.ReadLine("Filename");

                    try
                    {
                        company.SaveToXml(filename);
                        Console.WriteLine($"A list of buildings saved to '{filename}' successfully!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Sorry, some error occured: {e.Message}");
                    }
                }
            });

            menu.AddOption(new MenuOption {
                Title = "Load from XML",

                OnSelected = () => {
                    string filename = ConsoleMenu.ReadLine("Filename");

                    try
                    {
                        company = ManagementCompany.LoadFromXml(filename);
                        Console.WriteLine($"A list of buildings loaded from '{filename}' successfully!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Sorry, some error occured: {e.Message}");
                    }
                }
            });

            menu.AddOption(new MenuOption {
                Title = "Populate with test data",

                OnSelected = () => {
                    for (int i = 1; i <= 5; i++)
                    {
                        company.Add(new LivingBuilding
                        {
                            Address = $"Bliving st",
                            Rooms = i,
                            Apartments = i * 5
                        });

                        company.Add(new LivingBuilding
                        {
                            Address = $"Aliving st",
                            Rooms = i,
                            Apartments = i * 5
                        });

                        company.Add(new NonLivingBuilding
                        {
                            Address = $"DnonLiving st",
                            Square = i * i * 5 * 6.5
                        });

                        company.Add(new NonLivingBuilding
                        {
                            Address = $"CnonLiving st",
                            Square = i * i * 5 * 6.5
                        });
                    }

                    Console.WriteLine("Management company populated with test data!");
                }
            });

            menu.AddOption(new MenuOption { 
                Title = "Exit"
            });

            int option;

            do
            {
                option = menu.Prompt("Action");
            }
            while (option != menu.OptionCount);
        }

        public static Building ReadBuilding()
        {
            ConsoleMenu menu = new();

            menu.Title = "Select building type";

            menu.AddOption(new MenuOption { Title = "Living" });
            menu.AddOption(new MenuOption { Title = "Non-living"});

            int type = menu.Prompt("Type");

            try
            {
                if (type == 1)
                {
                    return new LivingBuilding
                    {
                        Address = ConsoleMenu.ReadLine("Address", false),
                        Rooms = ConsoleMenu.ReadInt("Number of rooms"),
                        Apartments = ConsoleMenu.ReadInt("Number of apartments")
                    };
                }
                else if (type == 2)
                {
                    return new NonLivingBuilding
                    {
                        Address = ConsoleMenu.ReadLine("Address", false),
                        Square = ConsoleMenu.ReadDouble("Square")
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}. Try again!");
            }

            return null;
        }
    }
}
