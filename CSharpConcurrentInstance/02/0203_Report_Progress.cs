using static System.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcurrentInstance._02
{
    public class _0203_Report_Progress
    {
        /*
         * 异步操作执行的过程中，需要展示操作的进度
         * 解决方案:使用IProgress<T>和Progress<T>类型。编写的async方法需要有IProgress<T>参数，其中T是需要报告的进度类型
         */
        public static async Task MyMethodAsync(IProgress<double> progress = null)
        {
            double percentComplete = 0;
            var done = false;
            while (!done)
            {
                WriteLine($"异步调用时间：{DateTime.Now}");
                await Task.Delay(5000);
                WriteLine($"异步结束时间：{DateTime.Now}");
                done = true;
                //报告进度
                if (progress != null)
                    progress.Report(percentComplete);
            }
        }

        public static async Task CallMyMethodAsync()
        {
            var progress = new Progress<double>();
            progress.ProgressChanged += (sender, args) =>
            {
                if (sender != null)
                    WriteLine($"sender:{sender}");

                WriteLine($"args:{args}");
            };
            await MyMethodAsync(progress);
        }
    }

}
