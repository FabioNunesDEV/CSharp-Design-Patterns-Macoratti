using Bridge.Implementor;

namespace Bridge.Abstraction;

/// <summary>
/// Abstraction (Bridge): o controle remoto.
/// Não conhece TV/Rádio concretos; delega tudo para o Implementor (IDispositivo).
/// </summary>
public class ControleRemoto
{
    /// <summary>
    /// Inicia o controle com um dispositivo (implementação) específico.
    /// </summary>
    public ControleRemoto(IDispositivo dispositivo)
    {
        Dispositivo = dispositivo ?? throw new ArgumentNullException(nameof(dispositivo));
    }

    /// <summary>
    /// Referência para o Implementor (ponte do padrão Bridge).
    /// Pode ser trocado em tempo de execução.
    /// </summary>
    public IDispositivo Dispositivo { get; private set; }

    /// <summary>
    /// Troca o implementor (por exemplo, TV -> Rádio) sem alterar o controle.
    /// </summary>
    public void TrocarDispositivo(IDispositivo dispositivo)
    {
        Dispositivo = dispositivo ?? throw new ArgumentNullException(nameof(dispositivo));
    }

    /// <summary>
    /// Encapsula as operações comuns do controle.
    /// A lógica real fica no dispositivo (implementação).
    /// </summary>
    public bool LigarDesligar() => Dispositivo.LigarDesligar();

    public int AumentarVolume() => Dispositivo.AumentarVolume();

    public int AbaixarVolume() => Dispositivo.AbaixarVolume();

    public string OpcaoProxima() => Dispositivo.OpcaoProxima();

    public string OpcaoAnterior() => Dispositivo.OpcaoAnterior();

    public void Reset() => Dispositivo.Reset();
}
