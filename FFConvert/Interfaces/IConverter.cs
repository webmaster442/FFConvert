namespace FFConvert.Interfaces;

internal interface IConverter
{
    (bool result, string converted, string issue) Convert(string input);
}
