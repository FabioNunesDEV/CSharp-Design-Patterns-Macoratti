namespace Strategy;

/// <summary>
/// Estratégia concreta - compactação no formato ZIP.
/// </summary>
public class CompressaoZip : ICompressao
{
    public void ComprimirArquivo(string nomeArquivo)
    {
        Console.WriteLine($"O arquivo \"{nomeArquivo}\" foi compactado usando o formato ZIP.");
        Console.WriteLine($"Um arquivo com a extensão \"{nomeArquivo}.zip\" foi criado.");
    }
}
