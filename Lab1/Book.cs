using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Book
    {
        public string Title { get; set; }
        public Authors Authors { get; set; }
        public string City { get; set; }
        public string Office { get; set; }
        public int Year { get; set; }


        public bool Match(Book query)
        {
            if (!string.IsNullOrEmpty(query.Title))
                if (string.IsNullOrEmpty(Title) || query.Title != Title)
                    return false;

            if (query.Authors != null)
                if (Authors == null || !Authors.Match(query.Authors))
                    return false;

            if (!string.IsNullOrEmpty(query.City))
                if (string.IsNullOrEmpty(City) || query.City != City)
                    return false;

            if (!string.IsNullOrEmpty(query.Office))
                if (string.IsNullOrEmpty(Office) || query.Office != Office)
                    return false;

            if (query.Year != 0)
                if (Year == 0 || query.Year != Year)
                    return false;

            return true;
        }


        public override string ToString()
        {
            StringBuilder repr = new StringBuilder();

            if (Authors != null)
            {
                repr.AppendJoin(", ", Authors);
                repr.Append(' ');
            }

            if (!string.IsNullOrEmpty(Title))
                repr.Append(Title);
            else
                repr.Append("Untitled");

            if (!string.IsNullOrEmpty(City))
            {
                repr.Append(". ");
                repr.Append(City);

                if (!string.IsNullOrEmpty(Office))
                {
                    repr.Append(": ");
                    repr.Append(Office);
                }
            }

            if (Year != 0)
            {
                repr.Append(", ");
                repr.Append(Year);
            }

            repr.Append(".");

            return repr.ToString();
        }

        public class TitleComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                string xTitle = x.Title;
                string yTitle = y.Title;

                if (string.IsNullOrEmpty(xTitle))
                    xTitle = "";

                if (!string.IsNullOrEmpty(yTitle))
                    yTitle = "";

                return string.Compare(
                    xTitle, yTitle,
                    StringComparison.CurrentCulture);
            }
        }

        public class FirstAuthorLastNameComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                Author xAuthor = x.Authors.Get(0);
                Author yAuthor = y.Authors.Get(0);

                string xName = "";
                string yName = "";

                if (xAuthor != null)
                    xName = xAuthor.FullName;

                if (yAuthor != null)
                    yName = yAuthor.FullName;

                return string.Compare(
                    xName, yName,
                    StringComparison.CurrentCulture);
            }
        }

        public class CityComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                string xCity = x.City;
                string yCity = y.City;

                if (string.IsNullOrEmpty(xCity))
                    xCity = "";

                if (!string.IsNullOrEmpty(yCity))
                    yCity = "";

                return string.Compare(
                    xCity, yCity,
                    StringComparison.CurrentCulture);
            }
        }

        public class OfficeComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                string xOffice = x.Office;
                string yOffice = y.Office;

                if (string.IsNullOrEmpty(xOffice))
                    xOffice = "";

                if (!string.IsNullOrEmpty(yOffice))
                    yOffice = "";

                return string.Compare(
                    xOffice, yOffice,
                    StringComparison.CurrentCulture);
            }
        }

        public class YearComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                return x.Year - y.Year;
            }
        }

    }
}
