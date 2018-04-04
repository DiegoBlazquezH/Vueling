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
                sw.WriteLine(alumno.ToString());
            }
        }
    }
}
