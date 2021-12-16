using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4;
using System;

namespace WebScannerTests
{
    [TestClass]
    public class WebScannerBasic
    {
        [TestMethod]
        public void AddTarget_Null()
        {
            using (WebScanner scanner = new ())
            {
                Assert.ThrowsException<ArgumentNullException>(() => scanner.AddTarget(null));
            }
        }

        [TestMethod]
        public void AddTransport_Null()
        {
            using (WebScanner scanner = new())
            {
                Assert.ThrowsException<ArgumentNullException>(() => scanner.AddTransport(null));
            }
        }

        [TestMethod]
        public void Scan_Null()
        {
            using (WebScanner scanner = new())
            {
                Assert.ThrowsException<ArgumentNullException>(() => scanner.Scan(null));
            }
        }

        [TestMethod]
        public void Scan_ZeroTargets()
        {
            using (WebScanner scanner = new())
            {
                Assert.ThrowsException<InvalidOperationException>(() => scanner.Scan(new Uri("https://test.ru/")));
            }
        }
    }
}
