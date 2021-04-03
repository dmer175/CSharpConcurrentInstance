using CSharpConcurrentInstance;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject2
{
    class _0301_Parallel_Processing_Test
    {
        [Test]
        public void InverMatrices()
        {
            var matrices = new List<Matrix>
            {
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = true },
                new Matrix(){ IsInvertible = false }
            };
            var count = _0301_Parallel_Processing.InverMatrices(matrices);

            Assert.AreEqual(2, count);
        }
        [Test]
        public void InverMatricesNoLock()
        {
            var matrices = new List<Matrix>
            {
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = true },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false },
                new Matrix(){ IsInvertible = false }
            };
            var count = _0301_Parallel_Processing.InverMatricesNoLock(matrices);

            Assert.AreEqual(14, count);
        }
    }
}
