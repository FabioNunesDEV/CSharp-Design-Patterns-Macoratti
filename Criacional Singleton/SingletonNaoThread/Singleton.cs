namespace SingletonNaoThread;

// Implementação mais simples do padrão Singleton.
// Observação: esta versão NÃO é thread-safe (não protege contra acesso concorrente).
public sealed class Singleton
{
	// Campo estático que mantém a referência para a única instância da classe.
	// Começa nulo e será inicializado sob demanda (lazy initialization).
	private static Singleton? _instance;

	// Contador apenas para demonstração: permite visualizar quantas vezes o construtor foi executado.
	private static int _instancesCount;

	// Construtor privado: impede que clientes criem instâncias via "new Singleton()".
	// Assim, a criação fica centralizada e controlada pela própria classe.
	private Singleton()
	{
		_instancesCount++;
		Console.WriteLine($"Instanciando no construtor privado. Número de instâncias: {_instancesCount}");
	}

	// Ponto de acesso global para obter a instância.
	// Na primeira chamada, cria a instância; nas chamadas seguintes, retorna a mesma referência.
	public static Singleton Instance
	{
		get
		{
			// Verifica se a instância já foi criada.
			// Se ainda não existe, cria a primeira e única instância (em cenários single-thread).
			if (_instance is null)
			{
				Console.WriteLine("Criando a primeira instância");
				_instance = new Singleton();
			}

			// Retorna sempre a mesma instância armazenada no campo estático.
			return _instance;
		}
	}
}
