# Instalación

## Requerimientos

* [.NET9.0+ SDK](https://dotnet.microsoft.com/download/dotnet)
* [Node v18 or 20](https://nodejs.org/en)

## Pasos

1. Chequear que en el proyecto `Alfredo.NocNoc.EntityFrameworkCore` exista la migración inicial.
2. Correr la aplicación `Alfredo.NocNoc.DbMigrator` para crear la base de datos inicial de Abp.
3. Correr la aplicación `Alfredo.NocNoc.GlasApi`.
4. Correr la aplicación `Alfredo.NocNoc.HttpApi.Host`.
5. Correr la aplicación web (ng serve, etc).

# Notas

Se decantó por el uso de A

## Glas Api Mock

- El mock de la GlasApi fue de gran utilidad para experimentar con las funcionalidades más primitivas de una aplicación ASP.NET. Dado el caso, por ejemplo, en el método GetSearch se practicó recibir los parámetros por "query", mientras que en el método GetSell por "route".

## Backend

- Como el backend realmente es un simple pasamanos, ya que todos los datos se "procesan" en la API de Glas, no me vi en la necesidad de crear entidades de dominio. Eso añadiría una capa de totalmente innecesaria, al menos, para esta prueba.

- Abp se encarga del manejo básico de excepciones a nivel de capa de aplicación, por lo que no se colocaron bloques try-catch en los métodos de los servicios.

- La interacción con la API de GLAS desde el backend se hizo implementando un módulo Abp independiente, esto con el objetivo de ejemplificar como debe ser una correcta separación de responsabilidades en un sistema DDD y cómo se crean módulos personalizados en Abp.

- El manejo de validaciones se hizo a nivel del módulo GlasApiClient. En caso de que se necesite elevar el manejo a la capa de aplicación se recomienda el uso de los Validators provistos por Abp.

- El manejo de excepciones se hizo a nivel del módulo GlasApiClient. En caso de que se necesite elevar el manejo a la capa de aplicación se recomienda el uso de la clase UserFriendlyException de Abp.

- Se implementó un único unit testing para que sirva de referencia de cómo sería una clase de prueba estándar

## Frontend

- Se descartó el uso de la aplicación que trae Abp.io por defecto al considerar que su modificación conllevaría más tiempo que crear una de cero.

- Se centralizó todo el procesamiento de datos en el componente principal por cuestiones de simplicidad. Haber delegado a cada componente la obtención y procesamiento de sus propios datos hubiera complejizado la aplicación innecesariamente. Por las mismas razones se descartó la implementación de un manejador de estados como NgRx.

- Se descartó un profundo estilizado de la aplicación por temas de tiempo.

- Se descartó la paginación de la lista de vuelos por temas de tiempo.

# Mejoras sugeridas en caso de crear un sistema real

- Estudiar en qué capas de la aplicación faltaron las validaciones correspondientes.
- Estudiar la implementación de entidades y servicios de dominio.
- Estudiar la implementación de una caché para los datos - obtenidos desde GLAS (Redis).
- Estilizar mejor la aplicación web
- Implementar paginación en la aplicación web
- Implementar signals en la aplicación web para mejorar el rendimiento
- Cambiar los Console.WriteLine por logs.
- Implementar más UTs.
- Implementar ambientes (develop, staging y production).
- Implementar Azure App Insights.
- Implementar autenticación (Microsoft Entra ID).
- Implementar autorización (Microsoft Entra ID y Abp.io).
- Implementar CI/CD.
