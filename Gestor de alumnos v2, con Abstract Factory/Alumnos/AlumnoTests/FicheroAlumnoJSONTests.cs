using System;
using System.Collections.Generic;
using System.IO;
using Alumnos;
using Alumnos.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Alumnos.Enums.ExtensionesFicheros;

namespace AlumnosTests
{
    [TestClass]
    public class FicheroAlumnoJSONTests
    {
        IFicheroFactory factory = new FicheroAlumnoFactory();
        IFicheroAlumno ficheroAlumnos = null;

        [TestInitialize()]
        public void Initialize()
        {
            factory = new FicheroAlumnoFactory();
            ficheroAlumnos = factory.CrearFichero(Extension.JSON);
            FileUtils.CrearFichero(ficheroAlumnos.Ruta);
        }
        

        [DataRow(3, "Diego", "Blazquez", "70910782B")]
        [DataRow(2, "Alberto", "Diaz", "12345678Z")]
        [DataRow(1, "Amaia", "Viñegra", "98765432A")]
        [DataTestMethod]
        public void AñadirTest(int ID, string Nombre, string Apellidos, string DNI)
        {
            List<Alumno> alumnosFicheroExistente = null;

            Alumno alumnoNuevo = new Alumno(ID, Nombre, Apellidos, DNI);
            ficheroAlumnos.Añadir(alumnoNuevo);

            Assert.IsTrue(File.Exists(ficheroAlumnos.Ruta));

            alumnosFicheroExistente = FileUtils.LeerFicheroJson(ficheroAlumnos.Ruta);

            Assert.IsTrue(alumnoNuevo.Equals(alumnosFicheroExistente[alumnosFicheroExistente.Count-1]));
        }

    }
}
