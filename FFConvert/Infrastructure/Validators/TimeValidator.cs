
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
            var parsed = TimeSpan.Parse(input);

            if (parsed.TotalSeconds < 0)
                throw new FormatException("Value can't be negative");

            return (true, string.Empty);
        }
        catch (FormatException ex)
        {
            return (false, ex.Message);
        }

    }
}
