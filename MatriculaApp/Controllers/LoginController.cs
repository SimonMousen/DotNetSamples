using Microsoft.AspNetCore.Mvc;
using MatriculaApp.Models;
using System.Text.Json;

namespace MatriculaApp.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        private const string USERS_FILE = "usuarios.json";
        private List<Usuario> _usuarios;

        public LoginController()
        {
            _usuarios = CargarUsuarios();
        }

        [HttpGet("")]
        public IActionResult Login()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "Pages", "Login.html"), "text/html");
        }

        [HttpPost("Validar")]
        public IActionResult Validar([FromForm] LoginModel login)
        {
            var usuario = _usuarios.FirstOrDefault(u => 
                u.Username == login.Username && 
                u.Password == login.Password && 
                u.Tipo == login.TipoUsuario);

            if (usuario != null)
            {
                HttpContext.Session.SetString("UsuarioLogueado", JsonSerializer.Serialize(usuario));
                
                return RedirectToAction("Dashboard", new { tipo = login.TipoUsuario });
            }

            return Content("Credenciales incorrectas. <a href='/Login'>Volver al login</a>", "text/html");
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard(string tipo)
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "Pages", $"Dashboard{tipo}.html"), "text/html");
        }

        [HttpGet("CerrarSesion")]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private List<Usuario> CargarUsuarios()
        {
            if (System.IO.File.Exists(USERS_FILE))
            {
                var json = System.IO.File.ReadAllText(USERS_FILE);
                return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
            }
            
            var usuariosDefault = new List<Usuario>
            {
                new Usuario { Id = 1, Username = "admin", Password = "admin123", Tipo = "admin", Nombre = "Administrador", Email = "admin@escuela.com" },
                new Usuario { Id = 2, Username = "profesor1", Password = "docente123", Tipo = "docente", Nombre = "Juan Pérez", Email = "juan@escuela.com" },
                new Usuario { Id = 3, Username = "estudiante1", Password = "estudiante123", Tipo = "estudiante", Nombre = "María García", Email = "maria@escuela.com" }
            };

            GuardarUsuarios(usuariosDefault);
            return usuariosDefault;
        }

        private void GuardarUsuarios(List<Usuario> usuarios)
        {
            var json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(USERS_FILE, json);
        }
    }
}