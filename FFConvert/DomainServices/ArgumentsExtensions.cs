using FFConvert.Domain;

namespace FFConvert.DomainServices;

internal static class ArgumentsExtensions
{
    public static bool IsSyntaxValid(this Arguments arguments)
    {
        return arguments.Count == 3
            && !string.IsNullOrEmpty(arguments.FileName)
            && !string.IsNullOrEmpty(arguments.PresetName)
            && !string.IsNullOrEmpty(arguments.OutputDirectory);
    }

    public static bool InputFileContainsWildCard(this Arguments arguments)
    {
        foreach (char chr in arguments.FileName)
        {
            switch (chr)
            {
                case '*':
                case '?':
                case '\\':
                    return true;
            }
        }
        return false;
    }

    public static bool IsGenericHelpRequested(this Arguments arguments)
    {
        return (string.IsNullOrEmpty(arguments.FileName)
            || arguments.FileName == "help")
            && string.IsNullOrEmpty(arguments.PresetName);
    }

    public static bool IsSpecificHelpRequested(this Arguments arguments)
    {
        return arguments.FileName == "help"
            && !string.IsNullOrEmpty(arguments.PresetName);
    }
}
