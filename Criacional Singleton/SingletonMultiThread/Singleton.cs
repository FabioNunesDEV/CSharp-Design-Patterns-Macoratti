namespace SingletonMultiThread;

// Singleton thread-safe para demonstrar sincronização em acesso concorrente.
// Aqui usamos `lock` como mecanismo de exclusão mútua, conforme descrito na transcrição.
public sealed class Singleton
{
	// Referência estática para a instância única.
	private static Singleton? _instance;

	// Objeto usado como "cadeado" (mutex) para sincronizar acesso.
	// Todas as threads que tentarem entrar no `lock` ao mesmo tempo serão serializadas.
	private static readonly object _lockObject = new();

	private Singleton()
	{
		// Construtor privado: impede `new Singleton()` fora da classe.
		// Garante que o único caminho para obter a instância seja a propriedade `Instance`.
	}

	// Propriedade estática que expõe a instância única.
	// Implementação com "verificação dupla" (double-check locking):
	// 1) verifica fora do lock para evitar custo de sincronização após inicializar
	// 2) verifica novamente dentro do lock para garantir segurança em concorrência
	public static Singleton Instance
	{
		get
		{
			// Se já existe, retorna imediatamente (caminho rápido).
			if (_instance is not null)
			{
				return _instance;
			}

			// Se ainda não existe, sincroniza para que apenas uma thread crie a instância.
			lock (_lockObject)
			{
				// Segunda checagem: outra thread pode ter criado a instância enquanto
				// a thread atual aguardava o lock.
				if (_instance is null)
				{
					_instance = new Singleton();
				}
			}

			return _instance;
		}
	}

	public void WriteToLog(string logFilePath, string message)
	{
		// Sincroniza a escrita no arquivo de log.
		// Como o arquivo é um recurso compartilhado, o `lock` evita interleaving de escrita.
		lock (_lockObject)
		{
			// Garante que o diretório exista antes de escrever.
			var directory = Path.GetDirectoryName(logFilePath);
			if (!string.IsNullOrWhiteSpace(directory))
			{
				Directory.CreateDirectory(directory);
			}

			// Escreve o conteúdo no final do arquivo.
			File.AppendAllText(logFilePath, message + Environment.NewLine + Environment.NewLine);

			// Mantém o arquivo "bloqueado" por 1 segundo para evidenciar a exclusão mútua.
			// Enquanto este trecho estiver executando, as outras threads ficam aguardando no lock.
			// Thread.Sleep(TimeSpan.FromSeconds(1));
		}
	}
}
