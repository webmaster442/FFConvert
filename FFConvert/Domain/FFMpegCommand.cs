// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

namespace FFConvert.Domain;

internal sealed class FFMpegCommand
{
    public string CommandLine { get; init; }
    public string OutputFile { get; init; }
    public string InputFile { get; init; }

    public FFMpegCommand()
    {
        InputFile = string.Empty;
        CommandLine = string.Empty;
        OutputFile = string.Empty;
    }
}
