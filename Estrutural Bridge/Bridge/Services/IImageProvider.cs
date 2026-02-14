using System.Drawing;

namespace Bridge.Services;

/// <summary>
/// Abstração para obtenção de imagens (ex.: a partir de um diretório, recursos embutidos, web etc.).
/// Mantém a UI desacoplada do detalhe de I/O.
/// </summary>
public interface IImageProvider
{
    /// <summary>
    /// Obtém a imagem associada à chave (ex.: "TV", "Radio").
    /// Implementações podem aplicar cache.
    /// </summary>
    Image Get(string key);
}
