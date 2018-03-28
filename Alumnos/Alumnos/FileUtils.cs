using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos
{
    public static class FileUtils
    {

        public static List<Alumno> LeerFicheroJson(string Ruta)
        {
            List<Alumno> alumnosFicheroExistente = new List<Alumno>();
            
            using (StreamReader sr = new StreamReader(Path.GetFileName(Ruta)))
            {
                string FileContent;
                FileContent = sr.ReadToEnd();
                alumnosFicheroExistente = JsonConvert.DeserializeObject<List<Alumno>>(FileContent);
            }
            return alumnosFicheroExistente;
        }

        public static void EscribirFichero(string fileContent, string Ruta)
        {
            using (StreamWriter sw = File.CreateText(Ruta))
            {
                sw.WriteLine(fileContent);
            }
        }

        public static void CrearFichero(string Ruta)
        {
            using (StreamWriter sw = File.CreateText(Ruta))
            {
            }
        }
    }
}
