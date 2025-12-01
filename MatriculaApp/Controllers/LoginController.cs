using Microsoft.AspNetCore.Mvc;
using MatriculaApp.Models;
using System.Text.Json;

namespace MatriculaApp.Controllers
{
    [Route("Login")] // Este controlador responde a todo lo que empiece con "/Login" en la dirección web
    public class LoginController : Controller
    {
        private const string USERS_FILE = "usuarios.json"; // El archivo donde guardamos a todos los usuarios
        private List<Usuario> _usuarios; // Una lista en la memoria para tener a todos los usuarios

        // Esto es lo primero que se ejecuta cuando alguien usa esta página
        public LoginController()
        {
            _usuarios = CargarUsuarios(); // Cargamos los usuarios del archivo cuando arrancamos
        }

        // Cuando escribes "tuweb.com/Login" en el navegador (método GET)
        [HttpGet("")]
        public IActionResult Login()
        {
            // Simplemente mostramos la página de login (el formulario para entrar)
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "Pages", "Login.html"), "text/html");
        }

        // Cuando llenas el formulario de login y le das a "Entrar" (método POST)
        [HttpPost("Validar")]
        public IActionResult Validar([FromForm] LoginModel login)
        {
            // Buscamos en nuestra lista de usuarios si hay alguien que coincida:
            // - Con el nombre de usuario que escribiste
            // - Con la contraseña que pusiste
            // - Con el tipo de usuario que seleccionaste (admin, profesor o estudiante)
            var usuario = _usuarios.FirstOrDefault(u => 
                u.Username == login.Username && 
                u.Password == login.Password && 
                u.Tipo == login.TipoUsuario);

            if (usuario != null) // ¡Encontramos al usuario! Las credenciales son correctas
            {
                // Guardamos al usuario en la "sesión" (como una memoria temporal del navegador)
                // para recordar que ya inició sesión
                HttpContext.Session.SetString("UsuarioLogueado", JsonSerializer.Serialize(usuario));
                
                // Lo mandamos a su página principal según su tipo
                // Si es admin va a Dashboardadmin.html, si es estudiante va a Dashboardestudiante.html, etc.
                return RedirectToAction("Dashboard", new { tipo = login.TipoUsuario });
            }

            // Si no encontramos al usuario, mostramos un mensaje de error
            return Content("Credenciales incorrectas. <a href='/Login'>Volver al login</a>", "text/html");
        }

        // Esta es la página a la que vas después de iniciar sesión
        [HttpGet("Dashboard")]
        public IActionResult Dashboard(string tipo)
        {
            // Mostramos la página de inicio según el tipo de usuario
            // tipo puede ser "admin", "docente" o "estudiante"
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "Pages", $"Dashboard{tipo}.html"), "text/html");
        }

        // Para cerrar la sesión (el botón de "Salir")
        [HttpGet("CerrarSesion")]
        public IActionResult CerrarSesion()
        {
            // Borramos todo lo que guardamos en la sesión (olvidamos que el usuario estaba logueado)
            HttpContext.Session.Clear();
            return RedirectToAction("Login"); // Lo mandamos de vuelta a la página de login
        }

        // Esta función lee el archivo donde guardamos a los usuarios
        private List<Usuario> CargarUsuarios()
        {
            // Primero miramos si existe el archivo usuarios.json
            if (System.IO.File.Exists(USERS_FILE))
            {
                // Si existe, lo leemos y convertimos a una lista de usuarios
                var json = System.IO.File.ReadAllText(USERS_FILE);
                return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
            }
            
            // Si el archivo no existe (primera vez que usamos el programa),
            // creamos unos usuarios de ejemplo
            var usuariosDefault = new List<Usuario>
            {
                new Usuario { Id = 1, Username = "admin", Password = "admin123", Tipo = "admin", Nombre = "Administrador", Email = "admin@escuela.com" },
                new Usuario { Id = 2, Username = "profesor1", Password = "docente123", Tipo = "docente", Nombre = "Juan Pérez", Email = "juan@escuela.com" },
                new Usuario { Id = 3, Username = "estudiante1", Password = "estudiante123", Tipo = "estudiante", Nombre = "María García", Email = "maria@escuela.com" }
            };

            // Guardamos estos usuarios de ejemplo en el archivo
            GuardarUsuarios(usuariosDefault);
            return usuariosDefault; // Y los devolvemos
        }

        // Esta función guarda la lista de usuarios en el archivo
        private void GuardarUsuarios(List<Usuario> usuarios)
        {
            // Convertimos la lista a un texto en formato JSON (como un diccionario organizado)
            var json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            // Escribimos ese texto en el archivo usuarios.json
            System.IO.File.WriteAllText(USERS_FILE, json);
        }
    }
}