namespace State;

public class CartaoInseridoState : ICaixaEletronicoState
{
    private readonly CaixaEletronico _caixaEletronico;

    public CartaoInseridoState(CaixaEletronico caixaEletronico)
    {
        _caixaEletronico = caixaEletronico;
    }

    public void InserirCartao()
    {
        Console.WriteLine("Não é possível inserir o cartão. O cartão já foi inserido.");
    }

    public void EjetarCartao()
    {
        Console.WriteLine("Cartão ejetado com sucesso.");
        _caixaEletronico.SetState(_caixaEletronico.CartaoNaoInserido);
    }

    public void InformarSenha()
    {
        Console.WriteLine("Senha informada com sucesso.");
    }

    public void SacarDinheiro()
    {
        Console.WriteLine("Dinheiro sacado com sucesso.");
    }
}
