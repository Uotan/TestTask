using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public static class Program
    {

        static void Main(string[] args)
        {
            var result = IsValid2("([{}])");
            Console.WriteLine(result);
            Console.ReadKey();
        }



        /// <summary>
        /// Задание 3, проверка валидности скобок
        /// </summary>
        /// <param name="braces"></param>
        /// <returns></returns>
        public static bool IsValid(string braces)
        {
            if (string.IsNullOrEmpty(braces))
            {
                return false;
            }


            Dictionary<char, char> keyValuePairs = new Dictionary<char, char>()
            {
                {'{', '}' },
                {'(', ')' },
                {'[', ']' },
            };

            Stack<char> stack = new Stack<char>();
            foreach (char brace in braces)
            {
                if (keyValuePairs.ContainsKey(brace))
                {
                    stack.Push(brace);
                }
                else if (!keyValuePairs.ContainsValue(brace))
                {
                    continue;
                }
                else if (stack.Count == 0)
                {
                    return false;
                }
                else if (keyValuePairs[stack.Pop()] != brace)
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }

        public static bool IsValid2(string braces)
        {
            if (String.IsNullOrEmpty(braces))
            {
                return false;
            }
            Stack<char> stack = new Stack<char>();

            //словарь не нужен
            Dictionary<char, char> keyValuePairs = new Dictionary<char, char>()
            {
                {'{', '}' },
                {'(', ')' },
                {'[', ']' },
            };
            foreach (var brace in braces)
            {
                if (keyValuePairs.ContainsKey(brace))
                {
                    stack.Push((char)brace);
                }
                else if(
                    (brace == ')' && stack.ElementAt(0)=='(')||
                    (brace == '}' && stack.ElementAt(0) == '{') ||
                    (brace == ']' && stack.ElementAt(0) == '[')
                    )
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
                
            }

            return true;
        }



    }

}
