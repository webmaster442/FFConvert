// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

namespace FFConvert.Interfaces;

internal interface IImplementationsOf<T> where T : class
{
    bool Contains(string name);
    T Get(string name);

    int Count { get; }
}
