using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatronesAlumnos
{
    class Program
    {
        public enum Opcion
        {
            CREAR = 1, CONFIGURACION, SALIR 
        }

        public enum Extension
        {
            TXT = 1, JSON
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
            int opcion = 0;

            Console.WriteLine("");
            Console.WriteLine("Indica lo que quieres realizar:");
            Console.WriteLine("1. Crear nuevo alumno");
            Console.WriteLine("2. Configuración");
            Console.WriteLine("3. Salir");
            Console.Write("Opción:");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch ((Opcion)opcion)
            {
                case Opcion.CREAR:
                    crearAlumno();
                    break;
                case Opcion.CONFIGURACION:
                    Configuracion();
                    break;
                case Opcion.SALIR:
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
            string temp;
            int temp2;
            Alumno nuevoAlumno = new Alumno();
            int serializacionFichero;

            Console.WriteLine("Introduzca el ID del alumno");
            nuevoAlumno.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduzca el nombre del alumno");
            nuevoAlumno.nombre = Console.ReadLine();
            Console.WriteLine("Introduzca el apellido del alumno");
            nuevoAlumno.apellidos = Console.ReadLine();
            Console.WriteLine("Introduzca el DNI del alumno");
            nuevoAlumno.DNI = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Datos del nuevo alumno:");
            Console.WriteLine("ID: " + nuevoAlumno.ID);
            Console.WriteLine("Nombre: " + nuevoAlumno.nombre);
            Console.WriteLine("Apellidos: " + nuevoAlumno.apellidos);
            Console.WriteLine("DNI: " + nuevoAlumno.DNI);

            Console.Write("¿Desea continuar? (si/no)");
            temp = Console.ReadLine();
            if (!temp.Equals("si"))
            {
                Console.WriteLine("Alumno descartado, volviendo al menú");
                Console.WriteLine("");
                return;
            }
            Console.Write("");

            serializacionFichero = Convert.ToInt32(ConfigurationManager.AppSettings["serializacionFichero"]);
            Console.WriteLine(serializacionFichero);

            switch ((Extension)serializacionFichero)
            {
                case Extension.TXT:
                    AlumnoToTXT(nuevoAlumno);
                    Console.WriteLine("Añadiendo alumno a TXT");
                    break;
                case Extension.JSON:
                    AlumnoToJSON(nuevoAlumno);
                    Console.WriteLine("Añadiendo alumno a JSON");
                    break;
                default:
                    AlumnoToTXT(nuevoAlumno);
                    Console.WriteLine("Añadiendo alumno a TXT default");
                    break;

            }
        }

        /***** Recibe un alumno y la ruta del fichero json y mete a dicho alumno en el fichero *****/
        static void AlumnoToJSON(Alumno nuevoAlumno)
        {
            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "alumnos.json");

            // Si el fichero alumnos.json ya existe
            if (File.Exists(pathFile))
            {
                List<Alumno> alumnosFichero = new List<Alumno>();
                // Leemos su contenido y desserializamos
                using (StreamReader r = new StreamReader("alumnos.json"))
                {
                    string json = r.ReadToEnd();
                    alumnosFichero = JsonConvert.DeserializeObject<List<Alumno>>(json);
                }
                // Añadimos el nuevoAlumno a la lista, volvemos a serializar todo y lo pasamos al fichero
                alumnosFichero.Add(nuevoAlumno);

                string alumnosFicheroNew = JsonConvert.SerializeObject(alumnosFichero, Formatting.Indented);

                using (StreamWriter sw = File.CreateText(pathFile))
                {
                    sw.WriteLine(alumnosFicheroNew);
                }
            }
            // Si el fichero alumnos.json no existe, lo creamos y le añadimos el nuevo alumno
            else
            {
                // Serializamos a Json el nuevo Alumno
                List<Alumno> listaAlumnos = new List<Alumno>{nuevoAlumno};
                string alumnoJson = JsonConvert.SerializeObject(listaAlumnos, Formatting.Indented);

                using (StreamWriter sw = File.CreateText(pathFile))
                {
                    sw.WriteLine(alumnoJson);
                }
            }
        }

        /***** Recibe un alumno y la ruta del fichero txt y mete a dicho alumno en el fichero *****/
        static void AlumnoToTXT(Alumno nuevoAlumno)
        {
            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "alumnos.txt");

            if (File.Exists(pathFile))
            {
                using (StreamWriter sw = File.AppendText(pathFile))
                {
                    sw.WriteLine("{0},{1},{2},{3}", nuevoAlumno.ID, nuevoAlumno.nombre, nuevoAlumno.apellidos, nuevoAlumno.DNI);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(pathFile))
                {
                    sw.WriteLine("{0},{1},{2},{3}", nuevoAlumno.ID, nuevoAlumno.nombre, nuevoAlumno.apellidos, nuevoAlumno.DNI);
                }
            }
        }

        /***** Menú para elegir en que formato se quiere serializar el nuevo usuario *****/
        static void Configuracion()
        {
            int formato;
            string[] extensiones = new string[] { "", "TXT", "JSON" };

            Console.WriteLine("");
            Console.WriteLine("¿En qué formato quieres serializar los nuevos alumnos? Formato actual {0}", extensiones[Convert.ToInt32(ConfigurationManager.AppSettings["serializacionFichero"])]);
            Console.WriteLine("1. TXT");
            Console.WriteLine("2. JSON");
            Console.WriteLine("3. Salir");
            Console.Write("Opción:");
            formato = Convert.ToInt32(Console.ReadLine());

            switch ((Extension)formato)
            {
                case Extension.TXT:
                    ConfigurationManager.AppSettings["serializacionFichero"] = Convert.ToString("1");
                    Console.WriteLine("Formato cambiado a TXT");
                    break;
                case Extension.JSON:
                    ConfigurationManager.AppSettings["serializacionFichero"] = Convert.ToString("2");
                    Console.WriteLine("Formato cambiado a JSON");
                    break;
                default:
                    break;
            }
        }
    }
}
