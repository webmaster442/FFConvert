
using FFConvert.Domain;
using FFConvert.DomainServices;

namespace FFConvert.Steps;

internal class CollectInputFilesFromFile : BaseStep
{
    public override bool CanSkip(State state)
    {
        return state.Arguments.InputFileContainsWildCard()
            || !state.Arguments.IsSwitchPresent(Constants.SwitchInputList);
    }

    public override bool TryExecute(State state)
    {
        try
        {
            var file = Path.GetFullPath(state.Arguments.FileName);
            using (var reader = File.OpenText(file))
            {
                string? line;
                do
                {
                    line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        var path = Path.GetFullPath(line);
                        if (File.Exists(path))
                        {
                            state.InputFiles.Add(path);
                        }
                    }
                }
                while (line != null);
            }
        }
        catch (Exception ex)
        {
            AddIssue(ex.Message);
        }

        return AreNoIssues();
    }
}
