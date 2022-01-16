namespace Spectre.Console.Cli;

internal sealed class CommandModel : ICommandContainer
{
    public string? ApplicationName { get; }
    public string? ApplicationVersion { get; }
    public string? ApplicationHelpTextHeader { get; }
    public string? ApplicationHelpTextFooter { get; }
    public ParsingMode ParsingMode { get; }
    public CommandInfo? DefaultCommand { get; }
    public IList<CommandInfo> Commands { get; }
    public IList<string[]> Examples { get; }
    public bool TrimTrailingPeriod { get; }

    public CommandModel(
        CommandAppSettings settings,
        CommandInfo? defaultCommand,
        IEnumerable<CommandInfo> commands,
        IEnumerable<string[]> examples)
    {
        ApplicationName = settings.ApplicationName;
        ApplicationVersion = settings.ApplicationVersion;
        ApplicationHelpTextHeader = settings.ApplicationHelpTextHeader;
        ApplicationHelpTextFooter = settings.ApplicationHelpTextFooter;
        ParsingMode = settings.ParsingMode;
        TrimTrailingPeriod = settings.TrimTrailingPeriod;
        DefaultCommand = defaultCommand;
        Commands = new List<CommandInfo>(commands ?? Array.Empty<CommandInfo>());
        Examples = new List<string[]>(examples ?? Array.Empty<string[]>());
    }

    public string GetApplicationName()
    {
        return
            ApplicationName ??
            Path.GetFileName(GetApplicationFile()) ?? // null is propagated by GetFileName
            "?";
    }

    public string GetApplicationVersion()
    {
        return
            ApplicationVersion ??
            VersionHelper.GetVersion(Assembly.GetEntryAssembly());
    }

    private static string? GetApplicationFile()
    {
        var location = Assembly.GetEntryAssembly()?.Location;
        if (string.IsNullOrWhiteSpace(location))
        {
            // this is special case for single file executable
            // (Assembly.Location returns empty string)
            return Process.GetCurrentProcess().MainModule?.FileName;
        }

        return location;
    }
}