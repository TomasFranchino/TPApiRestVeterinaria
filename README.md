# Sistema de Administración Veterinaria⚕️

Este proyecto es una aplicación integral para la administración de clínicas veterinarias, diseñada para gestionar de forma eficiente la información de animales, dueños, atenciones médicas y otros recursos clave para el correcto funcionamiento de una clínica o veterinaria.

## Características principales

- **Gestión de Animales**:  
  - Registrar nuevos animales con información detallada (especie, nombre, raza, edad, sexo, etc.).
  - Consultar la lista de animales registrados.
  - Ver el detalle de cada animal.
  - Modificar y eliminar registros de animales.

- **Gestión de Dueños**:  
  - Registrar nuevos dueños con sus datos personales (DNI, nombre, apellido, teléfono).
  - Consultar la lista de dueños y ver detalles individuales.
  - Asignar dueños a animales de forma sencilla.

- **Gestión de Atenciones Médicas**:  
  - Registrar atenciones médicas para animales, incluyendo datos como motivo, tratamiento, fecha y medicamentos.
  - Consultar el historial de atenciones y gestionar seguimientos.

- **API REST**:  
  - El backend está desarrollado en C# con ASP.NET Core, exponiendo recursos mediante una API REST.
  - La API implementa operaciones CRUD (crear, leer, actualizar, eliminar) para cada entidad.
  - Incluye validación y manejo de errores para garantizar la integridad de la información.

- **Front-End**:  
  - Se ha desarrollado una interfaz web (utilizando HTML, CSS y JavaScript) para interactuar con la API.
  - La interfaz permite registrar, modificar y consultar datos, facilitando la administración diaria.

- **Despliegue en Azure**:  
  - El proyecto está configurado para desplegarse en Azure, aprovechando la escalabilidad y fiabilidad de los servicios en la nube.
  - Las migraciones de Entity Framework se encargan de crear la estructura de la base de datos automáticamente en Azure.

## Tecnologías Utilizadas💻

- **Backend**:  
  - C#, ASP.NET Core, Entity Framework Core  
  - API REST para la exposición de recursos

- **Frontend**:  
  - HTML, CSS, JavaScript (sin frameworks externos)

- **Base de Datos**:  
  - SQL Server (configurado para Azure)

- **Despliegue**:  
  - Azure Web App

## Futuras mejoras🚀

- **Autenticación y autorización**:  
  - Autorizacion basada en tokens
  - Control de acceso basado en roles
 
- **Interfaz de usuario mas responsiva y dinamica**:  
  - Implementación de frameworks UI
  - React o Angular

- **Generacion de reportes y dashboards**:  
  -  Basados en estadísticas sobre consultas, atenciones y otros indicadores clave de la veterinaria.
