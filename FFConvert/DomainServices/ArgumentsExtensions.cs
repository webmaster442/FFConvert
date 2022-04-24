// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

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

    public static bool IsSwitchPresent(this Arguments arguments, string @switch)
    {
        return arguments.OtherOptions.Contains(@switch);
    }

    public static bool TryGetSwitchWithValue(this Arguments arguments, string @switch, out string value)
    {
        for (int i = 0; i < arguments.OtherOptions.Count; i++)
        {
            string next = i + 1 < arguments.OtherOptions.Count ? arguments.OtherOptions[i + 1] : string.Empty;
            if (!string.IsNullOrEmpty(next)
                && !next.StartsWith("-"))
            {
                value = next;
                return true;
            }
        }
        value = string.Empty;
        return false;
    }

    public static bool IsInstallCommand(this Arguments arguments)
    {
        return arguments.FileName == Constants.SwitchInstall
            && arguments.PresetName?.Length == 0
            && arguments.OutputDirectory?.Length == 0;
    }
}
