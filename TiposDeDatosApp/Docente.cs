using System;

namespace TiposDeDatosApp
{
    //La clase estudiante hereda de la clase Persona.
    public class Docente : Persona
    {
        //no necesito agregar ninguna propiedad porque 
        //la clase base tiene todos los campos que requiere.
        //Creo un Constructor para la clase que permit ainicializar las propiedades.       

        public Docente(int idest, string nom, string apel, string dir, string ema, int tel, DateTime fen, DateTime fin)
        {
            this.Id = idest;
            this.Nombres = nom;
            this.Apellidos = apel;
            this.Direccion = dir;
            this.Email = ema;
            this.Telefono = tel;
            this.FeNacimiento = fen;
            this.FeIngreso = fin;
        }
        public void GetInfoDocente()
        {
            Console.WriteLine(this.Nombres + " " + this.Apellidos);
        }
        public static string GetInfoDocente(Docente e)
        {
            string datos = $"Soy el Docente cod:{e.Id},\n mi nombre es {e.Nombres} {e.Apellidos}, \n mi dirección:{e.Direccion}\n y mi correo: {e.Email},\n Nací el {e.FeNacimiento} e ingresé el {e.FeIngreso}";
            return datos;
        }
    }
}