using Composite.Component;

namespace Composite.Composite;

/// <summary>
/// Composite (objeto composto) no padrão Composite.
/// 
/// Nesta implementação, a mesma classe é usada para representar:
/// - a organização raiz
/// - departamentos
/// 
/// Ambos podem conter outros composites (subdepartamentos) e/ou folhas (funcionários).
/// </summary>
public class Organizacao : HoraTrabalhada
{
    /// <summary>
    /// Lista de filhos (componentes) desta organização/departamento.
    /// 
    /// Pode conter tanto folhas (<c>Funcionario</c>) quanto outros composites (<c>Organizacao</c>).
    /// </summary>
    protected List<HoraTrabalhada> organizacoes = new List<HoraTrabalhada>();

    /// <summary>
    /// Adiciona um componente (filho) à lista.
    /// </summary>
    public override void Add(HoraTrabalhada component)
    {
        organizacoes.Add(component);
    }

    /// <summary>
    /// Remove um componente (filho) da lista.
    /// </summary>
    public override void Remove(HoraTrabalhada component)
    {
        organizacoes.Remove(component);
    }

    /// <summary>
    /// Calcula o total de horas trabalhadas deste composite.
    /// 
    /// O método percorre todos os filhos e soma o resultado.
    /// Se o filho também for um composite, a chamada é recursiva, percorrendo toda a subárvore.
    /// </summary>
    public override int GetHoraTrabalhada()
    {
        var horasTrabalhadasOrganizacao = 0;

        foreach (var organizacao in organizacoes)
        {
            // Polimorfismo: o código não precisa saber se o filho é folha ou composite.
            horasTrabalhadasOrganizacao += organizacao.GetHoraTrabalhada();
        }

        // Ao final da iteração, o total representa o somatório de toda a subárvore.
        Console.WriteLine($"Organização {Nome} tem {horasTrabalhadasOrganizacao} horas trabalhadas.");

        return horasTrabalhadasOrganizacao;
    }
}
