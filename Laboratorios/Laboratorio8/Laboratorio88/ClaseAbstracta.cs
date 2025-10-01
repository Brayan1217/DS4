abstract class ClaseAbstracta
{
    //Se fuerza la herencia de  la clase para defnir estos métodos
    abstract protected string TomarValor();
    abstract protected string prefixValor(string prefix);
    //Metodo comun 
    public void printOut()
    {
        Console.WriteLine(TomarValor());
    }
}