namespace Spectre.Console.Cli;

/// <summary>
/// An attribute representing the header of the help text for a command.
/// </summary>
/// <seealso cref="Attribute" />
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class HelpTextHeaderAttribute : Attribute
{
    /// <summary>
    /// Gets the header of the help text.
    /// </summary>
    public string Header { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpTextHeaderAttribute"/> class.
    /// </summary>
    /// <param name="header">The header of the help text.</param>
    public HelpTextHeaderAttribute(string header)
    {
        if (header == null)
        {
            throw new ArgumentNullException(nameof(header));
        }

        Header = header;
    }
}
