using Microsoft.AspNetCore.Mvc;
using MatriculaApp.Models;
using System.Text.Json;

namespace MatriculaApp.Controllers
{
    [Route("Login")] // ESTA CLASE RESPONDE A LAS RUTAS QUE COMIENZAN CON /Login
    public class LoginController : Controller
    {
        private const string USERS_FILE = "usuarios.json"; // NOMBRE DEL ARCHIVO DONDE SE GUARDAN LOS USUARIOS
        private List<Usuario> _usuarios; // LISTA DE USUARIOS CARGADA EN MEMORIA

        // CONSTRUCTOR: SE EJECUTA CUANDO SE CREA UNA INSTANCIA DEL CONTROLADOR
        public LoginController()
        {
            _usuarios = CargarUsuarios(); // CARGA LOS USUARIOS DEL ARCHIVO AL INICIAR
        }

        // MÉTODO GET PARA /Login - MUESTRA LA PÁGINA DE INICIO DE SESIÓN
        [HttpGet("")]
        public IActionResult Login()
        {
            // DEVUELVE EL ARCHIVO HTML DE LOGIN DESDE LA CARPETA Pages
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "Pages", "Login.html"), "text/html");
        }

        // MÉTODO POST PARA /Login/Validar - VALIDA LAS CREDENCIALES DEL USUARIO
        [HttpPost("Validar")]
        public IActionResult Validar([FromForm] LoginModel login)
        {
            // BUSCA UN USUARIO QUE COINCIDA CON USERNAME, PASSWORD Y TIPO
            var usuario = _usuarios.FirstOrDefault(u => 
                u.Username == login.Username && 
                u.Password == login.Password && 
                u.Tipo == login.TipoUsuario);

            // SI ENCUENTRA AL USUARIO (CREDENCIALES CORRECTAS)
            if (usuario != null)
            {
                // GUARDA EL USUARIO EN LA SESIÓN COMO STRING JSON
                HttpContext.Session.SetString("UsuarioLogueado", JsonSerializer.Serialize(usuario));
                
                // REDIRIGE AL DASHBOARD SEGÚN EL TIPO DE USUARIO
                return RedirectToAction("Dashboard", new { tipo = login.TipoUsuario });
            }

            // SI LAS CREDENCIALES SON INCORRECTAS, MUESTRA MENSAJE DE ERROR
            return Content("Credenciales incorrectas. <a href='/Login'>Volver al login</a>", "text/html");
        }

        // MÉTODO GET PARA /Login/Dashboard - MUESTRA EL PANEL SEGÚN EL TIPO DE USUARIO
        [HttpGet("Dashboard")]
        public IActionResult Dashboard(string tipo)
        {
            // DEVUELVE EL DASHBOARD CORRESPONDIENTE (admin, docente o estudiante)
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "Pages", $"Dashboard{tipo}.html"), "text/html");
        }

        // MÉTODO GET PARA /Login/CerrarSesion - CIERRA LA SESIÓN DEL USUARIO
        [HttpGet("CerrarSesion")]
        public IActionResult CerrarSesion()
        {
            // LIMPIA TODOS LOS DATOS DE LA SESIÓN
            HttpContext.Session.Clear();
            // REDIRIGE AL FORMULARIO DE LOGIN
            return RedirectToAction("Login");
        }

        // MÉTODO PRIVADO PARA CARGAR USUARIOS DESDE EL ARCHIVO JSON
        private List<Usuario> CargarUsuarios()
        {
            // VERIFICA SI EXISTE EL ARCHIVO DE USUARIOS
            if (System.IO.File.Exists(USERS_FILE))
            {
                // LEE Y DESERIALIZA EL ARCHIVO JSON
                var json = System.IO.File.ReadAllText(USERS_FILE);
                return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
            }
            
            // SI NO EXISTE EL ARCHIVO, CREA USUARIOS POR DEFECTO
            var usuariosDefault = new List<Usuario>
            {
                // USUARIO ADMINISTRADOR
                new Usuario { Id = 1, Username = "admin", Password = "admin123", Tipo = "admin", Nombre = "Administrador", Email = "admin@escuela.com" },
                // USUARIO DOCENTE
                new Usuario { Id = 2, Username = "profesor1", Password = "docente123", Tipo = "docente", Nombre = "Juan Pérez", Email = "juan@escuela.com" },
                // USUARIO ESTUDIANTE
                new Usuario { Id = 3, Username = "estudiante1", Password = "estudiante123", Tipo = "estudiante", Nombre = "María García", Email = "maria@escuela.com" }
            };

            // GUARDA LOS USUARIOS POR DEFECTO EN EL ARCHIVO
            GuardarUsuarios(usuariosDefault);
            return usuariosDefault; // RETORNA LA LISTA DE USUARIOS POR DEFECTO
        }

        // MÉTODO PRIVADO PARA GUARDAR USUARIOS EN EL ARCHIVO JSON
        private void GuardarUsuarios(List<Usuario> usuarios)
        {
            // CONVIERTE LA LISTA A FORMATO JSON CON INDENTACIÓN
            var json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            // ESCRIBE EL JSON EN EL ARCHIVO
            System.IO.File.WriteAllText(USERS_FILE, json);
        }
    }
}