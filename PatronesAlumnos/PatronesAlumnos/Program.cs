using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatronesAlumnos
{
    class Program
    {
        public enum Operacion
        {
            CREAR = 1, SALIR = 2
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Sistema gestor de alumnos");
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
            Console.WriteLine("Indica lo que quieres realizar:");
            Console.Write("1. Crear nuevo alumno\n2. Salir\nOperación:");
            operacion = Convert.ToInt32(Console.ReadLine());

            switch ((Operacion)operacion)
            {
                case Operacion.CREAR:
                    crearAlumno();
                    break;
                case Operacion.SALIR:
                    Console.WriteLine("Adios");
                    Console.ReadKey();
                    return false;
                default:
                    return true;
            }


            return true;
        }

        static void crearAlumno()
        {
            int ID;
            string Nombre;
            string Apellidos;
            string DNI;
            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "alumnos.txt");

            Console.WriteLine("Introduzca el ID del alumno");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduzca el nombre del alumno");
            Nombre = Console.ReadLine();
            Console.WriteLine("Introduzca el apellido del alumno");
            Apellidos = Console.ReadLine();
            Console.WriteLine("Introduzca el DNI del alumno");
            DNI = Console.ReadLine();

            if (File.Exists(pathFile))
            {
                using (StreamWriter sw = File.AppendText(pathFile))
                {
                    sw.WriteLine("{0},{1},{2},{3}", ID, Nombre, Apellidos, DNI);
                }
            } else
            {
                using (StreamWriter sw = File.CreateText(pathFile))
                {
                    sw.WriteLine("{0},{1},{2},{3}", ID, Nombre, Apellidos, DNI);
                }
            }


        }
    }
}
