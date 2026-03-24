/// <summary>
/// ConcreteClass (Classe Concreta) do padrão Template Method.
/// 
/// Implementa a etapa específica de decodificação para o formato MP4.
/// Herda de <see cref="VideoPlayer"/> e sobrescreve apenas o método abstrato
/// <see cref="DecodificarFormato"/>, que é o passo que varia conforme o formato.
/// 
/// As etapas comuns (CarregarVideo e IniciarExecucao) são herdadas da classe base
/// sem necessidade de reimplementação, evitando duplicação de código.
/// </summary>
public class VideoMP4 : VideoPlayer
{
    /// <summary>
    /// Implementação específica da decodificação para o formato MP4.
    /// Utiliza o decodificador adequado para processar arquivos .mp4.
    /// </summary>
    protected override void DecodificarFormato()
    {
        Console.WriteLine("  [2] Processando vídeo usando o decodificador MP4...");
    }
}
