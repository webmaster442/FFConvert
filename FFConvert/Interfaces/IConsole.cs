// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

namespace FFConvert.Interfaces;

internal interface IConsole
{
    int WindowHeight { get; }
    int WindowWidth { get; }
    void SetCursorPosition(int left, int top);

    string ReadLine();
    void WriteLine(string line);
    void Write(string line);
    void Error(params string[] errors);
    event EventHandler? CancelEvent;

    void Clear();
}
