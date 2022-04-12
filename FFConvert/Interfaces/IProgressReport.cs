using FFConvert.Domain;

namespace FFConvert.Interfaces;

internal interface IProgressReport : IProgress<ConvertProgress>
{
    void Show();
    void Hide();
}
