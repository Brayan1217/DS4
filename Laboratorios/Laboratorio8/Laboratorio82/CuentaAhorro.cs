public class CuentaAhorro: Cuenta
{
    public CuentaAhorro(string prntIdCuenta) : base(prntIdCuenta)
    {
    }
    public override void CalcularInteres()
    {
        System.Console.WriteLine("CuentaAhorro.CalcularIntereses() efectuado para" + "la cuenta {0}", getIdCuenta());
    }
}