using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(" === Home library 1.0 ===");
            Console.WriteLine("(C) Anatoly Mashkin, KE-204, Fall 2021.");

            HomeLibrary lib = new HomeLibrary();

            Console.WriteLine("");

            bool running = true;
            while (running)
            {
                Console.WriteLine(" === Select action ===");
                Console.WriteLine("1) Add book");
                Console.WriteLine("2) Remove book");
                Console.WriteLine("3) Search books");
                Console.WriteLine("4) Sort library");
                Console.WriteLine("5) List all books");
                Console.WriteLine("6) Fill library with test data");
                Console.WriteLine("7) Exit");
                Console.WriteLine("");
                Console.Write("Option > ");

                int action = int.Parse(Console.ReadLine());

                Console.WriteLine("");


                switch(action)
                {
                    case 1: // Add book
                        Console.WriteLine(" === Add book ===");
                        Console.WriteLine("");

                        Book book = ReadBook();
                        lib.Add(book);

                        Console.WriteLine("");
                        Console.WriteLine($"Book '{book.Title}' successfully added to library!");
                        break;

                    case 2: // Remove book
                        Console.WriteLine(" === Remove book ===");
                        Console.WriteLine("Specify parameters for book search.");
                        Console.WriteLine("Some parameters may be empty.");
                        Console.WriteLine("Note: all matching books will be removed!");
                        Console.WriteLine("");

                        Book query = ReadBook();

                        Console.WriteLine("");
                        List<Book> deleted = lib.Remove(query);

                        foreach (Book _book in deleted)
                            Console.WriteLine($"- book '{_book.Title}' removed");

                        if (deleted.Count == 0)
                            Console.WriteLine("No books match specified criteries.");

                        break;

                    case 3: // Search books
                        Console.WriteLine(" === Search books ===");
                        Console.WriteLine("Specify parameters for book search.");
                        Console.WriteLine("Some parameters may be empty.");
                        Console.WriteLine("");

                        query = ReadBook();

                        Console.WriteLine("");
                        List<Book> results = lib.Search(query);

                        foreach (Book _book in results)
                            Console.WriteLine("- " + _book);

                        if (results.Count == 0)
                            Console.WriteLine("No books match specified criteries.");

                        break;

                    case 4: // Sort library
                        Console.WriteLine(" === Sort library ===");
                        Console.WriteLine("Sort by ..");
                        Console.WriteLine("");
                        Console.WriteLine("1) Title");
                        Console.WriteLine("2) Last name of first author");
                        Console.WriteLine("3) Publishing city");
                        Console.WriteLine("4) Publishing office");
                        Console.WriteLine("5) Year of publishing");
                        Console.WriteLine("");
                        Console.Write("Option > ");
                        int option = int.Parse(Console.ReadLine());
                        bool wrongOption = false;

                        switch (option)
                        {
                            case 1:
                                lib.Sort(BookSort.Title);
                                break;

                            case 2:
                                lib.Sort(BookSort.FirstAuthorLastName);
                                break;

                            case 3:
                                lib.Sort(BookSort.City);
                                break;

                            case 4:
                                lib.Sort(BookSort.Office);
                                break;

                            case 5:
                                lib.Sort(BookSort.Year);
                                break;

                            default:
                                wrongOption = true;
                                Console.WriteLine("");
                                Console.WriteLine("Wrong option.");
                                break;

                        }

                        if (!wrongOption)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Library successfully sorted!");
                        }      

                        break;

                    case 5: // List all books
                        Console.WriteLine(" === List of books ===");

                        foreach (Book _book in lib)
                            Console.WriteLine(_book);

                        if (lib.Count == 0)
                            Console.WriteLine("*empty*");

                        break;

                    case 6: // Fill with test data
                        lib.Add(new Book { 
                            Title = "Puss in Boots", 
                            Authors = new Authors { "Charles Perrault" },
                            Year = 1697
                        });

                        lib.Add(new Book
                        {
                            Title = "Rumpelstiltskin",
                            Authors = new Authors { "Brothers Grimm" }
                        });

                        lib.Add(new Book
                        {
                            Title = "Rapunzel",
                            Authors = new Authors { "Brothers Grimm" }
                        });

                        lib.Add(new Book
                        {
                            Title = "The Frog Prince",
                            Authors = new Authors { "Brothers Grimm" },
                        });

                        lib.Add(new Book
                        {
                            Title = "The Snow Queen",
                            Authors = new Authors { "Hans Christian Andersen" },
                            Year = 1844
                        });

                        lib.Add(new Book
                        {
                            Title = "Sleeping Beauty",
                            Authors = new Authors { "Unknown" },
                            Year = 1697
                        });

                        lib.Add(new Book
                        {
                            Title = "Cinderella",
                            Authors = new Authors { "Charles Perrault" },
                            Year = 1697
                        });

                        lib.Add(new Book
                        {
                            Title = "Snow-White",
                            Authors = new Authors { "Brothers Grimm" }
                        });

                        lib.Add(new Book
                        {
                            Title = "Goldilocks and the Three Bears",
                            Authors = new Authors { "Laureate Robert Southey" },
                        });

                        lib.Add(new Book
                        {
                            Title = "Little Red Riding Hood",
                            Authors = new Authors { "Unknown" }
                        });

                        lib.Add(new Book
                        {
                            Title = "Kotlin in Action",
                            Authors = new Authors { "Jemerov Dmitry", "Isakova Svetlana"},
                            City = "Shelter Island",
                            Office = "Manning",
                            Year = 2018
                        });

                        lib.Add(new Book
                        {
                            Title = "The science of Interstellar",
                            Authors = new Authors { "Thorne Kip" },
                            City = "New York",
                            Office = "W.W. Norton & Company",
                            Year = 2015
                        });

                        Console.WriteLine("Test data added to library.");
                        break;


                    case 7: // Exit
                        running = false;
                        Console.WriteLine("Until next time!");
                        Console.WriteLine("Press enter to exit...");
                        break;

                    default:
                        Console.WriteLine("Unknown action. Try again.");
                        break;
                }

                Console.ReadLine(); // Wait for user to continue
                Console.WriteLine("");
            }


        }

        static Book ReadBook()
        {
            Book book = new Book();

            Console.Write("Title > ");
            book.Title = Console.ReadLine().Trim();

            Console.Write("Author(s) > ");
            book.Authors = new Authors();
            string[] strAuthors = Console.ReadLine().Split(",");

            foreach (string strAuthor in strAuthors)
                if (!string.IsNullOrEmpty(strAuthor))
                    book.Authors.Add(strAuthor.Trim());

            Console.Write("Publishing city > ");
            book.City = Console.ReadLine().Trim();

            Console.Write("Publishing office > ");
            book.Office = Console.ReadLine().Trim();

            bool yearValid = false;

            while (!yearValid)
            {
                Console.Write("Year of publishing > ");
                string year = Console.ReadLine().Trim();

                try
                {
                    if (!string.IsNullOrEmpty(year))
                        book.Year = int.Parse(year);

                    yearValid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Only numbers are valid as publishing year. Try agian.");
                    Console.WriteLine("Leave this field empty if you do not want to specify publishing year.");
                }
            }
                

            return book;
        }
    }
}
