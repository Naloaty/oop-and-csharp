using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab1
{
    public enum BookSort
    {
        Title,
        FirstAuthorLastName,
        City,
        Office,
        Year
    }

    public class HomeLibrary : IEnumerable<Book>
    {
        private readonly List<Book> _books = new List<Book>();

        public int Count
        {
            get { return _books.Count(); }
        }

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public List<Book> Search(Book query)
        {
            List<Book> result = new List<Book>();

            foreach(var book in _books)
            {
                if (book.Match(query))
                    result.Add(book);
            }

            return result;
        }

        public List<Book> Remove(Book query)
        {
            List<Book> forDeletion = Search(query);

            foreach (Book book in forDeletion)
                _books.Remove(book);

            return forDeletion;
        }

        public void Sort(BookSort sortBy)
        {
            switch (sortBy) {
                case BookSort.Title:
                    _books.Sort(new Book.TitleComparer());
                    break;

                case BookSort.FirstAuthorLastName:
                    _books.Sort(new Book.FirstAuthorLastNameComparer());
                    break;

                case BookSort.City:
                    _books.Sort(new Book.CityComparer());
                    break;

                case BookSort.Office:
                    _books.Sort(new Book.OfficeComparer());
                    break;

                case BookSort.Year:
                    _books.Sort(new Book.YearComparer());
                    break;
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return _books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
