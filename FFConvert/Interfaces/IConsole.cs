﻿namespace FFConvert.Interfaces;

internal interface IConsole
{
    string ReadLine();

    void WriteLine(string line);

    void Write(string line);

    void Error(params string[] errors);

    event EventHandler? CancelEvent;
}
