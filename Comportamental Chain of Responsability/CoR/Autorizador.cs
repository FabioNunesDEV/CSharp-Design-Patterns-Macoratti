namespace CoR;

// Padrão comportamental: Chain of Responsibility (Cadeia de Responsabilidade)
// Conforme a aula, este padrão evita acoplar o remetente da solicitação ao seu receptor,
// dando a mais de um objeto a chance de lidar com a solicitação.
//
// Neste projeto a “solicitação” é o pedido de licença remunerada (funcionário + dias).
// Cada autorizador (handler) tem uma alçada; se não puder tratar, repassa ao próximo.
public abstract class Autorizador
{
    // Referência para o próximo manipulador (sucessor) na cadeia.
    protected Autorizador _autorizador;

    // O cliente monta a cadeia chamando este método para definir o sucessor.
    // Exemplo usado na aula: Gerente de Projeto -> Supervisor de Equipe -> Setor de RH.
    public void ProximoAutorizador(Autorizador autorizador)
    {
        _autorizador = autorizador;
    }

    // Método que será sobrescrito pelos handlers concretos.
    // Cada handler aprova dentro da sua alçada ou encaminha ao sucessor.
    public abstract void AutorizarLicenca(string nome, int dias);
}
