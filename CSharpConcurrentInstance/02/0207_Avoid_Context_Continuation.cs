using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcurrentInstance._02
{
    public class _0207_Avoid_Context_Continuation
    {
        /*
         * 在默认情况下，一个async方法在被await调用后恢复运行时，会在原来的上下文中运行。如果是UI上下文，并且有大量的async方法在UI上下文中恢复，就会引起性能上的问题。每秒100个左右尚可，但每秒1000个左右就太多了。
         */
        public async Task ResumeOnContextAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            //该方法在同一上下文中恢复
        }

        public async Task ResumeWithoutContextAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            //该方法恢复运行时，会丢弃上下文
            //对于每一个async方法，如果它没有必要恢复到原来的上下文，最好使用ConfigureAwait。
        }
    }
}
