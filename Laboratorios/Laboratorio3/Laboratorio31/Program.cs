using System;

internal class CalculosMatematicos
{
    public int Calcular(int a, int b)
    {
        int suma = a + b;
        int resta = a - b;
        int resultado = suma * resta;

        return resultado;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero, segundoNumero, resultado_total;

        CalculosMatematicos calculos = new CalculosMatematicos();

        Console.WriteLine("Ingrese el primer numero: ");
        primerNumero = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el segundo numero: ");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        resultado_total=calculos.Calcular(primerNumero,segundoNumero);
        Console.WriteLine("El resultado de la operacion es: " + resultado_total);
}

    
}