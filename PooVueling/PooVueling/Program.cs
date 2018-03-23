using System;

namespace PooVueling
{
    class Program
    {
        public enum Operador
        {
            SUMA=1, RESTA, MULTIPLICACION, DIVISION
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a CalcC# v1.0");
            bool seguir = true;
            do
            {
                seguir = Menu();
            } while (seguir);

            return;
        }

        static bool Menu()
        {
            int operacion;
            int parametro1;
            int parametro2;
            int resultado = 0;
            ICalculadora iCalculadora = new Calculadora();

            Console.WriteLine("Indica la operación que quieres realizar:");
            Console.Write("1. Suma\n2. Resta\n3. Multiplicación\n4. División\n5. Salir\nOperación:");
            operacion = Convert.ToInt32(Console.ReadLine());

            if (operacion == 5)
            {
                Console.WriteLine("Adios");
                Console.ReadKey();
                return false;
            }

            Console.Write("Introduzca el primer número:");
            parametro1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introduzca el segundo número:");
            parametro2 = Convert.ToInt32(Console.ReadLine());

            switch ((Operador)operacion) {
                case Operador.SUMA:
                    resultado = iCalculadora.Suma(parametro1, parametro2);
                    break;
                case Operador.RESTA:
                    resultado = iCalculadora.Resta(parametro1, parametro2);
                    break;
                case Operador.MULTIPLICACION:
                    resultado = iCalculadora.Multiplicacion(parametro1, parametro2);
                    break;
                case Operador.DIVISION:
                    resultado = iCalculadora.Division(parametro1, parametro2);
                    break;
                default:
                    return true;
            }
            Console.WriteLine("El resultado es " + resultado);
            Console.WriteLine();

            return true;
        }
    }
}
