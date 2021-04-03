using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcurrentInstance._03
{
    /*
     * Q:需要并行调用一批方法，并且这些方法（大部分）是互相独立的。
     * A:Parallel.Invoke()
     */
    public class _0303_Parallel_Invoke
    {
        public static void ProcessArray(double [] array)
        {
            //支持token取消
            //invoke适用于简单无返回并行
            Parallel.Invoke(() => ProcessPartialArray(array, 0, array.Length / 2),
                () => ProcessPartialArray(array, array.Length / 2, array.Length));
        }

        private static void ProcessPartialArray(double[] array, int begin, int end)
        {
            //some Intensive processing
        }
    }
}
