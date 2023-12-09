using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tasks;
using TestTask.Classes;

namespace Unit_Tests
{
    [TestClass]
    public class UnitTest2
    {
        PaginationHelper<string> helper;
        
        void FillCollection()
        {
            //создадим коллекцию строк, где каждая строка будет имет вид number_1, number_2 и т.д. до 17
            ICollection<string> collection = new List<string>();
            for (int i = 1; i <= 17; i++)
            { 
                collection.Add("number_"+i.ToString());
            }
            //количество элементов на странице будет 5, должно быть 4 страницы с данными
            helper = new PaginationHelper<string>(collection, 5);
        }

        [TestMethod]
        public void TestGetCountOfData()
        {
            FillCollection();
            int result = helper.GetCountOfData();
            Assert.AreEqual(17, result);
        }

        [TestMethod]
        public void TestGetPageCount()
        {
            FillCollection();
            int result = helper.GetPageCount();
            Console.WriteLine(result);
            Assert.AreEqual(4, result);
        }


        [TestMethod]
        public void TestGetCountOfElementsOnPage()
        {
            FillCollection();
            //с учетом нумерации от нуля отправим индекс последней страницы
            int result = helper.GetCountOfElementsOnPage(3);
            Console.WriteLine(result);
            Assert.AreEqual(2, result);
        }


        [TestMethod]
        public void TestGetIndexOfPage()
        {
            FillCollection();
            int result = helper.GetIndexOfPage(14);
            Console.WriteLine(result);
            Assert.AreEqual(3, result);
        }
    }
}
