using Microsoft.AspNetCore.Mvc;
using MatriculaApp.Models;
using System.Text.Json;

namespace MatriculaApp.Controllers
{
    [Route("Matricula")] // ESTA CLASE RESPONDE A LAS RUTAS QUE COMIENZAN CON /Matricula
    public class MatriculaController : Controller
    {
        // MÉTODO GET PARA /Matricula - MUESTRA EL FORMULARIO DE MATRÍCULA
        [HttpGet("")]
        public IActionResult Form()
        {
            // DEVUELVE EL FORMULARIO HTML DESDE LA CARPETA Pages
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "Pages", "MatriculaForm.html"), "text/html");
        }

        // MÉTODO POST PARA /Matricula/Guardar - GUARDA LOS DATOS DE MATRÍCULA
        [HttpPost("Guardar")]
        public IActionResult Guardar([FromForm] Matricula datos)
        {
            // CONVIERTE LOS DATOS A FORMATO JSON
            var json = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });
            // GUARDA LOS DATOS EN UN ARCHIVO JSON (SOBREESCRIBE EL ANTERIOR)
            System.IO.File.WriteAllText("matricula.json", json);
            // MUESTRA MENSAJE DE CONFIRMACIÓN
            return Content("Matrícula guardada correctamente en matricula.json");
        }
    }
}