using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Lab4
{
    public class TargetItem
    {
        public Uri Uri { get; set; }
        public string Title { get; set; }
        public int Depth { get; set; }
        public string[] Values { get; set; }
        public Type Type { get; set; }
    }

    public class WebScanner: IDisposable
    {
        private readonly HashSet<Uri> m_procLinks = new();
        private readonly WebClient m_webClient = new();
        private readonly List<BaseTarget> m_scanTargets = new();
        private readonly List<BaseTransport> m_transports = new();

        private readonly HashSet<string> m_validFileTypes =
            new HashSet<string> {"", ".htm", ".html"};

        // Scanner settings
        private int m_pageLimit = 100;
        private int m_depthLimit = 5;

        // Scanning state
        private bool m_running = false;

        // On target found event
        private event Action<TargetItem> TargetFound;

        public WebScanner() { }

        public WebScanner(int pageLimit, int depthLimit)
        {
            m_pageLimit = pageLimit;
            m_depthLimit = depthLimit;
        }

        private void OnTargetFound(TargetItem target)
        {
            TargetFound?.Invoke(target);
        }

        private void ProcessPage(string domain, Uri page, string title, int depth)
        {
            if (depth >= m_depthLimit) return;
            if (m_procLinks.Count() >= m_pageLimit) return;

            if (m_procLinks.Contains(page)) return;
            m_procLinks.Add(page);

            string html = m_webClient.DownloadString(page);

            if (string.IsNullOrEmpty(title))
            {
                string titlePattern = @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>";
                title = Regex.Match(html, titlePattern, RegexOptions.IgnoreCase).Groups[1].Value;
            }

            foreach(var target in m_scanTargets)
            {
                var matches = target.MatchAll(html).ToArray();

                if (matches.Length > 0)
                {
                    OnTargetFound(new TargetItem
                    {
                        Uri = page,
                        Title = title,
                        Depth = depth,
                        Values = matches,
                        Type = target.GetType()
                    });
                }
            }

            string linkPattern = "<a.*?href=\"(.*?)\".*?>(.*?)</a>";

            var links = from link in Regex.Matches(html, linkPattern).Cast<Match>()
                        let url = link.Groups[1].Value
                        let caption = link.Groups[2].Value
                        let local = url.StartsWith("/")
                        let sameDomain = url.StartsWith(domain)
                        where local || sameDomain
                        select new
                        {
                            Uri = new Uri(local ? $"{domain}{url}" : url),
                            Title = caption
                        };

            foreach(var link in links.ToList())
            {
                string fileType = Path.GetExtension(link.Uri.LocalPath).ToLower();
                if (!m_validFileTypes.Contains(fileType)) continue;
                if (!link.Uri.AbsolutePath.StartsWith(page.AbsolutePath)) continue;

                string linkTitle = link.Title;

                // Fallback in case of non-standard <a> link
                if (Regex.Match(link.Title, @"[<>/\\]").Length > 0)
                    linkTitle = "";

                ProcessPage(domain, link.Uri, linkTitle, depth + 1);
            }
        }

        public void AddTarget(BaseTarget scanTarget)
        {
            if (scanTarget is null)
                throw new ArgumentNullException(nameof(scanTarget), "Scan target cannot be null");

            m_scanTargets.Add(scanTarget);
        }

        public void AddTransport(BaseTransport transport)
        {
            if (transport is null)
                throw new ArgumentNullException(nameof(transport), "Transport cannot be null");

            TargetFound += transport.ProcessTargetItem;
            m_transports.Add(transport);
        }

        public void Scan(Uri startPage)
        {
            if (startPage is null)
                throw new ArgumentNullException(nameof(startPage), "Start page cannot be null.");

            if (m_scanTargets.Count == 0)
                throw new InvalidOperationException("No scan targets are specified for WebScanner.");

            if (m_running)
                throw new InvalidOperationException("WebScanner is already running.");


            m_procLinks.Clear();
            m_running = true;

            ProcessPage($"{startPage.Scheme}://{startPage.Host}", startPage, "", 0);

            foreach (var transport in m_transports)
                transport.WorkDone();

            m_running = false;
        }

        public void Dispose()
        {
            m_webClient.Dispose();

            foreach (var transport in m_transports)
                transport.Dispose();
        }
    }
}
