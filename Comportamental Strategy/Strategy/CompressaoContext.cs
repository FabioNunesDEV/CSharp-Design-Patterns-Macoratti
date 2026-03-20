namespace Strategy;

/// <summary>
/// Classe Contexto - mantém uma referência para a estratégia de compressão
/// e delega a execução do algoritmo para o objeto estratégia.
/// </summary>
public class CompressaoContext
{
    private ICompressao _estrategia;

    public CompressaoContext(ICompressao estrategia)
    {
        _estrategia = estrategia;
    }

    /// <summary>
    /// Permite trocar a estratégia de compressão em tempo de execução.
    /// </summary>
    public void DefinirEstrategia(ICompressao estrategia)
    {
        _estrategia = estrategia;
    }

    /// <summary>
    /// Delega a compactação para a estratégia atualmente configurada.
    /// </summary>
    public void CriarArquivoCompactado(string nomeArquivo)
    {
        _estrategia.ComprimirArquivo(nomeArquivo);
    }
}
