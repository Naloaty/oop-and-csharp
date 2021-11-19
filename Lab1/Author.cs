using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    public class Authors : IEnumerable<Author>
    {
        private readonly List<Author> _list = new List<Author>();

        public void Add(string author)
        {
            _list.Add(new Author(author));
        }

        public bool Match(Authors query)
        {
            if (query == null)
                return false;

            foreach (Author queryAuthor in query)
            {
                bool present = false;

                foreach (Author bookAuthor in _list)
                {
                    if (!bookAuthor.Match(queryAuthor))
                        continue;

                    present = true;
                    break;
                }

                if (present)
                    continue;
                else
                    return false;
            }

            return true;
        }

        public Author Get(int index)
        {
            if (index < 0)
                return null;

            if (index >= _list.Count)
                return null;

            return _list[index];
        }

        public IEnumerator<Author> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Author
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                List<string> name = new List<string> { LastName };

                if (!string.IsNullOrEmpty(FirstName))
                    name.Add(FirstName);

                if (string.IsNullOrEmpty(MiddleName))
                    name.Add(MiddleName);

                return String.Join(' ', name);
            }
        }

        public string ShortName
        {
            get {
                List<string> name = new List<string> { LastName };
                bool addDot = true;

                if (!string.IsNullOrEmpty(FirstName))
                {
                    addDot = false;
                    name.Add(FirstName[0] + ".");
                }

                if (!string.IsNullOrEmpty(MiddleName))
                {
                    addDot = false;
                    name.Add(MiddleName[0] + ".");
                }

                if (addDot)
                    name.Add(".");

                return String.Join(addDot ? "" : " ", name); 
            }
        }

        public Author(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                throw new ArgumentNullException(nameof(fullName));

            string[] tokens = fullName.Split(' ');

            if (tokens.Length >= 1)
                LastName = tokens[0];

            if (tokens.Length >= 2)
                FirstName = tokens[1];

            if (tokens.Length >= 3)
                MiddleName = tokens[2];
        }

        public bool Match(Author query)
        {
            if (!string.IsNullOrEmpty(query.FirstName))
                if (string.IsNullOrEmpty(FirstName) || query.FirstName != FirstName)
                    return false;

            if (!string.IsNullOrEmpty(query.LastName))
                if (string.IsNullOrEmpty(LastName) || query.LastName != LastName)
                    return false;

            if (!string.IsNullOrEmpty(query.MiddleName))
                if (string.IsNullOrEmpty(MiddleName) || query.MiddleName != MiddleName)
                    return false;

            return true;
        }

        public override string ToString()
        {
            return ShortName;
        }
    }
}
