using System;

class PruebaVector
{
    private int[] sueldos; // Declaracion de vector

    public void Cargar()
    {
        sueldos = new int[5]; // inicializacion del vector en 5
        for (int f = 0; f < 5; f++)
        {
            Console.Write("Ingrese el sueldo del operario " + (f + 1) + ": ");
            String linea;
            linea = Console.ReadLine();
            sueldos[f] = int.Parse(linea);
        }
    }

    public void Imprimir()
    {
        Console.WriteLine("Los 5 sueldos de los operarios:");
        for (int f = 0; f < 5; f++)
        {
            Console.WriteLine("Operario " + (f + 1) + ": $" + sueldos[f]);
        }
        Console.WriteLine();
    }

    // Main principal
    static void Main(string[] args)
    {
        PruebaVector pv = new PruebaVector();
        pv.Cargar();
        pv.Imprimir();

        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }
}