# Ejemplo Redis

Aplicación de consola que emplea Redis como base de datos (como db en memoria).

Para instalar Redis, se ha utilizado Docker Toolbox para contenerizar el servidor.

El script arrancarRedisDocker.ps1 utiliza Docker Toolbox para arrancar un contenedor Redis. En caso de que no exista el contenedor o ni siquiera esté descargada la imagen, lo crea/descarga y lo arranca posteriormente.

NOTA: El script está hecho de una forma relativamente chapucera (básicamente bucles if anidados)