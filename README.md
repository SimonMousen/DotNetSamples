# DotNetSamples - Sistema de Gestión Académica

## Descripción del Proyecto
**DotNetSamples** es una aplicación web desarrollada en **ASP.NET Core** que gestiona usuarios y matrículas educativas mediante un sistema de roles diferenciados (Administrador, Docente, Estudiante). La aplicación implementa autenticación segura, sesiones persistentes y almacenamiento de datos en formato JSON, ofreciendo una plataforma eficiente para digitalizar procesos académicos en instituciones educativas.

## Características Principales
- **Autenticación por roles**: Tres tipos de usuarios con permisos diferenciados
- **Gestión de matrículas**: Formulario completo para registro estudiantil
- **Interfaz intuitiva**: Diseño responsive y fácil de usar
- **Almacenamiento JSON**: Base de datos ligera y portable
- **Sesiones seguras**: Timeout configurable de 30 minutos
- **Usuarios de prueba**: Preconfigurados para facilitar las pruebas

## Arquitectura del Proyecto

### Estructura de Archivos
```
DotNetSamples/
│
├── Controllers/
│   ├── LoginController.cs      # Gestión de autenticación
│   └── MatriculaController.cs  # Gestión de matrículas
│
├── Models/
│   ├── LoginModel.cs           # Modelo para login
│   ├── Matricula.cs            # Modelo para matrículas
│   └── Usuario.cs              # Modelo para usuarios
│
├── Pages/
│   ├── index.html              # Página principal
│   ├── Login.html              # Formulario de login
│   ├── MatriculaForm.html      # Formulario de matrícula
│   ├── DashboardAdmin.html     # Panel de administración
│   ├── DashboardDocente.html   # Panel de docente
│   └── DashboardEstudiante.html # Panel de estudiante
│
├── Data/
│   └── Usuarios.json           # Base de datos de usuarios
│
├── Program.cs                  # Configuración de la aplicación
└── Styles/                     # Archivos CSS
```

## Roles y Permisos

### 1. **Administrador** (`admin`)
- **Acceso completo** a todas las funcionalidades
- **Gestión de matrículas** (ver, editar, eliminar)
- **Panel de control** administrativo

### 2. **Docente** (`docente`)
- **Consulta de matrículas** existentes
- **Visualización** de estudiantes matriculados
- **Panel docente** con opciones específicas

### 3. **Estudiante** (`estudiante`)
- **Realizar matrículas** en cursos disponibles
- **Panel estudiantil** personalizado
- **Acceso limitado** a funcionalidades

## Credenciales de Prueba

La aplicación incluye usuarios preconfigurados para pruebas:

| Rol | Usuario | Contraseña | Email |
|-----|---------|------------|-------|
| **Administrador** | `admin` | `admin123` | admin@escuela.com |
| **Docente** | `profesor1` | `docente123` | juan@escuela.com |
| **Estudiante** | `estudiante1` | `estudiante123` | maria@escuela.com |

## Vistas y Funcionalidades

### 1. **Página Principal** (`/`)
- Opción para **Iniciar Sesión** (usuarios registrados)
- Opción para **Matricularse** (nuevos estudiantes)

### 2. **Login** (`/Login`)
- Selección interactiva de tipo de usuario
- Formulario con validación
- Opciones visuales para cada rol

### 3. **Paneles por Rol**

#### Panel de Administrador
- Gestión completa de matrículas
- Acceso a todas las funcionalidades
- Opción de cerrar sesión

#### Panel de Docente
- Consulta de matrículas existentes
- Visualización de estudiantes
- Navegación específica para docentes

#### Panel de Estudiante
- Realizar matrículas en cursos
- Formulario de matrícula completo
- Opciones limitadas al rol estudiante

### 4. **Formulario de Matrícula**
Campos requeridos:
- **Nombre completo**
- **Documento de identidad**
- **Curso a matricular**
- **Edad**
- **Correo electrónico**

## Posibles Mejoras Futuras

1. **Base de datos real**: Migrar de JSON a SQL Server o PostgreSQL
2. **Autenticación externa**: Integrar login con Google, Microsoft, etc.
3. **Notificaciones por email**: Confirmación de matrículas
4. **Panel de reportes**: Estadísticas y gráficos
5. **API REST**: Para integración con otras aplicaciones
6. **Pruebas unitarias**: Mejorar calidad del código
7. **Dockerización**: Contenedores para despliegue fácil

## Autores del Proyecto

### Equipo de Desarrollo
- **Juan Jose Giraldo Monsalve**
- **Simón Sierra López**
- **Jose Manuel Ruiz Zapata**

### Instrucción
- **Instructor**: Luis Fernando Sánchez
- **Centro**: Centro De Tecnología De La Manufactura Avanzada, SENA
- **Programa**: Análisis y Desarrollo de Software
- **Ficha**: 3144585
- **Fecha**: 27 de noviembre de 2025
