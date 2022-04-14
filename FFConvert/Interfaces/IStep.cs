// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;

namespace FFConvert.Interfaces;

internal interface IStep
{
    IEnumerable<string> Issues { get; }
    bool TryExecute(State state);
}
