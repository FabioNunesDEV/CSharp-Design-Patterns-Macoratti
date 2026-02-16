
using Facade.Facade;
using Facade.Subsistemas;

// Cliente do padrão (código consumidor).
// Ao invés de instanciar e chamar diretamente as classes do subsistema (Cadastro, Serasa, Cadin, LimiteCredito),
// o cliente interage apenas com o ponto de entrada de alto nível: a Facade.
MeuFacade concederCreditoFacade = new MeuFacade();

// Cenário 1: valor dentro do limite (deve conceder no exemplo, pois Serasa/Cadin retornam false).
Cliente cliente1 = new Cliente ("João");
bool resultado1 = concederCreditoFacade.ConcederEmprestimo(cliente1, 5000);
Console.WriteLine($"O emprestimo pleiteado pelo cliente {cliente1.Nome} foi {(resultado1 ? "concedido" : "negado")}\n\r");

// Cenário 2: valor acima do limite (deve negar pela regra simplificada do subsistema de limite).
Cliente cliente2 = new Cliente ("Maria");
bool resultado2 = concederCreditoFacade.ConcederEmprestimo(cliente2, 300000);
Console.WriteLine($"O emprestimo pleiteado pelo cliente {cliente2.Nome} foi {(resultado2 ? "concedido" : "negado")}\n\r");

Console.ReadLine();

