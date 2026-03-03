using Command;

Console.WriteLine("## Padrão Command ##\n");

// Client (GoF): configura as relações entre os objetos do padrão.
// 1) Cria o Receiver (Chef)
// 2) Cria o ConcreteCommand (Pedido), associando Receiver + dados do pedido
// 3) Entrega o comando ao Invoker (Garcom), que dispara a execução via Execute()

// Receiver: contém a lógica real (preparar prato/sobremesa)
Chef chef = new Chef ();

// Prato
Pedido pedido = new Pedido(chef, "Prato");
Garcom garcom = new Garcom(pedido);
garcom.Executar();

// Sobremesa
pedido = new Pedido(chef, "Sobremesa"); 
garcom = new Garcom(pedido);    
garcom.Executar();

Console.ReadKey();

