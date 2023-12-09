using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Classes
{
    public class PaginationHelper<T>
    {
        private readonly ICollection<T> _data;
        public readonly int _pageSize;
        private readonly int _countOfPages;

        /// <summary>
        /// Утилита для пагинации
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pageSize"></param>
        public PaginationHelper(ICollection<T> data, int pageSize)
        {
            _data = data;
            _pageSize = pageSize;
            if ((_data.Count % pageSize)>0)
            {
                _countOfPages = (_data.Count / pageSize)+1;
            }
            else
            {
                _countOfPages = (_data.Count / pageSize);
            }
        }

        /// <summary>
        /// Получает количество данных в массиве
        /// </summary>
        /// <returns></returns>
        public int GetCountOfData()
        {
            return _data.Count;
        }

        /// <summary>
        /// Получает количество страниц
        /// </summary>
        /// <returns></returns>
        public int GetPageCount()
        {
            return _countOfPages;
        }


        /// <summary>
        /// Получает колическо элементов на указанной странице
        /// </summary>
        /// <param name="pagenumber">Номер страницы (начинается с нуля)</param>
        /// <returns></returns>
        public int GetCountOfElementsOnPage(int pageNumber)
        {
            // было бы гораздо короче, если использовать _pageSize, но на половину сделаем вид, что не знаем количество элементов на странице
            pageNumber++;
            if (pageNumber>_countOfPages)
            {
                return 0;
            }
            if (pageNumber==1)
            {
                return pageNumber * _pageSize;
            }
            else if(pageNumber==_countOfPages)
            {
                return _data.Count() - ((pageNumber - 1) * _pageSize);
            }
            else
            {
                return pageNumber * _pageSize - (pageNumber - 1) * _pageSize;
            }
        }

        /// <summary>
        /// Получает номер страницы, по индексу элемента массива данных
        /// </summary>
        /// <param name="itemIndex">Индекс элмента данных</param>
        /// <returns></returns>
        public int GetIndexOfPage(int itemIndex)
        {
            if (itemIndex>_data.Count)
            {
                return 0;
            }
            int pageIndex = itemIndex / _pageSize;
            if ((itemIndex % _pageSize)!=0)
            {
                pageIndex++;
            }
            return pageIndex;
        }
    }
}
