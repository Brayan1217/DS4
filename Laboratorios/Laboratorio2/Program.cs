using System;
namespace Laboratorio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            //Ejemplo utilizando las variables de instancia de clase.
            client.FirstName = "Brayan";
            client.LastName = "Martinez";
            client.Age = 24;
            client.Id = 1;

            Console.WriteLine(client.GetFullName());
        }
    }

    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ushort Age { get; set; }
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}