using System;

namespace Lab2_NS
{
    public sealed class MyString: IComparable<MyString>
    {
        private bool m_dynamic;
        private char[] m_value;
        private int m_contentLen;

        public MyString(bool dynamic = false)
        {
            m_contentLen = 0;
            m_value = new char[10];
            m_dynamic = dynamic;
        }

        public MyString(string value, bool dynamic = false)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), "MyString value cannot be null");

            m_value = value.ToCharArray();
            m_contentLen = value.Length;
            m_dynamic = dynamic;
        }

        public int Length
        {
            get { return m_contentLen; }
        }

        public char Get(int index)
        {
            if (index <= -1 || index >= m_contentLen)
                throw new IndexOutOfRangeException();

            return m_value[index];
        }

        public MyString AppendChar(char ch)
        {
            if (m_contentLen + 1 > m_value.Length)
            {
                char[] value = new char[m_dynamic ? m_value.Length * 2 : m_value.Length + 1];

                Array.Copy(m_value, value, m_value.Length);
                Array.Clear(m_value, 0, m_value.Length);

                m_value = value;
            }

            m_value[m_contentLen] = ch;
            m_contentLen += 1;

            return this;
        }

        public int CompareTo(MyString other)
        {
            if (other is null) return 1;

            for (int i = 0; i < m_value.Length; i++)
            {
                // Other string is substring of this instance
                if (i == other.Length) return 1;

                int relation = m_value[i] - other.Get(i);
                int caseRelation = char.ToLower(m_value[i]) - char.ToLower(other.Get(i));

                // lexicographical order 
                if (caseRelation == 0)
                {
                    if (relation == 0)
                        continue;
                    else
                        return relation;
                }
                else
                    return caseRelation;
            }

            // Strings are equal or this string is substring of other instance

            if (m_value.Length == other.Length)
                return 0;
            else
                return -1;
        }

        public override bool Equals(Object other)
        {
            if (other is null)
                throw new ArgumentNullException("Cannot compare MyString to null");

            MyString value = other as MyString;

            if (value is null)
                throw new ArgumentException("Object is not MyString");

            return CompareTo(value) == 0;
        }

        public Char this [int index]
        {
            get { return this.Get(index); }
        } 

        public static bool operator == (MyString a, MyString b)
        {
            return a.Equals(b);
        }

        public static bool operator != (MyString a, MyString b)
        {
            return !a.Equals(b);
        }

        public static bool operator > (MyString a, MyString b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator < (MyString a, MyString b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator >= (MyString a, MyString b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator <= (MyString a, MyString b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static MyString operator + (MyString str, char ch)
        {
            return str.AppendChar(ch);
        }
    }
}
