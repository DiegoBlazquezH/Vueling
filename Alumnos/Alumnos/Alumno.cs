using System.Collections.Generic;

namespace Alumnos
{
    public class Alumno : Persona
    {
        public Alumno()
        {
        }

        public Alumno(int IDout, string NombreOut, string ApellidosOut, string DNIOut) : base(IDout, NombreOut, ApellidosOut, DNIOut)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Alumno alumno &&
                   ID == alumno.ID &&
                   Nombre == alumno.Nombre &&
                   Apellidos == alumno.Apellidos &&
                   DNI == alumno.DNI;
        }

        public override int GetHashCode()
        {
            var hashCode = 1123755146;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DNI);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
