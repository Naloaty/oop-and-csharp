using System;

namespace Lab4
{
    public class ConsoleTransport : BaseTransport
    {
        private string m_previousTitle = "";

        public override void ProcessTargetItem(TargetItem item)
        {
            if (m_previousTitle != item.Title)
            {
                m_previousTitle = item.Title;

                WriteIndent(item.Depth);
                Console.WriteLine($"({item.Depth}) {item.Title}");
            }

            foreach (var value in item.Values)
            {
                WriteIndent(item.Depth + 1);
                Console.WriteLine($"{value}");
            }
        }

        private static void WriteIndent(int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write("│   ");
        }
    }
}
