using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab4
{
    public class AddressTarget : BaseTarget
    {
        // ==============================================================================================
        // | Please note that it's IMPOSSIBLE to write a regular expression to match a street address!  |
        // ==============================================================================================

        private static readonly string m_addressPatern = ">(?:.*)Адрес: (.+)(?:.*)<";
        public override IEnumerable<string> MatchAll(string html)
        {
            var addresses = from match in Regex.Matches(html, m_addressPatern).Cast<Match>()
                            select match.Groups[1].Value.Trim();

            return addresses.Distinct();
        }
    }
}
