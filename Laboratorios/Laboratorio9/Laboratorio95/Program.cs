using System;

internal class Program
{
    public static void Main(string[] args)
    {
        Aleatorio a = new Aleatorio();

        int num1= a.GenerarNumero(1, 30);
        int num2= a.GenerarNumero(1, 30);

        Console.WriteLine("Ingrese un minimo:");
        int min = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese un maximo:");
        int max = int.Parse(Console.ReadLine());

        int[] unico = new int[10];
        for (int i = 0;i<unico.Length; i++)
        { int num;
          bool repetido;
            do
            {
                num= a.GenerarNumero(min, max);
               repetido=false;
                for (int j=0;j<i;j++)
                {
                    if(unico[j]==num)
                    {
                        repetido=true;
                        break;
                    }
                }
            }while(repetido);
            unico[i]=num;
        }

        Console.WriteLine("El arreglo unico es:");
        foreach (int n   in unico)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
    }

}