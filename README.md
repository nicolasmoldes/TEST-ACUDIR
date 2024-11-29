
# Acudir.Test.Apis
Para la creacion de la api utilice los principios SOLID y clean architecture. Ademas. utilice patrones como el mediator para separar las reponsabilidades de cada componente para darle una myor escalabilidad.
La API está protegida con JWT para autenticación y autorización.

## Requisitos
- Archivo `.env` con la clave secreta para JWT (`JWT_SECRET_KEY`)

## Configuración
1. Crea un archivo `.env` en la raíz del proyecto con la siguiente variable de entorno: JWT_SECRET_KEY=MySecureJwtKey12345678901234567890

## Autenticación

La api utiliza JWT para la autenticación y autorización. Asegúrate de incluir el token JWT en el encabezado de las solicitudes que requieren autenticación.
El jwt lo podes generar automaticamente desde https://jwt-generator-api.onrender.com/index.html con las credenciales que se indican mas abajo.

!!!IMPORTANTE !!!
Las credenciales de acceso son:
- Usuario: AcudirTest
- Contraseña: AcudirTest
- El token generado tiene una duración de 1 hora

La estructura del tocken es similar a esta:

Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJBY3VkaXJUZXN0IiwianRpIjoiYjZkMDg3ZGMtOWUyZC00YmI4LWEwYzgtOGIwYjc0ZGI3ZGJlIiwibmJmIjoxNzMyODY3NDEzLCJleHAiOjE3MzI4NzEwMTMsImlhdCI6MTczMjg2NzQxMywiaXNzIjoidHVJc3N1ZXIiLCJhdWQiOiJ0dUF1ZGllbmNlIn0.8Um0p-vX45U98Y1mGyO9LmWsMtLUsyuq7-o5rCH2QZw

Aclaracion: A la hora de ingresar el token para autorizarlo, copiar la cadena con el bearer incluido tal como se indica arriba
## Docker
Ejecutando el comando docker-compose up --build se va a crear una imagen de la aplicacion y para luego ejecutarse en un contenedor docker, el archivo `.env` se crea automaticamente con docker.
la aplicacion se ejecuta en https://localhost:5001

## Endpoints

### GET /Personas/GetPersonas

Obtiene todos los registros de personas. Permite buscar utilizando todos los filtros disponibles en el modelo `Persona`. Todos los filtros son opcionales.

**Ejemplo de uso:**
GET /Personas/GetPersonas?nombre=Juan&edad=30

### POST /Personas/AgregarPersona

Agrega un nuevo registro al archivo `Test.json`.

**Parámetros:**
- `nombreCompleto` (string, requerido)
- `edad` (int, requerido)
- `domicilio` (string, requerido)
- `telefono` (string, requerido)
- `profesion` (string, requerido)

**Ejemplo de uso:**

POST /Personas/AgregarPersona?nombreCompleto=Juan Perez&edad=30&domicilio=Calle Falsa 123&telefono=555-5555&profesion=Ingeniero


### PUT /Personas/ActualizarPersona

Modifica un registro existente en el archivo `Test.json`.

**Parámetros:**
- `id` (int, requerido)
- `nombreCompleto` (string, opcional)
- `edad` (int, opcional)
- `domicilio` (string, opcional)
- `telefono` (string, opcional)
- `profesion` (string, opcional)

**Ejemplo de uso:**
PUT /Personas/ActualizarPersona?id=1&nombreCompleto=Juan Perez&edad=31

## Estructura del Proyecto

- **Acudir.Test.Apis**: Proyecto principal de la API.
- **Data**: Contiene el repositorio para la manipulación de datos.
- **Domain**: Contiene las entidades y las interfaces.
- **UnitTest**: Contiene las pruebas unitarias.
