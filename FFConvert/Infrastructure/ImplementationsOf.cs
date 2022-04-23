// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Interfaces;

namespace FFConvert.Infrastructure;

internal sealed class ImplementationsOf<T> : IImplementationsOf<T> where T : class
{
    private readonly Dictionary<string, T> _implementations;

    public ImplementationsOf()
    {
        var items = typeof(ImplementationsOf<T>)
            .Assembly.DefinedTypes
            .Where(x => x.ImplementedInterfaces.Contains(typeof(T)) && !x.IsAbstract)
            .Select(x => Activator.CreateInstance(x) as T);

        _implementations = new Dictionary<string, T>();

        foreach (var item in items)
        {
            if (item != null)
            {
                _implementations.Add(item.GetType().Name, item);
            }
        }
    }

    public int Count => _implementations.Count;

    public bool Contains(string name)
    {
        return _implementations.ContainsKey(name);
    }

    public T Get(string name)
    {
        return _implementations[name];
    }
}
