namespace Command;

/// <summary>
/// Receiver (GoF): contém a lógica real do negócio.
/// 
/// Na analogia do restaurante: o <c>Chef</c> sabe "como fazer" (preparar prato e sobremesa).
/// O comando apenas delega a execução para este receiver.
/// </summary>
public class Chef
{
    public void PreparandoPrato()
    {
        Console.WriteLine($"Chef esta preparando o prato : Frango Marinado com especiarias...\n");
    }

    public void PreparandoSobremessa()
    {
        Console.WriteLine("Chef esta preparando a sobremesa : Petit Gateau...\n");
    }
}
