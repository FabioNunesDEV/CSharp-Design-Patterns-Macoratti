using System.Globalization;
using Adapter.Adaptee;
using Adapter.Domain;
using Adapter.Target;

namespace Adapter.Adapter;

// Adapter (Object Adapter)
// ------------------------
// Faz a ponte entre o contrato esperado pelo Cliente (Target)
// e a interface do componente legado (Adaptee).
//
// Versão "Object Adapter":
//   - usa composição (tem uma referência para o Adaptee)
//   - é a forma mais comum em C# (sem herança múltipla de classes)
public sealed class AlunoAdapter : IProcessaMensalidades
{
    private readonly SistemaMensalidades _sistemaMensalidades;

    public AlunoAdapter(SistemaMensalidades sistemaMensalidades)
        => _sistemaMensalidades = sistemaMensalidades;

    public IReadOnlyList<MensalidadeProcessada> ProcessaCalculoMensalidade(string[] relacaoAlunos)
    {
        // Responsabilidade do Adapter:
        // 1) Converter `string[]` (formato do Cliente) em `List<Aluno>` (formato do Adaptee)
        // 2) Delegar a execução para o Adaptee
        var alunos = Converter(relacaoAlunos);
        return _sistemaMensalidades.CalculaMensalidade(alunos);
    }

    private static List<Aluno> Converter(string[] relacaoAlunos)
    {
        // Para simplificar o estudo, consideramos um formato fixo: "Nome;Curso;Mensalidade".
        // Em produção, aqui normalmente entram validações mais robustas e tratamento de erros.
        var alunos = new List<Aluno>(relacaoAlunos.Length);

        foreach (var linha in relacaoAlunos)
        {
            var partes = linha.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length != 3)
                throw new FormatException($"Linha inválida: '{linha}'. Esperado: Nome;Curso;Mensalidade.");

            var nome = partes[0];
            var curso = partes[1];

            // Usamos cultura invariável para o exemplo ser previsível em qualquer máquina.
            if (!decimal.TryParse(partes[2], NumberStyles.Number, CultureInfo.InvariantCulture, out var mensalidade))
                throw new FormatException($"Mensalidade inválida na linha: '{linha}'.");

            alunos.Add(new Aluno(nome, curso, mensalidade));
        }

        return alunos;
    }
}
