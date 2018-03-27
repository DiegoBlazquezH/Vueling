using System;

namespace Alumnos
{
    public abstract class Persona
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public Guid GUID { get; set; }
        
        public Persona()
        {
            GUID = Guid.NewGuid();
        }

        public Persona(int IDout, string NombreOut, string ApellidosOut, string DNIOut)
        {
            this.ID = IDout;
            this.Nombre = NombreOut;
            this.Apellidos = ApellidosOut;
            this.DNI = DNIOut;
            this.GUID = Guid.NewGuid();
        }

        public Persona(int IDout, string NombreOut, string ApellidosOut, string DNIOut, Guid GUIDOut)
        {
            this.ID = IDout;
            this.Nombre = NombreOut;
            this.Apellidos = ApellidosOut;
            this.DNI = DNIOut;
            this.GUID = GUIDOut;
        }
    }
}