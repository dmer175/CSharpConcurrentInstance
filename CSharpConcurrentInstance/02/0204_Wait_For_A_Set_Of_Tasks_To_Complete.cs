using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcurrentInstance._02
{
    public class _0204_Wait_For_A_Set_Of_Tasks_To_Complete
    {

        /// <summary>
        /// 执行几个任务，等待它们全部完成
        /// </summary>
        /// <param name="urls"></param>
        /// <returns></returns>
        public static async Task<string> DownloadAllAsync(IEnumerable<string> urls)
        {
            var httpClient = new HttpClient();

            //此时只是注册异步行为，尚未开始操作
            var downloads = urls.Select(url => httpClient.GetStringAsync(url));

            //在这里开始同步开始下载
            Task<string>[] downloadTasks = downloads.ToArray();
            //在这里所有任务开始执行
            string[] htmlPages = await Task.WhenAll(downloadTasks);

            return string.Concat(htmlPages);

        }

        /*
         * 如果有一个任务抛出异常，则Task.WhenAll会出错，并把这个异常放在返回的Task中。如果多个任务抛出异常，则这些异常都会放在返回 的Task中。但是，如果这个Task在被await调用，就只会抛出其中的一个异常。如果要得到每个异常，可以检查Task.WhenAll返回的Task的  Exception属性
         */
        public static async Task ThrowNotImplExceptionAsync()
        {
            throw new NotImplementedException();
        }
        public static async Task ThrowInvalidOperationExceptionAsync()
        {
            throw new InvalidOperationException();
        }
        ///
        public static async Task ObserveOneExceptionAsync()
        {
            var task1 = ThrowNotImplExceptionAsync();
            var task2 = ThrowInvalidOperationExceptionAsync();

            try
            {
                await Task.WhenAll(task1, task2);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task ObserveAllExceptionsAsync()
        {
            var task1 = ThrowNotImplExceptionAsync();
            var task2 = ThrowInvalidOperationExceptionAsync();
            var allTasks = Task.WhenAll(task1, task2);
            try
            {
                await allTasks;
            }
            catch (Exception ex)
            {
                AggregateException allExceptions = allTasks.Exception;
                throw allExceptions;
            }
        }
    }
}
