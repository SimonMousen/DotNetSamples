using System;

namespace TiposDeDatosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime fing = DateTime.UtcNow;
            DateTime fnac = DateTime.Parse("2007/11/06");
            Estudiante aprendiz = new Estudiante(1033, "Simon", "Sierra Lopez", "Cra64#61-06", "simonuwusierra@gmail.com", 4560480, fnac, fing);
            
            aprendiz.GetInfoEstudiante();
            Console.WriteLine("\n --------------");
            Console.WriteLine(Estudiante.GetInfoEstudiante(aprendiz));

            Estudiante[] misalumnos = {
                new Estudiante(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing)
            };

            foreach (Estudiante e in misalumnos)
            {
                Console.WriteLine("\n --------------------------------");
                Console.WriteLine(Estudiante.GetInfoEstudiante(e));
            }

            Docente[] misDocentes =
           {
               new Docente(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing)

            };

            foreach (Docente d in misDocentes)
            {
                Console.WriteLine("\n --------------------------------");
                Console.WriteLine(Docente.GetInfoDocente(d));
            }
        }
    }
}
