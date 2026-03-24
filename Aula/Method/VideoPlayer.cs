/// <summary>
/// AbstractClass (Classe Abstrata) do padrão Template Method.
/// 
/// Define o esqueleto do algoritmo no método <see cref="ExecutarVideo"/> (Template Method),
/// controlando a ordem de execução das etapas.
/// 
/// Responsabilidades:
/// - Definir o Template Method com a sequência fixa de passos.
/// - Fornecer implementação padrão para etapas comuns a todos os formatos.
/// - Declarar métodos abstratos para etapas que variam conforme o formato do vídeo.
/// 
/// Etapas do algoritmo:
/// 1. CarregarVideo()      → Comum a todos os formatos (implementação padrão).
/// 2. DecodificarFormato() → Específica de cada formato (abstrata, delegada às subclasses).
/// 3. IniciarExecucao()    → Comum a todos os formatos (implementação padrão).
/// </summary>
public abstract class VideoPlayer
{
    /// <summary>
    /// Template Method - Define o esqueleto do algoritmo.
    /// 
    /// Este método controla a ordem fixa dos passos para executar um vídeo.
    /// As subclasses NÃO devem sobrescrever este método, apenas as etapas individuais.
    /// 
    /// Fluxo: Carregar → Decodificar → Iniciar Execução
    /// </summary>
    public void ExecutarVideo()
    {
        CarregarVideo();
        DecodificarFormato();
        IniciarExecucao();
    }

    /// <summary>
    /// Etapa COMUM - Carregar o arquivo de vídeo.
    /// 
    /// Implementação padrão fornecida na classe abstrata, pois esta etapa
    /// é igual para todos os formatos de vídeo.
    /// </summary>
    protected virtual void CarregarVideo()
    {
        Console.WriteLine("  [1] Carregando o arquivo de vídeo...");
    }

    /// <summary>
    /// Etapa ESPECÍFICA - Decodificar o formato do vídeo.
    /// 
    /// Método ABSTRATO: cada formato de vídeo possui um decodificador diferente,
    /// por isso esta etapa é delegada para as subclasses (classes concretas) implementarem.
    /// </summary>
    protected abstract void DecodificarFormato();

    /// <summary>
    /// Etapa COMUM - Iniciar a execução do vídeo.
    /// 
    /// Implementação padrão fornecida na classe abstrata, pois após a decodificação
    /// o processo de execução é o mesmo para todos os formatos.
    /// </summary>
    protected virtual void IniciarExecucao()
    {
        Console.WriteLine("  [3] Iniciando a execução do vídeo...");
    }
}
