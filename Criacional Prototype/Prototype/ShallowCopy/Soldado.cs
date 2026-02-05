using System;

namespace Prototype.ShallowCopy;

public sealed class Soldado : ICloneable
{
    public string Nome { get; set; } = string.Empty;
    public string Arma { get; set; } = string.Empty;
    public Acessorio Acessorio { get; set; } = new();


    public Soldado() { }

    private Soldado(Soldado origem)
    {
        Nome = origem.Nome;
        Arma = origem.Arma;
        Acessorio = origem.Acessorio;
    }

    public object Clone()
    {
        return new Soldado(this);
    }

    public override string ToString()
    {
        return $"Soldado: {Nome}\nArma: {Arma}\nAcessório: {Acessorio.Nome}\n";
    }
}
