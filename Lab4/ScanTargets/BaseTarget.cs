using System.Collections.Generic;

namespace Lab4
{
    public abstract class BaseTarget
    {
        public abstract IEnumerable<string> MatchAll(string html);
    }
}
