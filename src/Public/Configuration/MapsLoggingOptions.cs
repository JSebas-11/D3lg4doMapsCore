using Microsoft.Extensions.Logging;

namespace D3lg4doMaps.Core.Public.Configuration;

public sealed class MapsLoggingOptions {
    public bool Enabled { get; set; } = true;
    public LogLevel Level { get; set; } = LogLevel.Information;
    public string? MessagePrefix { get; set; } = "[D3lg4doMaps]";
}