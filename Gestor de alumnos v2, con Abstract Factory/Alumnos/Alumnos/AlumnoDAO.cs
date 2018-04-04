using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Alumnos
{
    public class AlumnoDAO
    {
        public Alumno CrearAlumno()
        {
            Alumno nuevoAlumno = new Alumno();

            Console.Clear();
            Console.WriteLine("Introduzca el ID del alumno");
            nuevoAlumno.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduzca el nombre del alumno");
            nuevoAlumno.Nombre = Console.ReadLine();
            Console.WriteLine("Introduzca el apellido del alumno");
            nuevoAlumno.Apellidos = Console.ReadLine();
            Console.WriteLine("Introduzca el DNI del alumno");
            nuevoAlumno.DNI = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Datos del nuevo alumno:");
            Console.WriteLine("ID: " + nuevoAlumno.ID);
            Console.WriteLine("Nombre: " + nuevoAlumno.Nombre);
            Console.WriteLine("Apellidos: " + nuevoAlumno.Apellidos);
            Console.WriteLine("DNI: " + nuevoAlumno.DNI);
            Console.WriteLine("GUID: " + nuevoAlumno.GUID);
            Thread.Sleep(2000);

            return nuevoAlumno;
        }
    }
}
