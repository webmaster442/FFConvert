using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Infrastructure.Validators;

internal class IntValidator : IValidator
{
    public (bool status, string errorMessage) Validate(string input, IDictionary<string, string> parameters)
    {
        try
        {
            int min = int.MinValue;
            int max = int.MaxValue;

            if (parameters.ContainsKey("max"))
                max = int.Parse(parameters["max"]);
            if (parameters.ContainsKey("min"))
                min = int.Parse(parameters["min"]);

            checked
            {
                int value = int.Parse(input);

                if (value < min)
                    throw new ArgumentOutOfRangeException(string.Format(Resources.ErrorMinMaxRange, min, max));
                if (value > max)
                    throw new ArgumentOutOfRangeException(string.Format(Resources.ErrorMinMaxRange, min, max));

                return (true, string.Empty);
            }

        }
        catch (Exception ex) when (ex is FormatException
                                         or OverflowException
                                         or ArgumentOutOfRangeException)
        {
            return (false, ex.Message);
        }
    }
}
