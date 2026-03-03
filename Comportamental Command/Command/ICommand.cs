namespace Command;

/// <summary>
/// Command (GoF): declara o contrato comum para execução de comandos.
/// 
/// Intenção do padrão: encapsular uma solicitação como um objeto, permitindo
/// parametrizar o <c>Invoker</c> (ex.: <c>Garcom</c>) sem que ele conheça o
/// <c>Receiver</c> (ex.: <c>Chef</c>) nem os detalhes da operação.
/// </summary>
public interface ICommand
{
    public abstract void Execute();
}
