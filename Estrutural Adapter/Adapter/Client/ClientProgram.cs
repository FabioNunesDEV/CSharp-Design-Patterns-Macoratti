using Adapter.Adapter;
using Adapter.Adaptee;
using Adapter.Target;

namespace Adapter.Client;

public static class ClientProgram
{
    public static void Run()
    {
        // O Cliente trabalha com dados no formato que ele possui.
        // Neste exemplo, o "sistema escolar" expõe a relação de alunos como `string[]`.
        var relacaoAlunos = new[]
        {
            // Formato: "Nome;Curso;Mensalidade"
            "Ana;Arquitetura de Software;350.00",
            "Bruno;C# e .NET;420.50",
            "Carla;Cloud;499.99",
        };

        // O Cliente depende apenas do Target (abstração).
        // Isso segue o DIP (Dependency Inversion Principle): dependemos de interface.
        IProcessaMensalidades processador = new AlunoAdapter(new SistemaMensalidades());

        var resultado = processador.ProcessaCalculoMensalidade(relacaoAlunos);

        Console.WriteLine("Mensalidades processadas (via Adapter):");
        foreach (var item in resultado)
        {
            Console.WriteLine($"- {item.Nome} ({item.Curso}) => {item.ValorMensalidade:C}");
        }
    }
}
