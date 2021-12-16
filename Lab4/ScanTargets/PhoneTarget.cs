using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab4
{
    public class PhoneTarget : BaseTarget
    {
        // ======================================================================================================
        // | Please note that this implementation of phone numbers search is not perfect and could be done      |
        // | much better. However, in the context of this practical work, this solution is quite acceptable.    |
        // ======================================================================================================

        private static readonly string m_phonePattern = @"(?<=^|\s|>|\;|\:|\))(?:\+|7|8|9|\()[\d\-\(\) ]{8,}\d";
        private readonly HashSet<string> m_procPhones = new();

        // Prevents the same phone number to appear on two different pages 
        private bool m_filterRepeats;

        // Converts phone numbers to one format   
        private bool m_reformatNumbers;

        // Only accepts phone numbers containing certain sequence of characters: '(ddd)'
        private bool m_strictValidation;

        public PhoneTarget(bool filterRepeats = false, bool reformatNumbers = false, bool strictValidation = false)
        {
            m_filterRepeats = filterRepeats;
            m_reformatNumbers = reformatNumbers;
            m_strictValidation = strictValidation;
        }

        public override IEnumerable<string> MatchAll(string html)
        {
            var phoneNumbers = from match in Regex.Matches(html, m_phonePattern).Cast<Match>()
                               select match.Value;

            if (m_strictValidation)
            {
                phoneNumbers = from number in phoneNumbers
                               where Regex.Match(number, @"\(\d{3}\)").Length > 0
                               select number;
            }

            List<string> result = new();

            foreach(var n in phoneNumbers.Distinct())
            {
                string clean = Regex.Replace(n, @"[\(\)\-\+ ]", "");

                if (m_filterRepeats && m_procPhones.Contains(clean))
                    continue;

                string number = n;

                if (m_reformatNumbers)
                {
                    switch (clean.Length)
                    {
                        case 11:
                            number = Regex.Replace(clean, @"(\d)(\d{3})(\d{3})(\d{2})(\d{2})", "$1($2)$3-$4-$5");
                            break;

                        case 10:
                            number = Regex.Replace(clean, @"(\d{3})(\d{3})(\d{2})(\d{2})", "7($1)$2-$3-$4");
                            break;

                        default:
                            continue;
                    }
                }

                result.Add(number);

                if (m_filterRepeats)
                    m_procPhones.Add(clean);
            }

            return result;
        }
    }
}
