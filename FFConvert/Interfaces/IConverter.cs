namespace FFConvert.Interfaces;

public interface IConverter
{
    (bool result, string converted, string issue) Convert(string input);
}
