using Memento;

Console.WriteLine("=====================================================");
Console.WriteLine("   Padrão de Projeto: Memento (Comportamental)");
Console.WriteLine("   Exemplo: Calculadora com Soma de Dois Números");
Console.WriteLine("=====================================================");
Console.WriteLine();

// 1. Criar a instância da Calculadora (Originator)
ICalculadora calculadora = new Calculadora();

// 2. Atribuir os dois números e obter o resultado (Estado 1)
Console.WriteLine("--- Estado 1: Primeira operação ---");
calculadora.SetPrimeiroNumero(60);
calculadora.SetSegundoNumero(50);
int resultado1 = calculadora.ObterResultado();
Console.WriteLine($"Primeiro número: 60");
Console.WriteLine($"Segundo número:  50");
Console.WriteLine($"Resultado da soma: {resultado1}");
Console.WriteLine();

// 3. Fazer o backup do estado atual (createMemento)
//    O método retorna ICaretaker, que não expõe o estado interno.
Console.WriteLine(">> Realizando backup do estado atual (Memento salvo)...");
ICaretaker memento = calculadora.BackupUltimoCalculo();
Console.WriteLine();

// 4. Atribuir novos valores e obter um novo resultado (Estado 2)
Console.WriteLine("--- Estado 2: Segunda operação ---");
calculadora.SetPrimeiroNumero(200);
calculadora.SetSegundoNumero(300);
int resultado2 = calculadora.ObterResultado();
Console.WriteLine($"Primeiro número: 200");
Console.WriteLine($"Segundo número:  300");
Console.WriteLine($"Resultado da soma: {resultado2}");
Console.WriteLine();

// 5. Restaurar o estado anterior usando o Memento (setMemento)
//    Simulando uma operação de Undo / Ctrl+Z / Rollback
Console.WriteLine(">> Restaurando o estado anterior (Undo / Rollback)...");
calculadora.RestauraUltimoCalculo(memento);
Console.WriteLine();

// 6. Obter o resultado após a restauração (deve ser o Estado 1)
Console.WriteLine("--- Estado Restaurado ---");
int resultadoRestaurado = calculadora.ObterResultado();
Console.WriteLine($"Resultado da soma após restauração: {resultadoRestaurado}");
Console.WriteLine();

Console.WriteLine("=====================================================");
Console.WriteLine($"  Estado 1 (original):    60 + 50  = {resultado1}");
Console.WriteLine($"  Estado 2 (novo):        200 + 300 = {resultado2}");
Console.WriteLine($"  Estado restaurado:      60 + 50  = {resultadoRestaurado}");
Console.WriteLine("=====================================================");
Console.WriteLine();
Console.WriteLine("O padrão Memento permitiu salvar o estado do objeto");
Console.WriteLine("(primeiro e segundo número) e restaurá-lo posteriormente,");
Console.WriteLine("sem violar o encapsulamento da classe Calculadora.");
