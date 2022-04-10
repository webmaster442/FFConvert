namespace FFConvert.Interfaces;

internal interface IImplementationsOf<T> where T : class
{
    bool Contains(string name);
    T Get(string name);

    int Count { get; }
}
