﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_101
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
    //        //int[] intArr = new int[] { 1, 3, 2 };
    //        //int[] intArr = new int[] { 1, 3 };
    //        TreeNode tn1 = new TreeNode(1);
    //        var res = solution.IsSymmetric(tn1);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 迭代
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)，实际小于n次，因为中途可能会直接返回false了
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;
            return IsSymmetricTree(root.left, root.right);
        }

        private bool IsSymmetricTree(TreeNode left, TreeNode right)
        {
            IEnumerable<TreeNode> data = new TreeNode[] { left, right };
            Queue<TreeNode> queue = new Queue<TreeNode>(data);
            while (queue.Count > 0)
            {
                left = queue.Dequeue();
                right = queue.Dequeue();
                if (left == null && right == null)
                    continue;
                if (left == null || right == null || left.val != right.val)
                    return false;

                queue.Enqueue(left.left);
                queue.Enqueue(right.right);

                queue.Enqueue(left.right);
                queue.Enqueue(right.left);
            }
            return true;
        }

        /// <summary>
        /// 递归
        /// 时间复杂度：O(n)
        /// 空间复杂度：最优O(Logn)，最差O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        //public bool IsSymmetric(TreeNode root)
        //{
        //    if (root == null)
        //        return true;
        //    return IsSymmetricTree(root.left, root.right);
        //}

        //private bool IsSymmetricTree(TreeNode p, TreeNode q)
        //{
        //    if (p == null && q == null)
        //        return true;
        //    else if (p == null || q == null || p.val != q.val)
        //        return false;
        //    else
        //        return IsSymmetricTree(p.left, q.right) && IsSymmetricTree(p.right, q.left);
        //}
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
