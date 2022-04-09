using FFConvert.Domain;

namespace FFConvert.Interfaces;

internal interface IStep
{
    IEnumerable<string> Issues { get; }
    bool TryExecute(State currentState);
}
