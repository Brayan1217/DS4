using System;

internal class CalculosMatematico
{
    public int Calcular(int a, int b)
    {
        int suma = a + b;
        int resta = a - b;
        int resultado = suma * resta;
        return resultado;
    }
    public double CalcularArea(double radio)
    {
        double area = Math.PI * Math.Pow(radio, 2);
        return area;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero,segundoNumero,resultado_total;
        double radio, areaCirculo;

        CalculosMatematico calculos = new CalculosMatematico();
        Console.WriteLine("Ingrese el primer numero:");
        primerNumero = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el segundo numero:");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        resultado_total = calculos.Calcular(primerNumero,segundoNumero);
        Console.WriteLine("El resultado de la operacion es:" +resultado_total );

        Console.WriteLine("Ingrese el radio del circulo:");
        radio = Convert.ToDouble(Console.ReadLine());

        areaCirculo = calculos.CalcularArea(radio);
        Console.WriteLine("El area del circulo es:" + areaCirculo);

    }
}