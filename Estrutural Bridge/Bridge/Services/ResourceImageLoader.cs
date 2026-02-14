using System.Collections.Concurrent;
using System.Drawing;

namespace Bridge.Services;

/// <summary>
/// Carrega imagens da pasta `Resources/` (copiada para o diretório de saída) e mantém cache em memória.
/// Objetivo: evitar pré-carregar tudo no Form e evitar recarregar a cada troca.
/// </summary>
public sealed class ResourceImageLoader : IImageProvider
{
    // Cache simples por chave ("TV", "Radio"...), ignorando maiúsculas/minúsculas.
    private readonly ConcurrentDictionary<string, Image> _cache = new(StringComparer.OrdinalIgnoreCase);

    public Image Get(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Chave inválida.", nameof(key));

        // Lazy-load: só carrega do disco na primeira vez.
        return _cache.GetOrAdd(key, LoadFromResources);
    }

    private static Image LoadFromResources(string nomeBase)
    {
        // Convenção do projeto: arquivos em `Resources/TV.png` e `Resources/Radio.png`.
        var baseDir = AppContext.BaseDirectory;
        var dir = Path.Combine(baseDir, "Resources");
        var candidates = new[]
        {
            Path.Combine(dir, $"{nomeBase}.png"),
            Path.Combine(dir, $"{nomeBase}.jpg"),
            Path.Combine(dir, $"{nomeBase}.jpeg"),
        };

        foreach (var path in candidates)
        {
            if (!File.Exists(path))
                continue;

            // Clona a imagem para não manter o arquivo aberto.
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var img = Image.FromStream(fs);
            return new Bitmap(img);
        }

        // Fallback para não quebrar a UI caso a imagem não exista.
        return new Bitmap(1, 1);
    }
}
