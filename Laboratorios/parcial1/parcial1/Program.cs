using System;

class Program
{
    static void Main(string[] args)
    {
        Matriz maz = new Matriz();
        maz.ingresarValores();
        maz.imprimir();

        int suma = maz.Suma();
        Console.WriteLine("La suma de las diagonales es: " + suma);
    }
}