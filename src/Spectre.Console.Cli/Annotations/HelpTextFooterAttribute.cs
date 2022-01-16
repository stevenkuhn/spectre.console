namespace Spectre.Console.Cli;

/// <summary>
/// An attribute representing the footer of the help text for a command.
/// </summary>
/// <seealso cref="Attribute" />
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class HelpTextFooterAttribute : Attribute
{
    /// <summary>
    /// Gets the footer of the help text.
    /// </summary>
    public string Footer { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpTextFooterAttribute"/> class.
    /// </summary>
    /// <param name="footer">The footer of the help text.</param>
    public HelpTextFooterAttribute(string footer)
    {
        if (footer == null)
        {
            throw new ArgumentNullException(nameof(footer));
        }

        Footer = footer;
    }
}
