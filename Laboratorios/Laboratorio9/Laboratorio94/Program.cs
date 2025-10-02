using System;

public class Aleatorio
{
    private Random r = new Random();
    public int GenerarNumero(int min, int max)
    {
        return r.Next(min, max + 1);
    }
    public int[] GenerarArreglo(int min, int max)
    {
        int[] arreglo = new int[10];
        for (int i = 0; i < arreglo.Length; i++)
        {
            arreglo[i] = GenerarNumero(min, max);
        }
        return arreglo;
    }
    public static void Main(string[] args)
    {
        Aleatorio a = new Aleatorio();

        int num = a.GenerarNumero(1, 10);
        Console.WriteLine(num);

        int[] arreglo = a.GenerarArreglo(1, 50);
        Console.WriteLine("El arreglo es:");
        foreach (int n in arreglo)

            Console.Write(n + " ");

    }
}