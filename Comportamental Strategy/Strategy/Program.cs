using Strategy;

Console.WriteLine("========================================");
Console.WriteLine("  Padrão Strategy - Compressão de Arquivos");
Console.WriteLine("========================================");
Console.WriteLine();

// Cria o contexto com a estratégia padrão (RAR)
var contexto = new CompressaoContext(new CompressaoRar());

Console.Write("Informe o nome do arquivo a comprimir: ");
string nomeArquivo = Console.ReadLine() ?? string.Empty;

Console.WriteLine();
Console.WriteLine("Informe o tipo de compressão a ser usada:");
Console.WriteLine("  1 - RAR");
Console.WriteLine("  2 - ZIP");
Console.WriteLine("  3 - GZIP");
Console.Write("Opção: ");
string opcao = Console.ReadLine() ?? "1";

Console.WriteLine();

// Altera a estratégia em tempo de execução conforme a escolha do usuário
switch (opcao)
{
    case "2":
        contexto.DefinirEstrategia(new CompressaoZip());
        break;
    case "3":
        contexto.DefinirEstrategia(new CompressaoGzip());
        break;
    default:
        // Mantém a estratégia padrão (RAR)
        break;
}

// Executa a compactação usando a estratégia selecionada
contexto.CriarArquivoCompactado(nomeArquivo);
