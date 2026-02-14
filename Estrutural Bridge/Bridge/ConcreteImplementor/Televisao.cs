using System.Drawing;
using Bridge.Domain;

namespace Bridge.ConcreteImplementor;

/// <summary>
/// ConcreteImplementor (Bridge): implementação concreta de um dispositivo do tipo TV.
/// Aqui ficam apenas os dados/configurações específicas (canais, limites, step).
/// </summary>
public sealed class Televisao : DispositivoBase
{
    /// <summary>
    /// A imagem é fornecida de fora (via serviço de imagens) para evitar I/O no domínio.
    /// </summary>
    public Televisao(Image imagem)
        : base(
            nome: "TV",
            step: 5,
            volumeMin: 0,
            volumeMax: 100,
            opcoes:
            [
                "Globo SP (5)",
                "Record SP (7)",
                "SBT (4)",
                "Band (13)",
                "RedeTV! (9)",
                "TV Cultura (2)",
                "Gazeta (11)",
                "TV Brasil (1)",
                "RIT (10)",
                "Canal 21 (21)",
            ],
            imagem: imagem)
    {
    }
}
