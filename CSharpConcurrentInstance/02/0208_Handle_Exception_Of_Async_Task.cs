using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcurrentInstance._02
{
    //一般使用try捕获异常
    public class _0208_Handle_Exception_Of_Async_Task
    {
        public static async Task ThrowExceptionAysnc()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            throw new InvalidOperationException("is Test");
        }
        public static async Task TestAsync()
        {
            try
            {
                //只有当Task对象被await调用时，才会引发异常：
                await ThrowExceptionAysnc();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }
    }
}
