using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcurrentInstance
{
    /*
     * Q:在并行操作结束时，需要聚合结果，包括累加和、平均值等
     * A:Parallel类通过局部值（local value）的概念来实现聚合，局部值就是只在并行循环内部存在的变量。这意味着循环体中的代码可以直接访问值，不需要担心同步问题
     * 循环中的代码使用LocalFinally委托来对每个局部值进行聚合。需要注意的是，localFinally委托需要以同步的方式对存放结果的变量进行访问。
     */
    public class _0302_Parallel_Aggregation
    {
        public static int ParallelSum(IEnumerable<int> values)
        {
            object mutex = new object();
            int result = 0;
            Parallel.ForEach(values, () => 0, (item, state, localValue) => localValue + item, localValue =>
            {
                lock (mutex)
                {
                    result += localValue;
                }
            });
            return result;

            //或者
            //values.AsParallel().Sum();
        }
    }
}
