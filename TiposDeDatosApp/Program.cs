using System;

namespace TiposDeDatosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime fing = DateTime.UtcNow;
            DateTime fnac = DateTime.Parse("04/20/2009");
            //Creamos una instancia del objeto Estudiante.
            Estudiante alumno = new Estudiante(98646, "Luis Fernando", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing);
            alumno.GetInfoEstudiante();
            Estudiante aprendiz = new Estudiante(98647, "Luis Armando", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing);
            Console.WriteLine(Estudiante.GetInfoEstudiante(alumno));
            Console.WriteLine(Estudiante.GetInfoEstudiante(aprendiz));
            Estudiante[] misalumnos = {
                new Estudiante(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
                new Estudiante(98649, "Luis Alfonso", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
                new Estudiante(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
                new Estudiante(98649, "Luis Alfonso", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
                new Estudiante(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
                new Estudiante(98649, "Luis Alfonso", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing)
            };
            foreach (Estudiante e in misalumnos)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine(Estudiante.GetInfoEstudiante(e));
            }

            Docente[] misDocentes =
           {
               new Docente(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
               new Docente(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
               new Docente(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
               new Docente(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
               new Docente(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
               new Docente(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
               new Docente(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing),
               new Docente(98648, "Luis Federico", "Sanchez Perez","Calle con carera y numero","yosisoy@elmejor.com",31200000,fnac,fing)

            };
            foreach (Docente d in misDocentes)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine(Docente.GetInfoDocente(d));
            }
            

               
        }
    }
}
