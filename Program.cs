﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            while (true)
            {
                //int input = int.Parse(Console.ReadLine());
                //int input2 = int.Parse(Console.ReadLine());
                //int input3 = int.Parse(Console.ReadLine());
                string input = Console.ReadLine();
                ////string input2 = Console.ReadLine();
                int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //int[] intArr = new int[] { -1, 0, 1, 2, -1, -4 };
                //int[] intArr = new int[] { -2, -1, -1, 0, 1, 1, 2 };
                //int[] intArr = new int[] { -2, 0, 1, 1, 2 };
                var res = solution.ThreeSum(intArr);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 期望用Dictionary来加快速度，结果不行，哈哈哈
            /// 时间复杂度：O(n²),但是内存循环内还有一个答案的去重，也会影响性能
            /// 空间复杂度：O(n),一个dictionary
            /// 结果还是超时。。。其实已经从n³尽力减到n²了
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                IList<IList<int>> res = new List<IList<int>>();
                //1.构建一个dictionary，key存数，value存个数。先把数组装进去。
                Dictionary<int, int> dic = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (dic.ContainsKey(nums[i]))
                        dic[nums[i]]++;
                    else
                        dic.Add(nums[i], 1);
                }
                //2.遍历dictionary，两层循环，再加一个dictionary查找
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        int diff = 0 - nums[i] - nums[j];
                        //因为使用了num[i]和nums[j],所以暂时dic中计数减一
                        dic[nums[i]]--;
                        dic[nums[j]]--;
                        if (dic.ContainsKey(diff) && dic[diff] > 0)
                        {
                            var arr = new int[] { nums[i], nums[j], diff };
                            Array.Sort(arr);
                            if (!res.Any(s => s[0] == arr[0] && s[1] == arr[1] && s[2] == arr[2]))
                                res.Add(arr);
                        }
                        dic[nums[i]]++;
                        dic[nums[j]]++;
                    }
                    //遍历完一个数之后，从dic中计数减一
                    dic[nums[i]]--;
                }
                return res;
            }
        }
    }
}