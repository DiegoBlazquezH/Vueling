using Newtonsoft.Json;
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
            CREAR = 1, CONFIGURACION, SALIR 
        }

        public enum Extension
        {
            TXT = 1, JSON, SALIR
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
            Console.WriteLine("1. Crear nuevo alumno");
            Console.WriteLine("2. Configuración");
            Console.WriteLine("3. Salir");
            Console.Write("Opción:");
            operacion = Convert.ToInt32(Console.ReadLine());

            switch ((Operacion)operacion)
            {
                case Operacion.CREAR:
                    crearAlumnoJSON();
                    break;
                case Operacion.CONFIGURACION:
                    Configuracion();
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

        static void crearAlumnoTXT()
        {
            int ID;
            string nombre;
            string apellidos;
            string DNI;
            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "alumnos.txt");

            Console.WriteLine("Introduzca el ID del alumno");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduzca el nombre del alumno");
            nombre = Console.ReadLine();
            Console.WriteLine("Introduzca el apellido del alumno");
            apellidos = Console.ReadLine();
            Console.WriteLine("Introduzca el DNI del alumno");
            DNI = Console.ReadLine();

            if (File.Exists(pathFile))
            {
                using (StreamWriter sw = File.AppendText(pathFile))
                {
                    sw.WriteLine("{0},{1},{2},{3}", ID, nombre, apellidos, DNI);
                }
            } else
            {
                using (StreamWriter sw = File.CreateText(pathFile))
                {
                    sw.WriteLine("{0},{1},{2},{3}", ID, nombre, apellidos, DNI);
                }
            }
        }

        static void crearAlumnoJSON()
        {
            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "alumnos.json");
            string output = "";
            Alumno nuevoAlumno = new Alumno();

            Console.WriteLine("Introduzca el ID del alumno");
            nuevoAlumno.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduzca el nombre del alumno");
            nuevoAlumno.nombre = Console.ReadLine();
            Console.WriteLine("Introduzca el apellido del alumno");
            nuevoAlumno.apellidos = Console.ReadLine();
            Console.WriteLine("Introduzca el DNI del alumno");
            nuevoAlumno.DNI = Console.ReadLine();
            
            output = JsonConvert.SerializeObject(nuevoAlumno);

            if (File.Exists(pathFile))
            {
                using (StreamWriter sw = File.AppendText(pathFile))
                {
                    sw.WriteLine(output);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(pathFile))
                {
                    sw.WriteLine(output);
                }
            }
        }

        static void Configuracion()
        {
            int formato;
            Console.WriteLine("¿En qué formato quieres serializar los alumnos?");
            Console.WriteLine("1. TXT");
            Console.WriteLine("2. JSON");
            Console.WriteLine("3. Salir");
            Console.Write("Opción:");
            formato = Convert.ToInt32(Console.ReadLine());

            switch ((Extension)formato)
            {
                case Extension.TXT:
                    //Cambiar variable global a (int)Extension.TXT y cambiar el fichero de config
                    break;
                case Extension.JSON:
                    //Cambiar variable global a (int)Extension.TXT y cambiar el fichero de config
                    break;
                case Extension.SALIR:
                    break;
                default:
                    break;
            }
        }
    }
}
