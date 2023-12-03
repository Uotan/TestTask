using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Tasks;

namespace Unit_Tests
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool result = Program.IsValid2("([{}])");
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            bool result = Program.IsValid2("(){}[]");
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestMethod3()
        {
            bool result = Program.IsValid2("(}");
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestMethod4()
        {
            bool result = Program.IsValid2("[(])");
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestMethod5()
        {
            bool result = Program.IsValid2("[({})](]");
            Assert.AreEqual(false, result); ;
        }
        [TestMethod]
        public void TestMethod6()
        {
            bool result = Program.IsValid2("[()()]");
            Assert.AreEqual(true, result); ;
        }
    }
}
