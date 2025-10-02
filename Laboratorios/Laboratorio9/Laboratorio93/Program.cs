using System;

internal class Program
{
    private static void Main(string[] args)
    {
        double lado1, lado2, lado3;
        
        Console.WriteLine("Ingrese el lado 1:");
        lado1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el lado 2:");
        lado2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el lado 3:");    
        lado3 = double.Parse(Console.ReadLine());

        if (lado1 + lado2 > lado3 && lado1 + lado3 > lado2 && lado2 +lado3 > lado1)
                    {
            Console.WriteLine("Los lados forman un triángulo");
        }
        else
        {
            Console.WriteLine("Los lados no forman un triángulo");
        }
    }
}