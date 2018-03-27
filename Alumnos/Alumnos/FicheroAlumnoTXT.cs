using Alumnos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos
{
    public class FicheroAlumnoTXT : IFicheroAlumno
    {
        public string Ruta { get; set; }

        public FicheroAlumnoTXT()
        {
        }

        public FicheroAlumnoTXT(string ruta)
        {
            Ruta = ruta;
        }

        public void Añadir(Alumno alumno)
        {
            using (StreamWriter sw = File.AppendText(Ruta))
            {
                sw.WriteLine("{0},{1},{2},{3},{4}", alumno.ID, alumno.Nombre, alumno.Apellidos, alumno.DNI, alumno.GUID);
            }
        }
    }
}
