using Bridge.ConcreteImplementor;

namespace Bridge.Services;

/// <summary>
/// Catálogo explícito de dispositivos suportados.
/// Para adicionar um novo dispositivo, registre aqui (e o Form não precisa ser alterado).
/// </summary>
public static class DeviceCatalog
{
    /// <summary>
    /// Cria as definições de dispositivos disponíveis.
    /// O provider de imagens é injetado para manter o carregamento de recursos centralizado.
    /// </summary>
    public static IReadOnlyList<DeviceDefinition> CreateAll(IImageProvider imageProvider)
    {
        if (imageProvider is null)
            throw new ArgumentNullException(nameof(imageProvider));

        return new List<DeviceDefinition>
        {
            new(
                Key: "TV",
                DisplayName: "TV",
                Create: () => new Televisao(imageProvider.Get("TV"))),

            new(
                Key: "Radio",
                DisplayName: "Radio",
                Create: () => new Radio(imageProvider.Get("Radio"))),
        };
    }
}
