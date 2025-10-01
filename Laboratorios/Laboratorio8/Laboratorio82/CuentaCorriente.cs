public class CuentaCorriente : Cuenta
{
    public CuentaCorriente(string prntIdCuenta) : base(prntIdCuenta)
    {
    }

    public override void CalcularInteres()
    {
        System.Console.WriteLine("CuentaCorriente.CalcularIntereses() efectuado para" + "la cuenta {0}", getIdCuenta());
    }
}