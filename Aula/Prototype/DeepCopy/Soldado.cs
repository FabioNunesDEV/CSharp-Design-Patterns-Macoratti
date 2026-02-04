namespace Prototype.DeepCopy;

public sealed class Soldado : ICloneable
{
    public string Nome { get; set; } = string.Empty;
    public string Arma { get; set; } = string.Empty;
    public Acessorio Acessorio { get; set; } = new();

    public Soldado() { }

    public Soldado(Soldado origem)
    {
        Nome = origem.Nome;
        Arma = origem.Arma;
        Acessorio = origem.Acessorio;
    }

    public override string ToString()
    {
        return $"Soldado: {Nome}\nArma: {Arma}\nAcessório: {Acessorio.Nome}\n";
    }

    public object Clone()
    {
        Soldado soldado = (Soldado)this.MemberwiseClone();
        soldado.Acessorio = (Acessorio)this.Acessorio.Clone();
        return soldado;
    }
}
