using StaticClass = CSharpConcurrentInstance._02._0204_Wait_For_A_Set_Of_Tasks_To_Complete;
using CSharpConcurrentInstance._02;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject2
{
    public class _0204_Wait_For_A_Set_Of_Tasks_To_Complete_Test
    {
        /*
         * 遇到问题：“NotImplementedException”未包含“GetAwaiter”的定义，并且找不到可接受第一个“NotImplementedException”类型参数的可访问扩展方法“GetAwaiter”(是否缺少 using 指令或程序集引用?)
         * 通过与eshop代码比较，是Assert.ThrowsAsync<NotImplementedException>()的返回值是NotImplementedException而不是Task<NotImplementedException>，所以不能使用await，直接执行即可
         */
        [Test]
        public void ObserveOneExceptionAsync()
        {
            Assert.ThrowsAsync<NotImplementedException>(async () =>
             {
                 await StaticClass.ObserveOneExceptionAsync();
             });
        }
        [Test]
        public void ObserveAllExceptionsAsync()
        {
            Assert.ThrowsAsync<AggregateException>(async () =>
            {
                await StaticClass.ObserveAllExceptionsAsync();
            });
        }
    }
}
