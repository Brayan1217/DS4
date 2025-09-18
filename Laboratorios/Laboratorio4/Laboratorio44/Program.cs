class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la nota del estudiante:");
        float score=float.Parse(Console.ReadLine());

        if (score >= 7)
        {
            Console.WriteLine();
            Console.WriteLine($"Su nota es {score}, usted ha aprobado.");

        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"Su nota es {score} ha reprobado, debe repetir.");
        }
    }
}