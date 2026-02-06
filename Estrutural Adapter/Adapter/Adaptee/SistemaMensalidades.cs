using Adapter.Domain;

namespace Adapter.Adaptee;

// Adaptee (Componente legado/reutilizado)
// --------------------------------------
// Esta classe representa um componente existente.
// Importante: a interface dele é incompatível com o que o Cliente possui.
public sealed class SistemaMensalidades
{
    // O legado espera receber a lista de alunos como objetos do domínio.
    // Não alteramos aqui para respeitar compatibilidade e reutilização.
    public IReadOnlyList<MensalidadeProcessada> CalculaMensalidade(IReadOnlyList<Aluno> alunos)
    {
        // Exemplo simplificado: aplica desconto para o curso "Cloud".
        // A lógica de negócio fica encapsulada no Adaptee.
        return alunos
            .Select(a =>
            {
                var fator = a.Curso.Equals("Cloud", StringComparison.OrdinalIgnoreCase) ? 0.90m : 1.00m;
                var valor = decimal.Round(a.Mensalidade * fator, 2, MidpointRounding.AwayFromZero);
                return new MensalidadeProcessada(a.Nome, a.Curso, valor);
            })
            .ToList();
    }
}
