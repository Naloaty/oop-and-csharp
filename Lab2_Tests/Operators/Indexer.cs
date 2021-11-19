using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_NS;

namespace Operators
{
    [TestClass]
    public class Indexer
    {
        [TestMethod]
        public void Indexer_AliceValue_ReturnsThirdChar()
        {
            MyString str = new MyString("Alice");
            Assert.AreEqual('i', str[2]);
        }
    }
}
