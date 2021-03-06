﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_44
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 1, 2, 5, 3, 4, null, 6 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        //int[] nums1 = new int[] { 2, 1, -2, 3 };
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "adceb";
    //        //string input2 = "*a*b";
    //        var res = solution.IsMatch(input, input2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// REDO
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// 动态规划，和第10题一个模子，是很好的分析状态转移的题目
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(n²)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {
            bool[,] dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;
            for (int i = 1; i <= p.Length; i++)
            {
                //把开头的 * 对应的状态都置为 true, 因为 * 可以对应空字符串
                if (p[i - 1] == '*')
                    dp[0, i] = true;
                else
                    break;
            }
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    if (p[j - 1] == '*')
                        dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
                    else if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                }
            }
            return dp[s.Length, p.Length];
        }
    }
}
