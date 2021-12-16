using System;
using System.IO;
using System.Text;

namespace Lab4
{
    public class CsvTransport : BaseTransport
    {
        private readonly FileStream m_fs;
        private readonly TextWriter m_csv;

        // Table settings
        private bool m_saveTitleAsTree;

        public CsvTransport(string filename, bool saveTitleAsTree = false)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException(nameof(filename), "Filename cannot be empty or null.");

            m_fs = File.Create(filename);
            m_csv = new StreamWriter(m_fs, Encoding.UTF8);

            m_saveTitleAsTree = saveTitleAsTree;

            string col_0 = "URL";
            string col_1 = "Name";
            string col_2 = "Depth";
            string col_3 = "Value";

            string header = string.Format("{0},{1},{2},{3}", col_0, col_1, col_2, col_3);
            m_csv.WriteLine(header);
        }

        public override void ProcessTargetItem(TargetItem item)
        {
            foreach(var val in item.Values)
            {
                string url = Escape(item.Uri.AbsoluteUri);
                string name = Escape(m_saveTitleAsTree ? Indent(item.Title, item.Depth) : item.Title);
                string value = Escape(val);

                string record = string.Format("{0},{1},{2},{3}", url, name, item.Depth, value);
                m_csv.WriteLine(record);
            }
        }

        private static string Indent(string str, int count)
        {
            string indent = "";

            for (int i = 0; i < count; i++)
                indent += "|--";

            indent += str;
            return indent;
        }

        private static string Escape(string str)
        {
            return $"\"{str}\"";
        }

        public override void WorkDone()
        {
            m_csv.Flush();
        }

        public override void Dispose()
        {
            m_csv.Dispose();
            m_fs.Dispose();
        }

    }
}
