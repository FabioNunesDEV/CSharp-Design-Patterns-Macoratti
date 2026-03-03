namespace CoR;

// Handler concreto: Gerente de Projeto.
// Na aula, o gerente tem alçada para aprovar até 5 dias.
// Se o pedido exceder a alçada, ele encaminha para o próximo autorizador.
public class GerenteProjeto : Autorizador
{
    private int ALCADA_DIAS = 5;
    public override void AutorizarLicenca(string nome, int dias)
    {
        // Regra de decisão do handler:
        // - se estiver na alçada: trata (aprova) e encerra.
        // - caso contrário: repassa ao próximo handler da cadeia.
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
            // Situação de final de cadeia: não há sucessor para tratar.
            Console.WriteLine($"Gerente de Projeto não pode autorizar a licença de {nome} por {dias} dias e não há próximo autorizador.");
        }
    }

    private void AprovarLicenca(string nome, int dias)
    {
        // “Tratamento” da solicitação (exemplo didático: apenas exibir mensagem).
        Console.WriteLine($"Gerente de Projeto aprovou a licença de {nome} por {dias} dias.\n");
    }
}
