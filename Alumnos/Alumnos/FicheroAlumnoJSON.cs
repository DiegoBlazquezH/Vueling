using Alumnos.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(File.Exists(Ruta)) { 
                using (StreamReader sr = new StreamReader(Path.GetFileName(Ruta)))
                {
                    string jsonAntiguo = sr.ReadToEnd();
                    alumnosFicheroExistente = JsonConvert.DeserializeObject<List<Alumno>>(jsonAntiguo);
                }
            }

            alumnosFicheroExistente.Add(alumno);

            string jsonNuevo = JsonConvert.SerializeObject(alumnosFicheroExistente, Formatting.Indented);

            using (StreamWriter sw = File.CreateText(Ruta))
            {
                sw.WriteLine(jsonNuevo);
            }
        }
    }
}
