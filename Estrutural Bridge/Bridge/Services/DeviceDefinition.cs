using Bridge.Implementor;

namespace Bridge.Services;

/// <summary>
/// Define como um dispositivo aparece na UI (DisplayName) e como ele é criado.
/// Isso evita duplicação de strings e switches no Form.
/// </summary>
public sealed record DeviceDefinition(
    string Key,
    string DisplayName,
    Func<IDispositivo> Create)
{
    // Facilita debug/exibição quando necessário.
    public override string ToString() => DisplayName;
}
