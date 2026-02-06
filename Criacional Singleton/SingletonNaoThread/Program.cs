namespace SingletonNaoThread;

internal static class Program
{
	private static void Main()
	{
		// Acessa a instância do Singleton pela primeira vez.
		// Como ainda não existe, o Singleton irá criá-la.
		Console.WriteLine("Tentando criar a instância S1...");
		var s1 = Singleton.Instance;

		// Acessa a instância do Singleton novamente.
		// Como já foi criada, o Singleton deve retornar a MESMA referência.
		Console.WriteLine("Tentando criar a instância S2...");
		var s2 = Singleton.Instance;

		// Compara as duas referências. Se forem iguais, aponta para a mesma instância.
		Console.WriteLine(s1 == s2
			? "Existe somente uma instância: S1 == S2"
			: "Instâncias distintas: S1 != S2");
	}
}
