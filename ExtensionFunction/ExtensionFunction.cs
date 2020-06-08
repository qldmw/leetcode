﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Extension
{
    /// <summary>
    /// Experience：
    /// 1.[]是IList的方法。
    /// 2.Count是ICollection的方法。
    /// 3.遍历（可不可以foreach）是IEnumerable的方法。
    /// 4.List 和 Array（就是int[]这种）都实现了IList, IEnumerable, ICollection，继承关系大概总结为 IList > ICollection > IEnumerable。
    /// 5.List<T>可以转为IList<T>，是因为List实现了IList;List<List<T>>不能转化为IList<IList<T>>，是因为List<T>的泛型参数不支持协变(Covariance)和逆变(Contravariance)，
    ///   支持协变的IEnumerable接口就可以完成这个转换，IEnumerable<List<T>>就可以转换为IEnumerable<IList<T>>。
    /// 6.对于协变和逆变的个人总结：
    ///   协变:子类可以变为父类的这个过程，比如List实现了IList，IList实现了IEnumerable，这种可以变过去。但是IList不能变成List，因为实现IList的
    ///        不只有一种类型，可能是List，但也可能是Array，还可能是其他的，这样编译器就不能确定，所以不能转换。
    ///   逆变:父类变为某个子类，但是因为编译器是不知道你要做什么的，所以要你去实现这个过程，到底要怎么做。但是ICompare之类的接口是天然支持逆变的，可能因为对于比较来说，类型
    ///        变化始终如一吧？
    /// </summary>
    public static class ConsoleX
    {
        /// <summary>
        /// 打印数组（支持一维和二维）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public static void WriteLine<T>(T arr) where T : IEnumerable
        {
            //通过第一个儿子确定是一维还是二维的
            if (IsChildEnumerable(arr))
            {
                foreach (var m in arr)
                {
                    IEnumerable IEnum = m as IEnumerable;
                    WriteLineBase(IEnum);
                }
            }
            else
            {
                WriteLineBase(arr);
            }
        }

        /// <summary>
        /// 是否是二维数组（指两层 交错数组 和 嵌套IEnumerable），通过遍历儿子是否是IEnumerable来确定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static bool IsChildEnumerable<T>(T arr) where T : IEnumerable
        {
            if (arr == null)
                return false;

            bool isEnum = false;
            foreach (var m in arr)
            {
                if (m is IEnumerable)
                {
                    isEnum = true;
                    break;
                }
            }
            return isEnum;
        }

        /// <summary>
        /// 打印数组的具体方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        private static void WriteLineBase<T>(T arr) where T : IEnumerable
        {
            string str = "[";
            //类型实现了IEnumerate不等于就有值
            if (arr != null)
            {
                foreach (var m in arr)
                {
                    str += $"{m},";
                }
            }
            str = str.TrimEnd(',') + "]";
            Console.WriteLine(str);
        }
    }
}
