using System;
class Program
{
    static void Main(String[] args)
    {
        int suma, cant, valor, promedio;
        string linea;
        suma = 0;
        cant = 0;
        do
        {
            Console.Write("Ingrese un valor entero (0 para finalizar): ");
            linea = Console.ReadLine();
            valor = int.Parse(linea);
            if (valor != 0)
            {
                suma = suma + valor;
                cant = cant + 1;
            }
        } while (valor != 0);
        if (cant != 0) {
            promedio = suma / cant;
            Console.WriteLine(" El promedio de los valores ingresados es");
    
                Console.WriteLine(promedio);
        }
        else
        {
            Console.WriteLine("No se ingresaron valores.");

        }
        Console.ReadKey();
    }
}