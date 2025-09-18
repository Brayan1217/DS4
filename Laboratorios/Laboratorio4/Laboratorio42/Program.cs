using System;
    class Program
{
    static void Main(String[] args)
    {
        int fac = 1, n;
        string linea;
        Console.Write("Ingrese un numero entero: ");
        linea = Console.ReadLine();
        n = int.Parse(linea);
        for (int i = 1; i <= n; i++)
        {
            fac = fac * i;
        }
        Console.WriteLine("El factorial de " + n + " es: " + fac);
        Console.ReadKey();
    }
}