using Iterator.Aggregates;
using Iterator.Domain;
using Iterator.Interfaces;

/// <summary>
/// Client (GoF): ponto de entrada que orquestra o uso do padrão Iterator sem conhecer a estrutura interna da coleção.
/// Demonstra que o cliente trabalha apenas com as interfaces (Aggregate/Iterator) e não com a coleção concreta.
/// </summary>
internal class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Demonstração do Padrão Iterator (GoF) ===\n");

        // 1) Criação do ConcreteAggregate e inclusão de elementos de domínio.
        ClienteAggregate aggregate = new();
        aggregate.Add(new Cliente(1, "Maria Silva"));
        aggregate.Add(new Cliente(2, "João Souza"));
        aggregate.Add(new Cliente(3, "Carla Pereira"));
        aggregate.Add(new Cliente(4, "Renato Lima"));

        Console.WriteLine("Aggregate criado e preenchido sem expor a lista interna ao cliente.");

        // 2) Cliente solicita um Iterator sem saber como a coleção armazena seus dados.
        IIterator<Cliente> iterator = aggregate.CreateIterator();
        Console.WriteLine("Iterator criado pelo Aggregate (fábrica dedicada).\n");

        // 3) Travessia manual, controlando o fluxo explicitamente com o Iterator.
        Console.WriteLine("Percorrendo usando apenas a interface do Iterator:\n");

        // Posiciona no primeiro elemento.
        Cliente? atual = iterator.First();
        Exibir(atual, "Primeiro elemento obtido com First():");

        // Laço controlado sem usar 'foreach' nem 'yield', mostrando o estado do Iterator.
        while (!iterator.IsDone)
        {
            Exibir(iterator.CurrentItem, "Elemento atual via CurrentItem:");
            atual = iterator.Next();
            if (atual is not null)
            {
                Exibir(atual, "Próximo elemento obtido com Next():");
            }
        }

        Console.WriteLine("\nInteração concluída. O cliente nunca acessou a estrutura interna da coleção.");
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    /// <summary>
    /// Apenas exibe o conteúdo de um cliente com um texto explicativo.
    /// Mantém a responsabilidade de apresentação separada da lógica do iterador.
    /// </summary>
    private static void Exibir(Cliente? cliente, string titulo)
    {
        Console.WriteLine(titulo);
        if (cliente is null)
        {
            Console.WriteLine("  - Nenhum elemento (fim da coleção).\n");
            return;
        }

        Console.WriteLine($"  - Id: {cliente.Id}, Nome: {cliente.Nome}\n");
    }
}
