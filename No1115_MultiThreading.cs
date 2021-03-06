﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LeetCode_1115
{
    class No1115_MultiThreading
    {
        //static void Main(string[] args)
        //{
        //    var solution = new Solution();
        //    while (true)
        //    {
        //        //int input = int.Parse(Console.ReadLine());
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
        //        //int[] nums1 = new int[] { 10, 1, 2, 7, 6, 1, 5 };
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
        //        //var res = solution.MinimumOperations(input);
        //        //ConsoleX.WriteLine(res);
        //    }
        //}

        /// <summary>
        /// 因为只是单纯的打印，很快就可以输出，所以使用 SpinWait。
        /// </summary>
        public class FooBar
        {
            private int n;
            private SpinWait _spinWait = new SpinWait();
            private int _signal = 0;

            public FooBar(int n)
            {
                this.n = n;
            }

            public void Foo(Action printFoo)
            {

                for (int i = 0; i < n; i++)
                {
                    while (_signal != 0)
                        _spinWait.SpinOnce();

                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();
                    _signal = 1;
                }
            }

            public void Bar(Action printBar)
            {

                for (int i = 0; i < n; i++)
                {
                    while (_signal != 1)
                        _spinWait.SpinOnce();
                    // printBar() outputs "bar". Do not change or remove this line.
                    printBar();
                    _signal = 0;
                }
            }
        }
    }
}
