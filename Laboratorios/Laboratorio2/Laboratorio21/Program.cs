using System;


namespace Laboratorio21
{ 
    public class Program
    {
        public static void Main()
        {
            //Asignando valores a variable estatica.
            MyClass.Valor = 1;
            Console.WriteLine(MyClass.Valor);
        }

    }
    public class MyClass
    {
        //Variable estatica.
        public static int Valor;
    }

}