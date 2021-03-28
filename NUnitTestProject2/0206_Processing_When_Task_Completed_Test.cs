using StaticClass = CSharpConcurrentInstance._02._0206_Processing_When_Task_Completed;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject2
{
    class _0206_Processing_When_Task_Completed_Test
    {
        [Test]
        public async Task ProcessTasksAsyncV0()
        {
            await StaticClass.ProcessTasksAsyncV0();
        }

        [Test]
        public async Task ProcessTasksAsyncV1()
        {
            await StaticClass.ProcessTasksAsyncV1();
        }
    }
}
