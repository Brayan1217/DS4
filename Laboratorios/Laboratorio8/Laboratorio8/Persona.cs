using System;


namespace Laboratorio8
{
    internal class Persona
    {
        //Campo de cada objeto que almacena su nombre
        public string Nombre;

        //Campo de cada objeto que almacena su edad
        public int Edad;

        //campo de cada objeto que almacena su NIF

        public string NIF;

        void Cumpleaños() //Incrementa en 1 la edad de la persona
        {
            Edad++;
        }

        //Constructor de la clase Persona

        public Persona(string nombre, int edad, string nif)
        { 
            Nombre = nombre;
            Edad = edad;    
            NIF = nif;
        }
    }
}
