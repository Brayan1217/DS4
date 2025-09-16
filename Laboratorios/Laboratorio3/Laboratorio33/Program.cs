using System;



internal class CalcularPerimetro
{
    public double CalculoPerimetro(double largo, double ancho)
   {
        double perimetro = 2 * (largo + ancho);
        return perimetro;
    }

}

internal class Program
{
    private static void Main(string[] args)
    {
        double largo, ancho, perimetro;

        CalcularPerimetro rectangulo = new CalcularPerimetro();

        Console.WriteLine("Ingrese el largo del rectangulo");
        largo=Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Ingrese el ancho del rectangulo");
        ancho=Convert.ToDouble(Console.ReadLine());

        perimetro=rectangulo.CalculoPerimetro(largo, ancho);

        Console.WriteLine("El perimetro del rectangulo es: " + perimetro);
    }
}
   

