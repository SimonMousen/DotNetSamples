// Este es el controlador que maneja las matrículas
[Route("Matricula")] // Responde a la dirección /Matricula
public class MatriculaController : Controller
{
    // Muestra el formulario de matrícula
    [HttpGet("")]
    public IActionResult Form()
    {
        // Devuelve la página HTML del formulario
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "Pages", "MatriculaForm.html"), "text/html");
    }

    // Guarda los datos del formulario
    [HttpPost("Guardar")]
    public IActionResult Guardar([FromForm] Matricula datos)
    {
        // Convierte los datos a formato JSON
        var json = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });
        
        // Guarda en un archivo (solo guarda la última matrícula)
        System.IO.File.WriteAllText("matricula.json", json);
        
        // Muestra mensaje de confirmación
        return Content("Matrícula guardada correctamente en matricula.json");
    }
}