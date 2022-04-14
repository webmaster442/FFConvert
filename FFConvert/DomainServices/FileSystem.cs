// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace FFConvert.DomainServices;

internal static class FileSystem
{
    private static bool IsWindows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    private static bool ContainsPathSeperator(string input)
    {
        if (IsWindows())
            return input.Contains('\\');
        else
            return input.Contains('/');
    }

    private static bool HasRootDir(string input)
    {
        if (IsWindows())
            return input.Contains(":\\");
        else
            return input.Contains('/');
    }

    private static string WildcardToRegex(string pattern)
    {
        return "^" + Regex.Escape(pattern).
        Replace("\\*", ".*").
        Replace("\\?", ".") + "$";
    }

    public static string GetWorkingDirectoryFromInputFile(string inputfile)
    {
        if (!ContainsPathSeperator(inputfile))
        {
            //it's in current dir
            return Environment.CurrentDirectory;
        }
        else if (HasRootDir(inputfile))
        {
            //full path
            return Path.GetDirectoryName(inputfile) ?? string.Empty;
        }
        else
        {
            //relatvie paths
            string relative = Path.GetFullPath(inputfile);
            return Path.GetDirectoryName(relative) ?? string.Empty;
        }
    }

    public static IEnumerable<string> GetFilesMatchingWildCard(string directory, string filter)
    {
        Regex r = new(WildcardToRegex(filter), RegexOptions.Compiled);
        string[] filters = Directory.GetFiles(directory);
        foreach (string file in filters)
        {
            string fileName = Path.GetFileName(file);
            if (r.IsMatch(fileName))
            {
                yield return file;
            }
        }
    }

    public static string CreateOutputFile(string inputfile, string targetExtension, string outputDirectory)
    {
        string fileName = Path.GetFileName(inputfile);
        string targetName = Path.ChangeExtension(fileName, targetExtension);
        return Path.Combine(outputDirectory, targetName);
    }
}
