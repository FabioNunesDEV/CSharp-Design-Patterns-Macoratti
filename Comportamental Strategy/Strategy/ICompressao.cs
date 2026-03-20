namespace Strategy;

/// <summary>
/// Interface Strategy - define o contrato comum para todas as estratégias de compressão.
/// </summary>
public interface ICompressao
{
    void ComprimirArquivo(string nomeArquivo);
}
