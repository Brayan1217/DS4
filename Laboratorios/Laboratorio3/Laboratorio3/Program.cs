internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el primer numero: ");
        int primerNumero = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el segundo numero: ");
        int segundoNumero = Convert.ToInt32(Console.ReadLine());
        int suma = primerNumero + segundoNumero;
        Console.WriteLine("La suma de los dos numeros es: " + suma);
    }
}