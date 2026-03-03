using Proxy;

// Client (cliente do padrão Proxy):
// - Trabalha contra a abstração (IPastaCompartilhada), mas aqui instancia diretamente o Proxy
//   para demonstrar o comportamento.
// - Testa múltiplos perfis para evidenciar que apenas usuários autorizados acessam o RealSubject.
Console.WriteLine("### Exemplo de implementação do padrão Proxy ###");

// acesso Programador
Console.WriteLine("\nFuncionário com perfil 'Programador' acessando a Pasta Compartilhada Proxy");

Funcionario funcionario = new Funcionario("MAcoratti","123456","Programador");
PastaCompartilhadaProxy pastaCompartilhadaProxy = new PastaCompartilhadaProxy(funcionario);
pastaCompartilhadaProxy.OperacaoDeLeituraGravacao();

// Acesso Usuario
Console.WriteLine("\nFuncionário com perfil 'Usuário' acessando a Pasta Compartilhada Proxy");
pastaCompartilhadaProxy = new PastaCompartilhadaProxy(new Funcionario("Fábio","654321","Usuário"));
pastaCompartilhadaProxy.OperacaoDeLeituraGravacao();

// Acesso CEO
Console.WriteLine("\nFuncionário com perfil 'CEO' acessando a Pasta Compartilhada Proxy");
pastaCompartilhadaProxy = new PastaCompartilhadaProxy(new Funcionario("Maria","123654","CEO"));
pastaCompartilhadaProxy.OperacaoDeLeituraGravacao();

Console.Read();