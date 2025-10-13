using System;

class Parcial1
{
    static void Main(string[] args)
    {
        Parcial1 Parcial1 = new Parcial1();
        Parcial1.panel();
    }

    public int[,] mat;

    public void panel()
    {

        mat = new int[5, 5];
        int suma = 0;
        Random r = new Random(); 

        for (int f = 0; f < 5; f++)
        {
            for (int c = 0; c < 5; c++)
            {
                    // esto es para que genere los valores en figura de cruz
                if (f == 2 || c == 2)
                {
                    int N = r.Next(1, 100);

                    if (N % 2 == 0)
                    {
                        mat[f, c] = 0;
                    }
                    else
                    {
                        mat[f, c] = N;
                        suma += mat[f, c];
                    }
                }
             

                Console.Write(mat[f, c] + "      ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("La suma de los impares es: " + suma);
    }
}
