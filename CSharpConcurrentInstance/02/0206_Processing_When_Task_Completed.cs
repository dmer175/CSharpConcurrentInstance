using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcurrentInstance._02
{
    /*
     * 正在await一批任务，希望在每个任务完成时对它做一些处理。另外，希望在任务一完成就立即进行处理，而不需要等待其他任务。
     */
    public class _0206_Processing_When_Task_Completed
    {
        //案例：启动了3个延时任务，然后对每一个进行await。
        public static async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return val;
        }

        public static async Task ProcessTasksAsyncV0()
        {
            //当前 此方法输出2，3，1
            //期望输出1，2，3
            //期望按任务完成的次序进行处理（例如Trace.WriteLine），不必等待其他任务。
            var tasks = new[]
            {
                DelayAndReturnAsync(2),
                DelayAndReturnAsync(3),
                DelayAndReturnAsync(1)
            };

            foreach (var task in tasks)
            {
                var result = await task;
                Console.WriteLine(result);
            }
        }

        //处理方法1
        //重构后的代码并发地执行处理过程，而原始代码是一个接着一个地处理。大多数情况下这不会有什么影响，但如果不允许有这种区别，可考虑使用锁.
        public static async Task ProcessTasksAsyncV1()
        {
            var tasks = new[]
            {
                DelayAndReturnAsync(2),
                DelayAndReturnAsync(3),
                DelayAndReturnAsync(1)
            };

            var processingTasks = tasks.Select(async t =>
            {
                var result = await t;
                Console.WriteLine(result);
            }).ToArray();

            //等待全部处理过程的完成
            await Task.WhenAll(processingTasks);
        }
    }
}
