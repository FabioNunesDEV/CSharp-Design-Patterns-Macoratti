namespace Composite.Component;

/// <summary>
/// Classe base (Component) do padrão Composite.
/// 
/// Define a operação comum (<see cref="GetHoraTrabalhada"/>) que será executada
/// tanto por objetos folha (ex.: <c>Funcionario</c>) quanto por objetos compostos
/// (ex.: <c>Organizacao</c> / departamentos).
/// </summary>
public abstract class HoraTrabalhada
{
    /// <summary>
    /// Construtor padrão.
    /// Mantido simples para o exemplo didático.
    /// </summary>
    public HoraTrabalhada() { }

    /// <summary>
    /// Nome do elemento na árvore.
    /// 
    /// Para folhas pode representar o nome do funcionário.
    /// Para composites pode representar o nome do departamento/organização.
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Operação principal do exemplo: obtém (ou calcula) as horas trabalhadas.
    /// 
    /// - Nas folhas: retorna o valor armazenado.
    /// - Nos composites: percorre os filhos somando recursivamente.
    /// </summary>
    public abstract int GetHoraTrabalhada();

    /// <summary>
    /// Adiciona um filho ao composite.
    /// 
    /// Por padrão, componentes folha não suportam essa operação.
    /// Classes compostas devem sobrescrever.
    /// </summary>
    public virtual void Add(HoraTrabalhada component)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Remove um filho do composite.
    /// 
    /// Por padrão, componentes folha não suportam essa operação.
    /// Classes compostas devem sobrescrever.
    /// </summary>
    public virtual void Remove(HoraTrabalhada component)
    {
        throw new NotImplementedException();
    }
}
