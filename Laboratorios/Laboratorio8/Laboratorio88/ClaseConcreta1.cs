class ClaseConcreta1 : ClaseAbstracta
{
    protected override string TomarValor()
    {
        return "Clase Concreta 1";
    }
    public override string prefixValor(string prefix)
    {
        return $"{prefix} - Clase Concreta 1";
    }
}