// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using System.Text;
using FFConvert.Interfaces;

namespace FFConvert.Infrastructure
{
    internal class ProgressReporter : IProgressReport
    {
        private const int Maximum = 100;
        private const int Minimum = 0;
        private readonly IConsole _console;

        public ProgressReporter(IConsole console)
        {
            _console = console;
        }

        public void Hide()
        {
            _console.Write("\x1b[?1049l");
        }

        public void Report(ConvertProgress value)
        {
            const int range = (Maximum - Minimum);
            int maxChars = _console.WindowWidth - "   ││   ".Length;
            int charcount = (int)((value.Percent * maxChars) / range);
            StringBuilder buffer = new();

            buffer.Append("   │");
            for (int i = 0; i < maxChars; i++)
            {
                if (i < charcount)
                    buffer.Append('█');
                else
                    buffer.Append(' ');
            }
            buffer.Append("│   ");

            int height = (_console.WindowHeight - 3) / 2;

            _console.SetCursorPosition(0, height);
            _console.Write(buffer.ToString());
            _console.Write(buffer.ToString());
            _console.WriteLine($"  {value.ProcessedFile}");
            _console.WriteLine($"  {value.StatusMsg}");
        }

        public void Show()
        {
            _console.Write("\x1b[?1049h");
        }
    }
}
