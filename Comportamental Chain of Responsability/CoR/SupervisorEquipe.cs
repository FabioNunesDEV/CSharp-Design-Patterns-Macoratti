namespace CoR;

// Handler concreto: Supervisor de Equipe.
// Na hierarquia do exemplo (aula): Desenvolvedor -> Gerente de Projeto -> Supervisor -> RH.
// O supervisor tem alçada para aprovar até 15 dias; do contrário, encaminha para o RH.
public  class SupervisorEquipe:Autorizador
{
    private int ALCADA_DIAS = 15;
    public override void AutorizarLicenca(string nome, int dias)
    {
        // Mantém a mesma lógica de decisão descrita na aula:
        // tratar quando possível ou repassar ao próximo manipulador.
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
            // Se a cadeia não foi montada corretamente ou não há sucessor.
            Console.WriteLine($"Supervisor da Equipe não pode autorizar a licença de {nome} por {dias} dias e não há próximo autorizador.");
        }
    }

    private void AprovarLicenca(string nome, int dias)
    {
        // “Tratamento” do pedido dentro da alçada do supervisor (mensagem no console).
        Console.WriteLine($"Supervisor da Equipe aprovou a licença de {nome} por {dias} dias.\n");
    }
}
