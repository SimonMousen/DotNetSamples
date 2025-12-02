namespace MatriculaApp.Models
{
    // MODELO QUE REPRESENTA LOS DATOS DEL FORMULARIO DE LOGIN
    public class LoginModel
    {
        // NOMBRE DE USUARIO PARA INICIAR SESIÓN
        public string Username { get; set; }
        
        // CONTRASEÑA DEL USUARIO
        public string Password { get; set; }
        
        // TIPO DE USUARIO: admin, docente o estudiante
        public string TipoUsuario { get; set; }
    }
}