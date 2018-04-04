using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesAlumnos
{
    public class Alumno
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string DNI { get; set; }

        public Alumno()
        {

        }

        public Alumno(int IDout, string NombreOut, string ApellidosOut, string DNIOut)
        {
            ID = IDout;
            nombre = NombreOut;
            apellidos = ApellidosOut;
            DNI = DNIOut;
        }

        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   ID == alumno.ID &&
                   nombre == alumno.nombre &&
                   apellidos == alumno.apellidos &&
                   DNI == alumno.DNI;
        }

        public override int GetHashCode()
        {
            var hashCode = 1123755146;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DNI);
            return hashCode;
        }
    }
}
