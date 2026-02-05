namespace Prototype.DeepCopy;

public sealed class Acessorio 
{
    public string Nome { get; set; } = string.Empty;

    public override string ToString() => Nome;

    public object Clone() => MemberwiseClone();
}
