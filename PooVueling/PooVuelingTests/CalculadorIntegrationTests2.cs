using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PooVueling.Tests
{
    [TestClass()]
    public class CalculadoraIntegrationTests2
    {
        ICalculadora iCalculadora = new Calculadora();

        [DataRow(4,2,2)]
        [DataRow(9,3,3)]
        [DataRow(0,4,0)]
        [DataTestMethod]
        public void DivisionTest2(int num1, int num2, int resultado)
        {
            Assert.IsTrue(iCalculadora.Division(num1, num2) == resultado);
        }

        /*
        [DataRow(4,0, ExpectedException(typeof(DivideByZeroException)))]
        [DataTestMethod]
        public void DivisionTest2Fail(int num1, int num2, int resultado)
        {
            Assert.IsTrue(iCalculadora.Division(num1, num2) == resultado);
        }
        */

        [DataRow(4,2,8)]
        [DataRow(6,3,18)]
        [DataRow(-1,12,-12)]
        [DataRow(-2,-2,4)]
        [DataTestMethod]
        public void MultiplicacionTest2(int num1, int num2, int resultado)
        {
            Assert.IsTrue(iCalculadora.Multiplicacion(num1, num2) == resultado);
        }

        [DataRow(10,4,6)]
        [DataRow(5,-5,10)]
        [DataRow(-3,-5,2)]
        [DataTestMethod]
        public void RestaTest2(int num1, int num2, int resultado)
        {
            Assert.IsTrue(iCalculadora.Resta(num1, num2) == resultado);
        }

        [DataRow(2,2,4)]
        [DataRow(3,-1,2)]
        [DataRow(-4,-3,-7)]
        [DataTestMethod]
        public void SumaTest2(int num1, int num2, int resultado)
        {
            Assert.IsTrue(iCalculadora.Suma(num1, num2) == resultado);
        }
    }
}
