using Alumnos.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Alumnos
{
    public class FicheroAlumnoJSON : IFicheroAlumno
    {
        public FicheroAlumnoJSON()
        {
        }

        public FicheroAlumnoJSON(string ruta)
        {
            Ruta = ruta;
        }

        public string Ruta { get; set; }

        public void Añadir(Alumno alumno)
        {
            List<Alumno> alumnosFicheroExistente = new List<Alumno>();
            if (File.Exists(Ruta))
            {
                alumnosFicheroExistente = FileUtils.LeerFicheroJson(Ruta);
            }

            alumnosFicheroExistente.Add(alumno);
            string jsonNuevo = JsonConvert.SerializeObject(alumnosFicheroExistente, Formatting.Indented);
            FileUtils.EscribirFichero(jsonNuevo, Ruta);
        }
    }
}
