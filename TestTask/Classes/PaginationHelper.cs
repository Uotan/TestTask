using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Classes
{
    public class PaginationHelper
    {
        private readonly List<string> _data;
        private readonly int _pageSize;
        private readonly int _countOfPages;
        public PaginationHelper(List<string> data, int pageSize)
        {
            _data = data;
            _pageSize = pageSize;
            _countOfPages = (int)_data.Count / _pageSize;
        }
        public int GetCountOfData()
        {
            return _data.Count;
        }
        public int GetPageCount()
        {
            return _countOfPages;
        }
        public int GetCountOfElementsOnPage(int pageNumber)
        {
            if (pageNumber<=(_countOfPages-1))
            {
                return _pageSize;
            }
            else
            {
                return 0;
            }
        }
        public int GetIndexOfPage(int itemIndex)
        {
            return itemIndex / _pageSize;
        }
    }
}
