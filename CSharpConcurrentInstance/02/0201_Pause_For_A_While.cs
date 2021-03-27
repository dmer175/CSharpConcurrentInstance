using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpConcurrentInstance._02
{
    /*
     * 1.让程序（以异步方式）等待一段时间。这在进行单元测试或者实现重试延迟时非常有用。
     * 2.本解决方案也能用于实现简单的超时。
     * 3.在模拟一个异步操作时，至少要测试“同步成功”“异步成功”和“异步失败”这三种情况。
     */
    /// <summary>
    /// 暂停一段时间
    /// </summary>
    public class _0201_Pause_For_A_While
    {
        /// <summary>
        /// 此方法用于测试“异步成功”
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static async Task<T> DelayResult<T>(T result,TimeSpan delay)
        {
            await Task.Delay(delay);
            return result;
        }

        /// <summary>
        /// 一个简单的指数退避
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static async Task<string> DownloadStringWithRetries(string uri)
        {
            using (var client=new HttpClient())
            {
                //第一次重试前等1s,2次2s,3次4s
                var nextDelay = TimeSpan.FromSeconds(1);
                for (int i = 0; i < 3; i++)
                {
                    WriteLine($"第{i}次调用");
                    try
                    {
                        return await client.GetStringAsync(uri);
                    }
                    catch 
                    {
                    }
                    await Task.Delay(nextDelay);
                    nextDelay = nextDelay + nextDelay;
                }

                //最后重试一次，让调用者知道出错消息
                return await client.GetStringAsync(uri);
            }
        }
    }
}
