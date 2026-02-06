using Adapter.Domain;

namespace Adapter.Target;

// Target (Contrato esperado pelo Cliente)
// --------------------------------------
// Define o formato de comunicação que o cliente entende.
// Neste exemplo, o cliente só consegue fornecer a relação de alunos como `string[]`.
public interface IProcessaMensalidades
{
    IReadOnlyList<MensalidadeProcessada> ProcessaCalculoMensalidade(string[] relacaoAlunos);
}
