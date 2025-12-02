namespace MatriculaApp.Models
{
    // MODELO QUE REPRESENTA UN USUARIO DEL SISTEMA
    public class Usuario
    {
        // IDENTIFICADOR ÚNICO DEL USUARIO
        public int Id { get; set; }
        
        // NOMBRE DE USUARIO PARA LOGIN
        public string Username { get; set; }
        
        // CONTRASEÑA DEL USUARIO
        public string Password { get; set; }
        
        // TIPO DE USUARIO: admin, docente o estudiante
        public string Tipo { get; set; } 
        
        // NOMBRE COMPLETO REAL DEL USUARIO
        public string Nombre { get; set; }
        
        // CORREO ELECTRÓNICO DEL USUARIO
        public string Email { get; set; }
    }
}
