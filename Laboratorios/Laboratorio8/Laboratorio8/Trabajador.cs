using System;


namespace Laboratorio8
{
   class Trabajador : Persona
    {
        //Campo que almacena el sueldo del trabajador
        public int Sueldo;

        public Trabajador(string nombre, int edad, string nif, int sueldo) : base(nombre, edad, nif)
        {
            //Inicializamos cada Tabajador en base al constructor de Persona
            Sueldo = sueldo;
        }
    }
}
