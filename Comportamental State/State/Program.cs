using State;

var caixa = new CaixaEletronico();

// Estado inicial: Cartão NÃO inserido
Console.WriteLine("===========================================");
Console.WriteLine($"Estado atual: {caixa.GetEstadoAtual()}");
Console.WriteLine("===========================================");
caixa.InformarSenha();
caixa.SacarDinheiro();
caixa.EjetarCartao();

// Inserir o cartão -> muda o estado para Cartão Inserido
Console.WriteLine();
Console.WriteLine("--- Inserindo o cartão ---");
caixa.InserirCartao();

Console.WriteLine();
Console.WriteLine("===========================================");
Console.WriteLine($"Estado atual: {caixa.GetEstadoAtual()}");
Console.WriteLine("===========================================");
caixa.InformarSenha();
caixa.SacarDinheiro();
caixa.InserirCartao();

// Ejetar o cartão -> muda o estado para Cartão Não Inserido
Console.WriteLine();
Console.WriteLine("--- Ejetando o cartão ---");
caixa.EjetarCartao();

Console.WriteLine();
Console.WriteLine("===========================================");
Console.WriteLine($"Estado atual: {caixa.GetEstadoAtual()}");
Console.WriteLine("===========================================");
