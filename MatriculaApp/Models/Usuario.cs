namespace MatriculaApp.Models
{
    // Esta clase representa a una persona que puede usar el sistema
    public class Usuario
    {
        // Un número único para identificar a cada usuario (como número de carnet)
        public int Id { get; set; }
        
        // El nombre de usuario para iniciar sesión (como un apodo)
        public string Username { get; set; }
        
        // La contraseña para verificar que es la persona correcta
        public string Password { get; set; }
        
        // El tipo de usuario: admin, docente o estudiante
        public string Tipo { get; set; } 
        
        // El nombre completo real de la persona
        public string Nombre { get; set; }
        
        // El correo electrónico de contacto
        public string Email { get; set; }
    }
}