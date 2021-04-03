using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpConcurrentInstance
{
    public static class _0301_Parallel_Processing
    {
        /*
         * Q:有一批数据，需要对每个元素进行相同的操作。该操作是计算密集型的，需要耗费一定的时间。
         * A:Parallel.ForEach()
         */
        /// <summary>
        /// 对每一个矩阵都进行旋转
        /// </summary>
        /// <param name="matrices"></param>
        /// <param name="degrees"></param>
        public static void RotateMatrices(IEnumerable<Matrix> matrices,float degrees)
        {
            Parallel.ForEach(matrices, matrix => matrix.Rotate(degrees));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrices"></param>
        /// <param name="degrees"></param>
        /// <param name="token">用于取消并行循环</param>
        public static void RotateMatrices(IEnumerable<Matrix> matrices, float degrees,CancellationToken token)
        {
            Parallel.ForEach(matrices, new ParallelOptions { CancellationToken = token }, matrix => matrix.Rotate(degrees));
        }
        //注意保护共享状态
        public static int InverMatrices(IEnumerable<Matrix> matrices)
        {
            object mutex = new object();
            int nonInvertibleCount = 0;
            Parallel.ForEach(matrices, matrix =>
            {
                if (!matrix.IsInvertible)
                {
                    lock (mutex)
                    {
                        ++nonInvertibleCount;
                    }
                }
            });
            return nonInvertibleCount;
        }
        public static int InverMatricesNoLock(IEnumerable<Matrix> matrices)
        {
            object mutex = new object();
            int nonInvertibleCount = 0;
            Parallel.ForEach(matrices, matrix =>
            {
                if (!matrix.IsInvertible)
                {
                        ++nonInvertibleCount;
                    Console.WriteLine(nonInvertibleCount);
                }
            });
            return nonInvertibleCount;
        }
    }

    public class Matrix
    {
        public bool IsInvertible { get; set; }

        public void Rotate(float degrees)
        {

        }
    }
}
