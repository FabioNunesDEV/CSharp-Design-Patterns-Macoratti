using System.Drawing;

namespace Bridge.Implementor;

/// <summary>
/// Implementor (Bridge): contrato que todo dispositivo (TV, Rádio, etc.) deve expor.
/// A Abstraction (controle remoto) conversa apenas com esta interface.
/// </summary>
public interface IDispositivo
{
    /// <summary>
    /// Nome do dispositivo (ex.: "TV", "Radio").
    /// </summary>
    string Nome { get; }

    /// <summary>
    /// Incremento/decremento de volume.
    /// </summary>
    int Step { get; }
    int VolumeMin { get; }
    int VolumeMax { get; }

    /// <summary>
    /// Lista de canais/estações disponíveis.
    /// </summary>
    IReadOnlyList<string> Opcoes { get; }

    /// <summary>
    /// Estado de energia atual.
    /// </summary>
    bool Ligado { get; set; }

    /// <summary>
    /// Estado atual do volume.
    /// </summary>
    int VolumeAtual { get; }

    /// <summary>
    /// Índice atual da opção (canal/estação).
    /// </summary>
    int OpcaoAtualIndex { get; }

    /// <summary>
    /// Opção atual (derivada do índice).
    /// </summary>
    string OpcaoAtual { get; }

    /// <summary>
    /// Aumenta o volume respeitando min/max.
    /// </summary>
    int AumentarVolume();

    /// <summary>
    /// Diminui o volume respeitando min/max.
    /// </summary>
    int AbaixarVolume();

    /// <summary>
    /// Vai para a opção anterior (canal/estação), sem ultrapassar o primeiro item.
    /// </summary>
    string OpcaoAnterior();

    /// <summary>
    /// Vai para a próxima opção (canal/estação), sem ultrapassar o último item.
    /// </summary>
    string OpcaoProxima();

    /// <summary>
    /// Alterna o estado de energia (liga/desliga).
    /// </summary>
    bool LigarDesligar();

    /// <summary>
    /// Reseta o estado do dispositivo para os valores iniciais (volume e opção).
    /// </summary>
    void Reset();

    /// <summary>
    /// Retorna a imagem associada ao dispositivo (para exibição na UI).
    /// </summary>
    Image RetornarImagem();
}
