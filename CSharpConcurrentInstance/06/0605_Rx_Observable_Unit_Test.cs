using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace CSharpConcurrentInstance._06
{
    public class _0605_Rx_Observable_Unit_Test
    {

    }

    public interface IHttpService
    {
        IObservable<string> GetString(string url);
    }
    public class MyTimeoutClass
    {
        private readonly IHttpService httpService;

        public MyTimeoutClass(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        //消耗一个Observable，生成一个Observable
        public IObservable<string> GetStringWithTimeout(string url)
        {
            return httpService.GetString(url).Timeout(TimeSpan.FromSeconds(1));
        }
    }
}
