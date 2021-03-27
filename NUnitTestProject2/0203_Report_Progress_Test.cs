using CSharpConcurrentInstance._02;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject2
{
    public class _0203_Report_Progress_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CallMyMethodAsync()
        {
            await _0203_Report_Progress.CallMyMethodAsync();

        }
    }
}
