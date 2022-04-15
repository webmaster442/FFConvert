
using FFConvert.Interfaces;

namespace FFConvert.Infrastructure.Validators;

internal class TimeValidator : IValidator
{
    public (bool status, string errorMessage) Validate(string input, IDictionary<string, string> parameters)
    {
        if (string.IsNullOrEmpty(input))
            return (true, string.Empty);

        try
        {
            TimeSpan.TryParse(input, out _);
            return (true, string.Empty);
        }
        catch (FormatException ex)
        {
            return (false, ex.Message);
        }

    }
}
