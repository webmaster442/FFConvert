namespace FFConvert.Interfaces;

internal interface IConsole
{
    int WindowHeight { get; }
    int WindowWidth { get; }

    string ReadLine();

    void WriteLine(string line);

    void Write(string line);

    void Error(params string[] errors);

    event EventHandler? CancelEvent;

    void SetCursorPosition(int left, int top);
}
