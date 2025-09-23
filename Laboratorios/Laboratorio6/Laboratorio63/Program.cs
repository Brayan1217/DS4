class Program
{
    static void main(string[] args)
    {
        try
        {
            int[] myNumber = { 1, 2, 3 };
            Console.WriteLine(myNumber[10]);
        }
        catch (Exception e)
        {
            Console.WriteLine("Algo salio mal, valide el indice del arreglo");
        }
        finally
        {
            Console.WriteLine("continuacion de la aplicacion, luego del bloque try/catch");
        }
    }
}