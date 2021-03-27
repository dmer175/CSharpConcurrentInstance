using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcurrentInstance._02
{
    /*
     * 实现一个具有异步签名的同步方法
     * 1.如果从异步接口或基类继承代码，但希望用同步的方法来实现它
     * 2.对异步代码做单元测试，以及用简单的生成方法存根（stub）或者模拟对象（mock）来产生异步接口
     */
    public class _0202_Return_To_Completed_Task
    {

    }

    public class MySyncImpl : IMyAsync
    {
        public Task<int> GetValueAsync()
        {
            return Task.FromResult(13);
        }
    }
    interface IMyAsync
    {
        Task<int> GetValueAsync();
    }
}
