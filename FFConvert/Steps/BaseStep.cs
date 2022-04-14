// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using FFConvert.Interfaces;

namespace FFConvert.Steps;

internal abstract class BaseStep : IStep
{
    private readonly List<string> _issues;

    protected BaseStep()
    {
        _issues = new List<string>();
    }

    public IEnumerable<string> Issues => _issues;

    protected void AddIssue(string format, params object[] parameters)
    {
        _issues.Add(string.Format(format, parameters));
    }

    protected bool AreNoIssues()
    {
        return _issues.Count == 0;
    }

    public abstract bool TryExecute(State state);
}
