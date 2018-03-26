using static Alumnos.Enums.ExtensionesFicheros;
using Alumnos.Interfaces;
using System;
using System.IO;

namespace Alumnos
{
    public class FicheroAlumnoFactory : IFicheroFactory
    {
        public IFicheroAlumno CrearFichero(Extension extension)
        {
            switch (extension)
            {
                case Extension.TXT:
                    return new FicheroAlumnoTXT(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "alumnos.txt"));
                case Extension.JSON:
                    return new FicheroAlumnoJSON(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "alumnos.json"));
                /*
            case Extension.XML:
                return new FicheroAlumnoXML(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "alumnos.xml"));
                */
                default:
                    return new FicheroAlumnoTXT(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "alumnos.txt"));

            }
        }
    }
}
