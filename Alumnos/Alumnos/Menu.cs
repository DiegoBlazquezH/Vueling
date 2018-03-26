using Alumnos.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Alumnos.Enums.ExtensionesFicheros;

namespace Alumnos
{
    public enum OpcionesMenu
    {
        CREAR = 1, CONFIGURACION, SALIR
    }

    public class Menu
    {

        public void Run()
        {
            bool seguir = true;
            do
            {
                seguir = MenuPrincipal();
            } while (seguir);

            return;
        }

        public bool MenuPrincipal()
        {
            int opcion = 0;

            ImprimirMenuPrincipal();

            opcion = Convert.ToInt32(Console.ReadLine());

            switch ((OpcionesMenu)opcion)
            {
                case OpcionesMenu.CREAR:
                    IFicheroFactory factory = new FicheroAlumnoFactory();
                    var extensionElegida = ConfigurationManager.AppSettings["serializacionFichero"];
                    Extension extActual = (Extension)Enum.Parse(typeof(Extension), extensionElegida, true);
                    IFicheroAlumno ficheroAlumnos = factory.CrearFichero(extActual);
                    AlumnoDAO alumnoDAO = new AlumnoDAO();
                    ficheroAlumnos.Añadir(alumnoDAO.CrearAlumno());
                    Console.WriteLine("Alumno añadido");
                    break;
                case OpcionesMenu.CONFIGURACION:
                    Configuracion();
                    break;
                case OpcionesMenu.SALIR:
                    Console.Clear();
                    Console.WriteLine("\n\n\n*** Cerrando ***\n\n\n");
                    Thread.Sleep(2000);
                    return false;
                default:
                    return true;
            }
            return true;
        }

        public void ImprimirMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("   Sistema gestor de Alumnos");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Indica lo que quieres realizar:");
            Console.WriteLine("1. Crear nuevo alumno");
            Console.WriteLine("2. Configuración");
            Console.WriteLine("3. Salir");
            Console.Write("Opción:");
        }

        public void Configuracion()
        {
            int formato;

            Console.Clear();
            Console.WriteLine("¿En qué formato quieres serializar los nuevos alumnos? Formato actual {0}", ConfigurationManager.AppSettings["serializacionFichero"]);
            Console.WriteLine("1. TXT");
            Console.WriteLine("2. JSON");
            Console.WriteLine("3. Salir");
            Console.Write("Opción:");
            formato = Convert.ToInt32(Console.ReadLine());

            if(formato == 3)
            {
                return;
            }

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["serializacionFichero"].Value = Enum.GetName(typeof(Extension), formato);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            Console.Clear();
            Console.WriteLine("Formato aplicado: {0}", Enum.GetName(typeof(Extension), formato));
            Thread.Sleep(2000);
        }
    }
}


