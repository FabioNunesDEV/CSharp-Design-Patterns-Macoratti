namespace Facade.Subsistemas;

/// <summary>
/// Subsistema: responsável pelo cadastro do cliente.
/// 
/// No padrão Facade, esta classe representa uma parte do subsistema complexo.
/// O cliente (código consumidor) não precisa acessá-la diretamente quando utiliza a <see cref="Facade.MeuFacade"/>.
/// </summary>
public class Cadastro
{
    /// <summary>
    /// Realiza o cadastro do cliente.
    /// Aqui é apenas uma simulação (Console), pois o objetivo do projeto é demonstrar o padrão.
    /// </summary>
    public void CadastrarCliente(Cliente cliente)
    {
        Console.WriteLine($"Cliente '{cliente.Nome}' cadastrado com sucesso.");
    }
}
