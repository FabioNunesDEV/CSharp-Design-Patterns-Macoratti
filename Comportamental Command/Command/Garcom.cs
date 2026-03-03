namespace Command;

/// <summary>
/// Invoker (GoF): solicita a execução de um comando.
/// 
/// Na analogia do restaurante: o <c>Garcom</c> recebe o pedido e apenas o executa.
/// Ele não conhece detalhes de preparo (não chama <c>Chef</c> diretamente); trabalha
/// via abstração do comando.
/// </summary>
public class Garcom
{
    private Pedido _pedido;

    public Garcom(Pedido pedido)
    {
        _pedido = pedido;
    }

    public void Executar()
    {
        // Invoker dispara a execução sem saber "como" o receiver realizará o trabalho.
        _pedido.Execute();
    }
}
