using System;
using System.Numerics;

namespace CalculadoraSimple
{
    class Program

    {
        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Calculadora");
                Console.WriteLine("1.Suma");
                Console.WriteLine("2.Resta");
                Console.WriteLine("3.Multiplicacion");
                Console.WriteLine("4.Division");
                Console.WriteLine("5.Salir");

                String opcion = Console.ReadLine();

                if (opcion == "5")
                {
                    continuar = false;
                    Console.WriteLine("Hasta la proxima");
                    break;
                }
                Console.Write("Ingresa el primer número:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ingresa el segundo número:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double resultado = 0;
                bool operacionValida = true;


                switch (opcion)
                {
                    case "1":
                        resultado = Sumar(num1, num2);
                        Console.WriteLine($"Resulado: {num1} + {num2} = {resultado} ");
                        break;
                    case "2":
                        resultado = Restar(num1, num2);
                        Console.WriteLine($"Resulado: {num1} - {num2} = {resultado} ");
                        break;
                    case "3":
                        resultado = Multiplicar(num1, num2);
                        Console.WriteLine($"Resulado: {num1} * {num2} = {resultado} ");
                        break;
                    case "4":
                        if (num2 == 0)
                        {
                            Console.WriteLine("Error: No se puede dividir entre cero.");
                            operacionValida = false;
                        }
                        else
                        {
                            resultado = Division(num1, num2);
                            Console.WriteLine($"Resultado: {num1} / {num2} = {resultado}");
                        }
                        break;
                }

                if (operacionValida)
                {
                    Console.WriteLine($"Resultado guardado: {resultado}");
                }

                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        static double Sumar(double a, double b)
        {
            return a + b;
        }
        static double Restar(double a, double b)
        {
            return a - b;
        }
        static double Multiplicar(double a, double b)
        {
            return a * b;
        }
        static double Division(double a, double b)
        {
            return a / b;


        }
    }
}


    