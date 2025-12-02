namespace MatriculaApp.Models
{
    // MODELO QUE REPRESENTA UNA MATRÍCULA ESCOLAR
    public class Matricula
    {
        // NOMBRE COMPLETO DEL ESTUDIANTE
        public string Nombre { get; set; }
        
        // NÚMERO DE DOCUMENTO DE IDENTIDAD
        public string Documento { get; set; }
        
        // CURSO AL QUE SE MATRICULA EL ESTUDIANTE
        public string Curso { get; set; }
        
        // EDAD DEL ESTUDIANTE
        public int Edad { get; set; }
        
        // CORREO ELECTRÓNICO DEL ESTUDIANTE
        public string Email { get; set; }
    }
}