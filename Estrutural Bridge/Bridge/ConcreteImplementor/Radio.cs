using System.Drawing;
using Bridge.Domain;

namespace Bridge.ConcreteImplementor;

/// <summary>
/// ConcreteImplementor (Bridge): implementação concreta de um dispositivo do tipo Rádio.
/// Define estações, limites e step. As regras comuns ficam em DispositivoBase.
/// </summary>
public sealed class Radio : DispositivoBase
{
    /// <summary>
    /// A imagem é fornecida pelo serviço de imagens (lazy + cache).
    /// </summary>
    public Radio(Image imagem)
        : base(
            nome: "Radio",
            step: 2,
            volumeMin: 0,
            volumeMax: 50,
            opcoes:
            [
                "Jovem Pan FM 100,9",
                "FM O Dia 100,5",
                "BandNews FM 96,9",
                "CBN SP 90,5",
                "Rádio Bandeirantes 90,9",
                "Mix FM 106,3",
                "Transamérica 100,1",
                "Alpha FM 101,7",
                "Antena 1 94,7",
                "89 FM A Rádio Rock 89,1",
                "Kiss FM 92,5",
                "Energia 97 97,7",
                "Nova Brasil FM 89,7",
                "Disney FM 91,3",
                "Rádio USP FM 93,7",
            ],
            imagem: imagem)
    {
    }
}
