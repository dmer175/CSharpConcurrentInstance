using NUnit.Framework;
using System;
using System.Threading.Tasks;
using static System.Console;
using Instance = CSharpConcurrentInstance._02._0201_Pause_For_A_While;

namespace NUnitTestProject2
{
    public class _0201_Pause_For_A_While_Test
    {
        //_0201_Pause_For_A_While Instance
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task DelayResultIsSuc()
        {
            WriteLine($"���ÿ�ʼ {DateTime.Now}");
            await Instance.DelayResult<int>(1, new System.TimeSpan(100));
            WriteLine($"���ý��� {DateTime.Now}");
            Assert.Pass();
        }
    }
}