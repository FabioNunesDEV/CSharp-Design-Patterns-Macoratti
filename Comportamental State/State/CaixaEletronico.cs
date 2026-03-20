namespace State;

public class CaixaEletronico
{
    public ICaixaEletronicoState CartaoNaoInserido { get; }
    public ICaixaEletronicoState CartaoInserido { get; }

    private ICaixaEletronicoState _estadoAtual;

    public CaixaEletronico()
    {
        CartaoNaoInserido = new CartaoNaoInseridoState(this);
        CartaoInserido = new CartaoInseridoState(this);
        _estadoAtual = CartaoNaoInserido;
    }

    public void SetState(ICaixaEletronicoState novoEstado)
    {
        _estadoAtual = novoEstado;
        Console.WriteLine($"  >> Estado mudou para: {_estadoAtual.GetType().Name}");
    }

    public void InserirCartao()
    {
        _estadoAtual.InserirCartao();
    }

    public void EjetarCartao()
    {
        _estadoAtual.EjetarCartao();
    }

    public void InformarSenha()
    {
        _estadoAtual.InformarSenha();
    }

    public void SacarDinheiro()
    {
        _estadoAtual.SacarDinheiro();
    }

    public string GetEstadoAtual() => _estadoAtual.GetType().Name;
}
