namespace SingletonMultiThread;

internal static class Program
{
	private static void Main()
	{
		// O log será criado na pasta de saída do build (bin/Debug/net8.0).
		// AppContext.BaseDirectory é uma forma simples de resolver esse caminho em apps console.
		var logFilePath = Path.Combine(AppContext.BaseDirectory, "log.txt");

		// Para facilitar a demonstração, removemos o arquivo anterior.
		if (File.Exists(logFilePath))
		{
			File.Delete(logFilePath);
		}

		Console.WriteLine($"Arquivo de log: {logFilePath}");
		Console.WriteLine("Iniciando 4 threads para escrever no log...\n");

		// Cria 4 threads "reais" do SO para simular concorrência.
		// Cada uma vai tentar escrever no MESMO arquivo.
		var threads = new List<Thread>();
		for (var i = 1; i <= 4; i++)
		{
			var threadIndex = i;
			threads.Add(new Thread(() => WriteLogFromThread(threadIndex, logFilePath))
			{
				IsBackground = false,
				Name = $"Thread-{threadIndex}"
			});
		}

		// Inicia todas as threads.
		foreach (var thread in threads)
		{
			thread.Start();
		}

		// Aguarda todas finalizarem para então encerrar o programa.
		foreach (var thread in threads)
		{
			thread.Join();
		}

		Console.WriteLine("\nFinalizado. Verifique o arquivo log.txt.");
	}

	private static void WriteLogFromThread(int threadIndex, string logFilePath)
	{
		// Monta um texto "grande" (3 parágrafos) para demonstrar que o tamanho não importa:
		// a sincronização garante que a escrita seja feita de forma atômica por thread.
		var content = BuildThreadMessage(threadIndex);

		// Mensagens no console ajudam a ver quem está aguardando e quem conseguiu escrever.
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {Thread.CurrentThread.Name} solicitou escrita no log.");

		// A classe `Singleton` centraliza o acesso ao recurso compartilhado e aplica `lock`.
		Singleton.Instance.WriteToLog(logFilePath, content);
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {Thread.CurrentThread.Name} concluiu escrita no log.");
	}

	private static string BuildThreadMessage(int threadIndex)
	{
		var header = $"===== INÍCIO - {Thread.CurrentThread.Name} - {DateTime.Now:O} =====";
		var p1 = $"Parágrafo 1 (Thread {threadIndex}): Esta mensagem foi gerada para demonstrar o uso do Singleton thread-safe escrevendo em um recurso compartilhado (arquivo de log).";
		var p2 = $"Parágrafo 2 (Thread {threadIndex}): O acesso concorrente é sincronizado com lock, garantindo que apenas uma thread escreva no arquivo por vez e mantendo integridade do log.";
		var p3 = $"Parágrafo 3 (Thread {threadIndex}): Após escrever, a thread mantém o bloqueio por 1 segundo para simular uma operação demorada e evidenciar a serialização das escritas.";
		var footer = $"===== FIM - {Thread.CurrentThread.Name} =====";

		return string.Join(Environment.NewLine, header, p1, string.Empty, p2, string.Empty, p3, footer);
	}
}
