﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_22
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int input3 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        //string input = "abcbefga";
    //        //string input2 = "dbefga";
    //        //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
    //        //int[] nums3 = new int[] { 10, 15, 20 };
    //        //int[] nums1 = new int[] { 1, 1, 1, 2, 2, 3 };
    //        //IList<IList<int>> data = new List<IList<int>>()
    //        //{
    //        //    new List<int>() { 1, 3 },
    //        //    new List<int>() { 3, 0, 1 },
    //        //    new List<int>() { 2 },
    //        //    new List<int>() { 0 }

    //        //    //new List<int>() { 1 },
    //        //    //new List<int>() { 2 },
    //        //    //new List<int>() { 3 },
    //        //    //new List<int>() {  }
    //        //};
    //        var res = solution.GenerateParenthesis(input);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 回溯法（这个和深度优先感觉很像，leetcode的说明里有一个说的很好：“回溯算法的基本思想是：从一条路往前走，能进则进，不能进则退回来，换一条路再试。”）
        /// 时间复杂度：O(4ⁿ/Sqrt(n))，官方题解推导出的是卡特兰数的时间复杂度，这个我真不知道怎么算的，我只有个大概范围的概念
        /// 空间复杂度：O(n),最大深度 2n,因为括号是左右两个
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            if (n <= 0)
                return new List<string>();

            IList<string> res = new List<string>();
            //左括号当前总数，左括号（Left Parenthesis）
            int leftParenthesisCount = 0;
            //左括号剩余个数
            int leftLeftCount = n;
            //右括号剩余个数
            int rightLeftCount = n;
            Recurse(leftLeftCount, rightLeftCount, leftParenthesisCount, string.Empty);
            return res;

            void Recurse(int llc, int rlc, int lpc, string s)
            {
                //如果左右括号计数小于0，或者右括号多于左括号，则为不合法，直接返回
                if (llc < 0 || rlc < 0 || lpc < 0)
                    return;
                if (llc == 0 && rlc == 0)
                    res.Add(s);
                Recurse(llc - 1, rlc, lpc + 1, s + "(");
                Recurse(llc, rlc - 1, lpc - 1, s + ")");
            }
        }
    }
}
