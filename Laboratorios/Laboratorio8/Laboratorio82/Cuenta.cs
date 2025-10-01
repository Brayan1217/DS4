
public class Cuenta

{
    private string idCuenta;

    public Cuenta(string prntIdCuenta)
    {
     
        idCuenta = prntIdCuenta;
        System.Console.WriteLine("Constructor Clase Base para cuernta {0}", prntIdCuenta);
    }
    public virtual void CalcularInteres()
    {
        System.Console.WriteLine("Cuenta.CalcularIntereses() efectuado para la cuenta {0}", this.idCuenta);
    }

    public string getIdCuenta()
    {
        return this.idCuenta;
    }
}