
using FFConvert.Interfaces;

namespace FFConvert.Infrastructure;

public class ProgramConsole : IConsole
{
    public ProgramConsole()
    {
        Console.CancelKeyPress += Console_CancelKeyPress;
    }

    public event EventHandler? CancelEvent;

    private void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
    {
        CancelEvent?.Invoke(sender, EventArgs.Empty);
        e.Cancel = true;
    }

    public string ReadLine()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }

    public void Write(string line)
    {
        Console.Write(line);
    }

    public void Error(params string[] errors)
    {
        var old = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var error in errors)
        {
            Console.WriteLine(error);
        }
        Console.ForegroundColor = old;
    }

}
