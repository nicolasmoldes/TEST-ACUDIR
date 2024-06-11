Documentación del Test
Descargar el Proyecto
Clona o descarga el proyecto desde el repositorio proporcionado.

Especificaciones Técnicas
Se debe generar una arquitectura que contenga los siguientes componentes:

Dominio: Aquí se debe generar un modelo denominado Persona.
Repository: Encargado de la manipulación de los datos.
Interfaces: Definición de las interfaces necesarias para el funcionamiento del repositorio.
La manipulación de datos debe realizarse sobre el archivo Test.json.


Endpoints Esperados
GET /GetAll
Descripción: Obtiene todos los registros.
Filtros: Permite buscar utilizando todos los filtros disponibles en el modelo Persona(crearla en base a , Test.Json). Todos los filtros son opcionales.

Ejemplo de uso:
GET /GetAll?nombre=Juan&edad=30
POST /
Descripción: Agrega nuevos registros al archivo Test.json.
PUT /
Descripción: Modifica registros existentes en el archivo Test.json.


Entrega del Ejercicio
Una vez terminado el ejercicio, súbelo en una rama nueva con la siguiente nomenclatura: feature/test-NombreDelDesarrollador.


¿Qué se espera del Test?
Se espera que puedas manipular datos dentro del archivo Test.json, gestionando las acciones a través de una API y utilizando la arquitectura recomendada.



Esta versión es más clara y estructurada, lo que facilita la comprensión de las instrucciones y expectativas del proyecto.
