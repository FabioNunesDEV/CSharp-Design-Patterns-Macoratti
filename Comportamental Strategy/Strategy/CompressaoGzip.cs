namespace Strategy;

/// <summary>
/// Estratégia concreta - compactação no formato GZIP.
/// </summary>
public class CompressaoGzip : ICompressao
{
    public void ComprimirArquivo(string nomeArquivo)
    {
        Console.WriteLine($"O arquivo \"{nomeArquivo}\" foi compactado usando o formato GZIP.");
        Console.WriteLine($"Um arquivo com a extensão \"{nomeArquivo}.gz\" foi criado.");
    }
}
