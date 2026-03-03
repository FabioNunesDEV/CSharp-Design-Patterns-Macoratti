namespace CoR;

// Handler concreto: Setor de RH.
// Na aula, o RH é o último manipulador da cadeia e tem alçada para aprovar até 30 dias.
// Ao ser o final da cadeia, se o pedido extrapolar a alçada ele precisa tratar “o erro”.
public class SetorRH : Autorizador
{
    private int ALCADA_DIAS = 30;
    public override void AutorizarLicenca(string nome, int dias)
    {
        // Último handler do cenário apresentado: tenta tratar e, se não for possível,
        // encerra com uma mensagem (na aula foi citado que aqui poderia lançar exceção
        // ou executar outro tratamento definido pelo desenvolvedor).
        if (dias <= ALCADA_DIAS)
        {
            AprovarLicenca(nome, dias);
        }
        else if (_autorizador != null)
        {
            _autorizador.AutorizarLicenca(nome, dias);
        }
        else
        {
            // Final da cadeia sem aprovador para a solicitação.
            Console.WriteLine($"Setor RH não pode autorizar a licença de {nome} por {dias} dias e não há próximo autorizador.");
        }
    }

    private void AprovarLicenca(string nome, int dias)
    {
        // Tratamento do pedido dentro da alçada do RH.
        Console.WriteLine($"Setor RH aprovou a licença de {nome} por {dias} dias.\n");
    }
}
