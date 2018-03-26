namespace Alumnos.Interfaces
{
    public interface IFicheroAlumno
    {
        string Ruta { get; set; }
        
        void Añadir(Alumno alumno);
    }
}
