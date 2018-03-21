using System;
using System.IO;
using System.Management.Automation;
using System.Text;

namespace LectorVariablesEntorno
{
    class Program
    {
        static void Main(string[] args)
        {
            string PathInicial = Directory.GetCurrentDirectory();
            string ScriptFile = @"crearVariableEntorno.ps1";
            string script = "";
            string nombreVariable = "VariableTesting";

            try
            {
                script = File.ReadAllText(Path.Combine(PathInicial, ScriptFile));
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Error, el script de creación de variables de entorno no existe.");
                Console.ReadKey();
                return;
            }
           
            //Console.WriteLine(script);

            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(script);
                var result = PowerShellInstance.Invoke();

                foreach (var obj in result)
                {
                    Console.WriteLine(obj);
                }
            }

            var variableLocal = System.Environment.GetEnvironmentVariable(nombreVariable, EnvironmentVariableTarget.User);

            Console.WriteLine("Contenido de la variable " + nombreVariable + ": "+ variableLocal);
            Console.ReadKey();
        }
    }
}
