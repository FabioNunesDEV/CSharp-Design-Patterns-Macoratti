namespace Proxy;

/// <summary>
/// Proxy de proteção para a pasta compartilhada.
/// 
/// Papel no padrão Proxy:
/// - <b>Proxy</b>: mantém uma referência para o <b>RealSubject</b> (via <see cref="IPastaCompartilhada"/>)
///   e controla o acesso ao recurso.
/// - Implementa a mesma interface do RealSubject para ser usado de forma intercambiável.
/// 
/// Responsabilidade principal neste exemplo:
/// - Verificar o perfil do <see cref="Funcionario"/>.
/// - Se autorizado, criar o RealSubject e delegar a operação.
/// - Caso contrário, negar acesso.
/// 
/// Referências:
/// - Aula: proxy de proteção valida permissões antes de encaminhar a chamada.
/// - Material complementar: proxy pode executar lógica antes/depois de delegar ao serviço.
/// </summary>
public class PastaCompartilhadaProxy : IPastaCompartilhada
{
    private IPastaCompartilhada pasta;
    private Funcionario funcionario;

    public PastaCompartilhadaProxy(Funcionario funcionario)
    {
        this.funcionario = funcionario;
    }

    public void OperacaoDeLeituraGravacao()
    {
        // Proxy de Proteção: checa permissão (perfil) antes de delegar ao objeto real.
        if (funcionario.Perfil.ToUpper() == "CEO")
        {
            // Inicialização sob demanda (criação apenas quando necessário):
            // neste exemplo, o proxy instancia o RealSubject apenas quando o perfil é permitido.
            pasta = new PastaCompartiolhada();
            Console.WriteLine("O proxy 'Pasta Compartilhada' invoca a pasta Real: 'método usado: OperacaoDeLeituraGravacao()'\n");

            // Delegação ao RealSubject (mesma interface).
            pasta.OperacaoDeLeituraGravacao();
        }
        else
        {
            // Acesso negado: cliente não interage diretamente com o RealSubject.
            Console.WriteLine("O proxy 'Pasta Compartilhada' avisa: 'Você não tem permissão para acessar esta pasta'\n");
        }
    }
}
