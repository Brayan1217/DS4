class ClaseConcreta2 : ClaseAbstracta
{
    protected override string TomarValor()
    {
        return "Clase Concreta 2";
    }
    public override string prefixValor(string prefix)
    {
        return $"{prefix} - Clase Concreta 2";
    }
}