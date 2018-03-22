using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PooVueling;
using Xunit;

namespace PooVuelingXunitTests
{
    public class CalculadoraXunitTests
    {
        ICalculadora iCalculadora = new Calculadora();

        [Fact]
        public void DivisionTest()
        {
            Assert.Equal(4, iCalculadora.Suma(2, 2));
        }

        [Fact]
        public void MultiplicacionTest()
        {
            Assert.True(iCalculadora.Multiplicacion(3, 6) == 18);
        }

        [Fact]
        public void RestaTest()
        {
            Assert.False(iCalculadora.Resta(5, 3) == 10);
        }

        [Fact]
        public void SumaTest()
        {
            Assert.False(iCalculadora.Suma(2, 2) == 6);
        }

    }
}
