namespace Strategy;

/// <summary>
/// Estratégia concreta - compactação no formato RAR.
/// </summary>
public class CompressaoRar : ICompressao
{
    public void ComprimirArquivo(string nomeArquivo)
    {
        Console.WriteLine($"O arquivo \"{nomeArquivo}\" foi compactado usando o formato RAR.");
        Console.WriteLine($"Um arquivo com a extensão \"{nomeArquivo}.rar\" foi criado.");
    }
}
