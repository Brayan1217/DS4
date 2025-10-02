using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Precio del producto:");
        double precio = double.Parse(Console.ReadLine());

        if (precio <= 0)
        {
            Console.WriteLine("El precio debe ser positivo");
            return;
        }
        Console.WriteLine("Forma de pago: (E/T)");
        char forma = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        if (forma == 'T')
        {
            Console.WriteLine("Ingrese el numero de la tarjeta");
            string tarjeta = Console.ReadLine();
            if (tarjeta.Length == 16)
                Console.WriteLine("Pago aprobado");
            else
                Console.WriteLine("Pago rechazado");
        }
        else if (forma == 'E')
        {
            Console.WriteLine($"Pago en efectivo de {precio}");
        }
    }


}