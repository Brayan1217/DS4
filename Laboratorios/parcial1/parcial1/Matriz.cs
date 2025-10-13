using System;

class Matriz
{
    private int[,] matriz;
    private int n;

    public void ingresarValores()
    {
        // valores deben ser inpares
        do
        {
            Console.WriteLine("Ingrese la dimension de la matriz:");
            String linea = Console.ReadLine();
            n = int.Parse(linea);
            if (n % 2 == 0) 
            {
                Console.WriteLine("n debe ser inpar");
            }

        } while (n % 2 == 0);

        //matroz
        matriz = new int[n, n];
        Random random = new Random();

        // llena con ceros
        for (int f = 0; f < n; f++)
        {
            for (int c = 0; c < n; c++)
            {
                matriz[f, c] = 0;
            }
        }

        ///matrix random
        for (int i = 0; i < n; i++)
        {
            matriz[i, i] = random.Next(1, 101); //izq

            matriz[i, n - 1 - i] += random.Next(1, 101); //drec
        }
    }

    public void imprimir()
    {
        for (int f = 0; f < n; f++)
        {
            for (int c = 0; c < n; c++)
            {
                //alineado
                Console.Write( matriz[f, c] + "   ");
            }
            // salto de linea
            Console.WriteLine();
        }
    }

    public int Suma()
    {
        int suma = 0;
        for (int i = 0; i < n; i++)
        {
            //matriz izquierda
            suma += matriz[i, i];

            //matriz derecha diferente de  0 para no sumar dos veces 
            if (i != n - 1 - i)
            {
                suma += matriz[i, n - 1 - i];
            }
        } 
        return suma;
    } 
      
}