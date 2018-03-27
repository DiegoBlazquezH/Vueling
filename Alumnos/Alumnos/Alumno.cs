using System;
using System.Collections.Generic;

namespace Alumnos
{
    public class Alumno : Persona
    {
        public Alumno()
        {
            GUID = Guid.NewGuid();
        }

        public Alumno(int IDout, string NombreOut, string ApellidosOut, string DNIOut) : base(IDout, NombreOut, ApellidosOut, DNIOut)
        {
        }

        public Alumno(int IDout, string NombreOut, string ApellidosOut, string DNIOut, Guid GUIDOut) : base(IDout, NombreOut, ApellidosOut, DNIOut, GUIDOut)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Alumno alumno &&
                   this.ID == alumno.ID &&
                   this.Nombre == alumno.Nombre &&
                   this.Apellidos == alumno.Apellidos &&
                   this.DNI == alumno.DNI &&
                   this.GUID == alumno.GUID;
        }

        public override int GetHashCode()
        {
            var hashCode = 1123755146;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DNI);
            hashCode = hashCode * -1521134295 + GUID.GetHashCode();

            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
