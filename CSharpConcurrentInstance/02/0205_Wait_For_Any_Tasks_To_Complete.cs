using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcurrentInstance._02
{
    /*
     * Task.WhenAny返回的task对象永远不会以“故障”或“已取消”状态作为结束。该方法的运行结果总是一个Task首先完成。如果这个任务完成时有异常，这个异常也不会传递给Task.WhenAny返回的Task对象。因此，通常需要在Task对象完成后继续使用await。
     * 第一个任务完成后，考虑是否要取消剩下的任务。
     */
    public class _0205_Wait_For_Any_Tasks_To_Complete
    {
        public static async Task<int> FirstRespondingUrlAsync(string urlA,string urlB)
        {
            var httpClient = new HttpClient();

            Task<byte[]> taskA = httpClient.GetByteArrayAsync(urlA);
            Task<byte[]> taskB = httpClient.GetByteArrayAsync(urlB);

            Task<byte[]> completedTask =
                await Task.WhenAny(taskA, taskB);

            byte[] data = await completedTask;
            return data.Length;
        }
    }
}
