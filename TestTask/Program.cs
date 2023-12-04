﻿using System;
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

        public static string EncodingWithParentheses(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return null;
            }
            data = data.ToLower();
            string result = "";
            List<char> list = new List<char>();
            foreach (char c in data)
            {
                list.Add(c);
            }
            foreach (char c in data) 
            {
                var count = list.Count(x => x == c);
                if (count>1)
                {
                    result += ")";
                }
                else
                {
                    result += "(";
                }
            }

            return result;
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


        /// <summary>
        /// Задание 3, проверка валидности скобок (второй вариант решения)
        /// </summary>
        /// <param name="braces"></param>
        /// <returns></returns>
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
                else if(stack.Count!=0)
                {
                    if ((brace == ')' && stack.ElementAt(0) == '(') ||
                    (brace == '}' && stack.ElementAt(0) == '{') ||
                    (brace == ']' && stack.ElementAt(0) == '['))
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    return false;
                }
            }
            if (stack.Count == 0)
            {
                return true;
            }
            return false;
        }



    }

}
