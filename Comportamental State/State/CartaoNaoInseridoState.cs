namespace State;

public class CartaoNaoInseridoState : ICaixaEletronicoState
{
    private readonly CaixaEletronico _caixaEletronico;

    public CartaoNaoInseridoState(CaixaEletronico caixaEletronico)
    {
        _caixaEletronico = caixaEletronico;
    }

    public void InserirCartao()
    {
        Console.WriteLine("Cartão inserido com sucesso.");
        _caixaEletronico.SetState(_caixaEletronico.CartaoInserido);
    }

    public void EjetarCartao()
    {
        Console.WriteLine("Não é possível ejetar o cartão. O cartão não foi inserido.");
    }

    public void InformarSenha()
    {
        Console.WriteLine("Não é possível informar a senha. O cartão não foi inserido.");
    }

    public void SacarDinheiro()
    {
        Console.WriteLine("Não é possível sacar dinheiro. O cartão não foi inserido.");
    }
}
