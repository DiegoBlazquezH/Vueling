# Creación y lectura de variables de entorno en C#

El objetivo del ejercicio es crear una variable de entorno de forma automatizada y leerla posteriormente utilizando C#. Además se han implementado evento de postcompilación para copiar el ejecutable final en una carpeta más accesible.

* crearVariableEntorno.ps1: Este script de Powershell crea una variable de entorno de usuario llamada VariableTesting. Comprueba primero si la variable existe y si no es así, la genera.

* LectorVariableEntorno: El programa llama en primer lugar al script crearVariableEntorno.ps1 para generar la variable de entorno. A continuación, la lee y muestra su contenido por pantalla.

En este caso, la llamada al script de creación de la variable de entorno se realiza en tiempo de ejecución al principio del programa, ya que se espera que el usuario final reciba directamente el ejecutable y el script. Una opción más correcta en caso de que se fuer a hacer la compilación (para un entorno de integración continua, por ejemplo) sería la de incluir un evento de precompilación que ejecutara el script. En este caso, sería necesario borrar el código que lee y ejecuta el script en LectorVariableEntorno.

Resultado si la variable no existe:

![](Imagenes/cap1.png?raw=true "Resultado si la variable no existe")

Resultado si la variable ya existe:

![](Imagenes/cap2.png?raw=true "Resultado si la variable ya existe")
