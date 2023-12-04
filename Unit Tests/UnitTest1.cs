using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tasks;

namespace Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string result = Program.EncodingWithParentheses("din");
            Console.WriteLine(result);
            Assert.AreEqual("(((", result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string result = Program.EncodingWithParentheses("Success");
            Console.WriteLine(result);
            Assert.AreEqual(")())())", result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string result = Program.EncodingWithParentheses("pip");
            Console.WriteLine(result);
            Assert.AreEqual(")()", result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string result = Program.EncodingWithParentheses("((@");
            Console.WriteLine(result);
            Assert.AreEqual("))(", result);
        }


    }
}
