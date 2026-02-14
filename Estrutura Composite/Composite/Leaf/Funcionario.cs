using Composite.Component;

namespace Composite.Leaf;

/// <summary>
/// Leaf (folha) no padrão Composite.
/// 
/// Representa um elemento terminal da árvore: não possui filhos.
/// Sua responsabilidade é retornar suas próprias horas trabalhadas.
/// </summary>
public class Funcionario : HoraTrabalhada
{
    /// <summary>
    /// Identificador do funcionário (apenas para exibição no console).
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Total de horas registradas pelo funcionário.
    /// </summary>
    public int Horas { get; set; }

    /// <summary>
    /// Retorna as horas trabalhadas do funcionário.
    /// 
    /// Como é um Leaf, não há recursão: o valor é retornado diretamente.
    /// </summary>
    public override int GetHoraTrabalhada()
    {
        // Exibe as horas individuais antes de o composite fazer a soma.
        Console.WriteLine($"Fucionário {Id}-{Nome} registrou {Horas} horas trabalhadas.");

        return Horas;
    }
}
