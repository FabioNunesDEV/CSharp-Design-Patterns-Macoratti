namespace Facade.Subsistemas;

/// <summary>
/// Entidade simples usada pelo exemplo.
/// 
/// Representa o cliente que solicita o empréstimo e transita entre a Facade e o subsistema.
/// </summary>
public class Cliente
{
    /// <summary>
    /// Nome do cliente.
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Cria um novo cliente.
    /// </summary>
    public Cliente(string nome)
    {
        Nome = nome;
    }
}
