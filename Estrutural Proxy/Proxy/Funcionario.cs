namespace Proxy;

/// <summary>
/// Representa o <b>Client Context</b> do exemplo.
/// 
/// No cenário apresentado (pasta compartilhada com informações confidenciais),
/// o acesso ao recurso é liberado ou negado de acordo com o <see cref="Perfil"/>.
/// 
/// Papel no padrão Proxy:
/// - É o dado de entrada usado pelo <b>Proxy de Proteção</b> para decidir se irá
///   delegar a chamada ao objeto real.
/// 
/// Referências:
/// - Material da aula (proxy de proteção: valida permissões antes de encaminhar ao RealSubject).
/// </summary>
public class Funcionario
{
    public string Nome { get; set; }
    public string Senha { get; set; }
    public string Perfil { get; set; }

    public Funcionario(string nome, string senha, string perfil)
    {
        Nome = nome;
        Senha = senha;
        Perfil = perfil;
    }
}
