using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alumnos.Enums.ExtensionesFicheros;

namespace Alumnos.Interfaces
{
    public interface IFicheroFactory
    {
        IFicheroAlumno CrearFichero(Extension extension);
    }
}
