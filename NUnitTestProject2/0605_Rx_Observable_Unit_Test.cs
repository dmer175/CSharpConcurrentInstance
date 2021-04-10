using CSharpConcurrentInstance._06;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject2
{
    class SuccessHttpServiceStub : IHttpService
    {
        public IObservable<string> GetString(string url)
        {
            return Observable.Return("stub");
        }
    }

    class FailureHttpServiceStub : IHttpService
    {
        public IObservable<string> GetString(string url)
        {
            return Observable.Throw<string>(new HttpRequestException());
        }
    }

    class _0605_Rx_Observable_Unit_Test
    {
        [Test]
public async Task MyTimeoutClass_SuccessfulGet_ReturnsResult()
        {
            var stub = new SuccessHttpServiceStub();
            var my = new MyTimeoutClass(stub);

            var result = await my.GetStringWithTimeout("http://example.com/").SingleAsync();

            Assert.AreEqual("stub", result);
        }

        [Test]
        public async Task MyTimeoutClass_FailedGet_PropagatesFailure()
        {
            var stub = new SuccessHttpServiceStub();
            var my = new MyTimeoutClass(stub);

            await ThrowsExceptionAsync<HttpRequestException>(async () =>
            {
                await my.GetStringWithTimeout("http://example.com/").SingleAsync();
            });
        }

        /// <summary>
        /// 确保一个异步委托抛出异常
        /// </summary>
        /// <typeparam name="T">预计类型</typeparam>
        /// <param name="action">被测试的异步委托</param>
        /// <param name="allowDerivedTypes">是否接受派生的类</param>
        /// <returns></returns>
        private async Task ThrowsExceptionAsync<T>(Func<Task> action, bool allowDerivedTypes = true)
        {
            try
            {
                await action();
                Assert.Fail("Delegate did not throw expected " + typeof(T).Name + ".");
            }
            catch (Exception ex)
            {
                if (allowDerivedTypes&&!(ex is T))
                {
                    Assert.Fail("Delegate threw exception of type " + ex.GetType().Name + ", but " + typeof(T).Name + " or a derived type was expected .");
                    if (!allowDerivedTypes&& ex.GetType()!=typeof(T))
                    {
                        Assert.Fail("Delegate threw exception of type " + ex.GetType().Name + ",but " + typeof(T).Name + " was expected.");
                    }
                }
                throw;
            }
        }
    }
}
