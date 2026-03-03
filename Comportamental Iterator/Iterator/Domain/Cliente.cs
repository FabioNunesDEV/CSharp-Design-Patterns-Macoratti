namespace Iterator.Domain;

/// <summary>
/// Entidade de domínio usada na coleção. Mantém dados mínimos para demonstrar o padrão Iterator.
/// </summary>
public class Cliente
{
    /// <summary>
    /// Identificador único do cliente.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Nome do cliente.
    /// </summary>
    public string Nome { get; }

    public Cliente(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
