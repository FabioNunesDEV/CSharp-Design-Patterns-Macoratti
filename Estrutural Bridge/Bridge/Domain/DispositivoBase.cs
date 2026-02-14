using System.Drawing;
using Bridge.Implementor;

namespace Bridge.Domain;

/// <summary>
/// Classe base para dispositivos concretos do exemplo (TV/Rádio).
/// Centraliza as regras de negócio comuns: volume, lista de opções e reset.
/// </summary>
public abstract class DispositivoBase : IDispositivo
{
    private readonly List<string> _opcoes;

    /// <summary>
    /// Construtor protegido: usado apenas pelas classes concretas.
    /// A imagem é recebida por parâmetro (injeção) para manter essa classe focada no domínio.
    /// </summary>
    protected DispositivoBase(
        string nome,
        int step,
        int volumeMin,
        int volumeMax,
        IEnumerable<string> opcoes,
        Image imagem)
    {
        Nome = nome;
        Step = step;
        VolumeMin = volumeMin;
        VolumeMax = volumeMax;

        _opcoes = opcoes?.ToList() ?? throw new ArgumentNullException(nameof(opcoes));
        if (_opcoes.Count == 0)
            throw new ArgumentException("A lista de opções não pode ser vazia.", nameof(opcoes));

        Imagem = imagem ?? throw new ArgumentNullException(nameof(imagem));

        Ligado = false;
        Reset();
    }

    public string Nome { get; }
    public int Step { get; }
    public int VolumeMin { get; }
    public int VolumeMax { get; }

    public IReadOnlyList<string> Opcoes => _opcoes;

    public bool Ligado { get; set; }

    public int VolumeAtual { get; private set; }
    public int OpcaoAtualIndex { get; private set; }
    public string OpcaoAtual => _opcoes[OpcaoAtualIndex];

    protected Image Imagem { get; }

    /// <summary>
    /// Aplica o step e respeita VolumeMax.
    /// </summary>
    public int AumentarVolume()
    {
        VolumeAtual = Math.Min(VolumeMax, VolumeAtual + Step);
        return VolumeAtual;
    }

    /// <summary>
    /// Aplica o step e respeita VolumeMin.
    /// </summary>
    public int AbaixarVolume()
    {
        VolumeAtual = Math.Max(VolumeMin, VolumeAtual - Step);
        return VolumeAtual;
    }

    /// <summary>
    /// Navega para a opção anterior (sem passar do início).
    /// </summary>
    public string OpcaoAnterior()
    {
        OpcaoAtualIndex = Math.Max(0, OpcaoAtualIndex - 1);
        return OpcaoAtual;
    }

    /// <summary>
    /// Navega para a próxima opção (sem passar do fim).
    /// </summary>
    public string OpcaoProxima()
    {
        OpcaoAtualIndex = Math.Min(_opcoes.Count - 1, OpcaoAtualIndex + 1);
        return OpcaoAtual;
    }

    /// <summary>
    /// Alterna o estado de energia.
    /// A UI é quem decide habilitar/desabilitar botões conforme esse estado.
    /// </summary>
    public bool LigarDesligar()
    {
        Ligado = !Ligado;
        return Ligado;
    }

    /// <summary>
    /// Estado inicial do dispositivo: volume mínimo e primeira opção.
    /// </summary>
    public void Reset()
    {
        VolumeAtual = VolumeMin;
        OpcaoAtualIndex = 0;
    }

    /// <summary>
    /// Devolve a imagem do dispositivo para a UI.
    /// </summary>
    public Image RetornarImagem() => Imagem;
}
