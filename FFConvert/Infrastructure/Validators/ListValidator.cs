using FFConvert.Interfaces;
using FFConvert.Properties;

namespace FFConvert.Infrastructure.Validators;

public class ListValidator : IValidator
{
    public (bool status, string errorMessage) Validate(string input, IDictionary<string, string> parameters)
    {
        try
        {
            checked
            {
                int[] valid = parameters["valid"]
                    .Split(',')
                    .Select(x => int.Parse(x))
                    .ToArray();


                int value = -1;
                if (parameters.ContainsKey("ignoreSuffix"))
                {
                    value = int.Parse(input.Replace(parameters["ignoreSuffix"], ""));
                }
                else
                {
                    value = int.Parse(input);
                }

                if (!valid.Contains(value))
                {
                    throw new ArgumentOutOfRangeException(string.Format(Resources.ErrorInvalidValue, parameters["valid"]));
                }

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
