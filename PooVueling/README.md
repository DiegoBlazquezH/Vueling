# Calculadora, proyecto inicial de C# y tests

Este proyecto es una primera toma de contacto con C# y las labores de testing. Esta dividido en tres proyectos:

* PooVueling contiene la Calculadora, que implementa la interfaz ICalculadora. Esta tiene 4 métodos (suma, resta, multiplicación, división).

* PooVuelingTests contiene el código para realizar los tests con MSTestv2. Se han implementado un test sencillo por cada método a modo de prueba. Estos tests son llamados a través de la opción Pruebas->Ejecutar->Todas las pruebas. Hay que remarcar la utilización de los custom attributes [Test(Class)] y [TestMethod()] para indicar que son clases y métodos de testing, así como los métodos Assert.isTrue y Assert.isFalse para realizar las diferentes pruebas.

<p align="center">
![](Imagenes/cap1.png?raw=true "Resultado positivo de los tests")
</p>

* PooVuelingXunitTests contiene el código para realizar los tests con Xunit. En primer lugar ha sido necesario utilizar el NuGet para instalar xunit y xunit.runner.console:

![](Imagenes/cap2.png?raw=true "Instalación de Xunit con NuGet")

A diferencia de MSTest2, Xunit utiliza el custom attribute [Fact] para indicar los métodos de testing. Por otro lado, la sintaxis de los asserts es ligeramente distinta. 

```VisualStudio
// Con MXTest2
[TestClass()]
public class CalculadoraIntegrationTests
{
    ICalculadora iCalculadora = new Calculadora();

    [TestMethod()]
    public void DivisionTest()
    {
        Assert.IsTrue(iCalculadora.Division(10, 5) == 2);
    }
}
```

```VisualStudio
// Con Xunit
[Fact]
        public void SumaTest()
        {
            Assert.Equal(4, iCalculadora.Suma(2, 2));
            Assert.True(iCalculadora.Suma(3, 6) == 9);
            Assert.False(iCalculadora.Suma(5, 3) == 10);
        }
```

Para ejecutar el test con Xunit, debemos ir al directorio de la solución y ejecutar "packages\xunit.runner.console.2.2.0\tools\xunit.console" seguido del nombre de la dll de testeo (en este caso, PooVuelingXunitTests.dll):

