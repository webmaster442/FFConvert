namespace FFConvert.Interfaces;

internal interface IValidator
{
    (bool status, string errorMessage) Validate(string input, IDictionary<string, string> parameters);
}
