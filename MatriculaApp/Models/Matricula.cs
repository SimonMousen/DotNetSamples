namespace MatriculaApp.Models
{
    // Esta clase guarda los datos de una matrícula escolar
    public class Matricula
    {
        // El nombre completo del estudiante
        public string Nombre { get; set; }
        
        // El número de documento de identidad
        public string Documento { get; set; }
        
        // El curso al que se quiere matricular
        public string Curso { get; set; }
        
        // La edad del estudiante
        public int Edad { get; set; }
        
        // El correo electrónico para contactar
        public string Email { get; set; }
    }
}