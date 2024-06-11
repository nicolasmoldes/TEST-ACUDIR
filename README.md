Documentación del Test
Descargar el Proyecto
Clona o descarga el proyecto desde el repositorio proporcionado.
Manipulación de Datos
La manipulación de datos debe realizarse sobre el archivo Test.json.
Requisitos Técnicos
Aplicar Interfaces.
Utilizar toda la estructura del proyecto.
Endpoints Esperados
1. GET /GetAll
Descripción: Obtiene todos los registros.
Filtros: Permite buscar utilizando todos los filtros disponibles en el modelo Persona. Todos los filtros son opcionales.
Ejemplo de uso:
http
Copiar código
GET /GetAll?nombre=Juan&edad=30
2. POST /
Descripción: Agrega nuevos registros al archivo Test.json.

3. PUT /
Descripción: Modifica registros existentes en el archivo Test.json.
Cuerpo de la Solicitud:


Entrega del Ejercicio
Una vez terminado el ejercicio, súbelo en una rama nueva con la siguiente nomenclatura:
feature/test-NombreDelDesarrollador



Este documento proporciona una estructura clara y detallada de lo que se espera en el test, facilitando su comprensión y ejecución.
