namespace MatriculaApp.Models
{
    // Esta clase representa los datos que vienen del formulario de login
    public class LoginModel
    {
        // El nombre de usuario que escribe la persona
        public string Username { get; set; }
        
        // La contraseña que escribe la persona  
        public string Password { get; set; }
        
        // El tipo de usuario que selecciona (admin, docente o estudiante)
        public string TipoUsuario { get; set; }
    }
}