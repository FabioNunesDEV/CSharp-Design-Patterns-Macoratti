namespace Command;

/// <summary>
/// ConcreteCommand (GoF): encapsula uma solicitação como objeto.
/// 
/// Responsabilidades:
/// - Manter a referência ao <c>Receiver</c> (<c>Chef</c>), que executa o trabalho real.
/// - Guardar os dados necessários para decidir qual ação disparar (neste exemplo, <c>Acao</c>).
/// - Implementar <see cref="ICommand.Execute"/> delegando para o receiver.
/// </summary>
public class Pedido : ICommand
{
    // Receiver: quem sabe executar as operações associadas ao comando.
    private Chef Receiver { get; set; }    

    // Dados/parâmetros do pedido (o que será preparado). Em um cenário real, isso poderia ser
    // um enum, um objeto de pedido completo, etc.
    private string Acao { get; set; }   

    public Pedido(Chef chef, string acao)
    {
        Receiver = chef;
        Acao = acao;
    }

    public void Execute()
    {
        // O Invoker chama apenas Execute(). A decisão do que fazer está encapsulada no comando.
        if (Acao.Equals("Prato"))
        {
            Receiver.PreparandoPrato();
        }
        else if (Acao.Equals("Sobremesa"))
        {
            Receiver.PreparandoSobremessa();
        }
    }
}
