﻿// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using FFConvert.Interfaces;

namespace FFConvert.Infrastructure;

internal sealed class StepRunner : IDisposable
{
    private readonly IStep[] _steps;
    private readonly List<int> _disposables;
    private readonly IConsole _console;

    public StepRunner(IConsole console, params IStep[] steps)
    {
        _disposables = new List<int>(steps.Length);
        _steps = new IStep[steps.Length];
        for (int i = 0; i < steps.Length; i++)
        {
            _steps[i] = steps[i];
            if (_steps[i] is IDisposable)
            {
                _disposables.Add(i);
            }
        }

        _console = console;
    }

    public void Run(State state)
    {
        foreach (var step in _steps)
        {
            if (step.CanSkip(state))
                continue;

            bool canContinue = step.TryExecute(state);

            if (!canContinue)
            {
                _console.Error(step.Issues.ToArray());
                break;
            }
        }
    }

    public void Dispose()
    {
        foreach (int i in _disposables)
        {
            if (_steps[i] is IDisposable disposable)
                disposable.Dispose();
        }
    }
}
