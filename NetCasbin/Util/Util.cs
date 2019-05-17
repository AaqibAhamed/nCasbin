﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NetCasbin
{
    public static class Util
    {
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        /// <summary>
        /// 删除文本中#开头的注释
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String RemoveComments(String s)
        {
            int pos = s.IndexOf("#");
            if (pos == -1)
            {
                return s;
            }
            return s.Substring(0, pos).Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string EscapeAssertion(string s)
        {
            // 替换第一个点
            if (s.StartsWith("r") || s.StartsWith("p"))
            {
                s = s.ReplaceFirst(@".", "_");
            }
            String regex = "(\\|| |=|\\)|\\(|&|<|>|,|\\+|-|!|\\*|\\/)(r|p)\\.";
            Regex p = new Regex(regex);
            var matches = p.Matches(s);
            StringBuilder sb = new StringBuilder(s);

            for (int i = 0, j = matches.Count; i < j; i++)
            {
                var match = matches[i];
                string replace = match.Groups[0].Value.Replace(".", "_");
                if (replace.Trim().Length > 0)
                {
                    sb.Replace(match.Value, replace, match.Index, match.Length);
                }
            }
            return sb.ToString();
        }

        internal static string ArrayToString(string[] v)
        {
            throw new NotImplementedException();
        }

        public static Boolean ArrayEquals(List<String> a, List<String> b)
        {
            if (a == null)
            {
                a = new List<string>();
            }
            if (b == null)
            {
                b = new List<string>();
            }
            if (a.Count != b.Count)
            {
                return false;
            }

            for (int i = 0; i < a.Count; i++)
            {
                if (!a[i].Equals(b[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static Boolean Array2DEquals(List<List<String>> a, List<List<String>> b)
        {
            if (a == null)
            {
                a = new List<List<string>>();
            }
            if (b == null)
            {
                b = new List<List<string>>();
            }
            if (a.Count != b.Count)
            {
                return false;
            }

            for (int i = 0; i < a.Count; i++)
            {
                if (!ArrayEquals(a[i], b[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static Boolean ArrayRemoveDuplicates(List<String> s)
        {
            return true;
        }

        public static String ArrayToString(List<String> s)
        {
            return String.Join(", ", s);
        }

        public static String ParamsToString(String[] s)
        {
            return String.Join(", ", s);
        }

        public static Boolean SetEquals(List<String> a, List<String> b)
        {
            if (a == null)
            {
                a = new List<string>();
            }
            if (b == null)
            {
                b = new List<string>();
            }
            if (a.Count != b.Count)
            {
                return false;
            }

            a.Sort();
            b.Sort();

            for (int i = 0; i < a.Count; i++)
            {
                if (!a[i].Equals(b[i]))
                {
                    return false;
                }
            }
            return true;
        }

        internal static void LogPrint(string v)
        {
            throw new NotImplementedException();
        }
    }
}
