using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesAlumnos
{
    public class Alumno
    {
        public int ID;
        public string nombre;
        public string apellidos;
        public string DNI;

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
    }
}
