// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

using FFConvert.Domain;
using FFConvert.DomainServices;
using FFConvert.Properties;
using System.Text;
using System.Text.RegularExpressions;

namespace FFConvert.Steps;

internal class CreateCommandLines : BaseStep
{
    private const string InputKey = "%input%";
    private const string OutputKey = "%output%";
    private const string SourceExtKey = "%sourceext%";

    private readonly Regex _paramRegex = new(@"\%(\w+)\%", RegexOptions.Compiled);

    private static Dictionary<ParameterKey, string> CreateParamDictionary(State currentState)
    {
        Dictionary<ParameterKey, string> parameters = new()
        {
            {  new ParameterKey(InputKey, false), "" },
            {  new ParameterKey(OutputKey, false), "" },
        };
        foreach (var parameter in currentState.CurrentPreset.ParametersToAsk)
        {
            if (!parameter.IsOptional 
                || (parameter.IsOptional && !string.IsNullOrEmpty(parameter.Value)))
            {
                parameters.Add(new ParameterKey(parameter), parameter.Value);
            }
        }
        return parameters;
    }

    public override bool TryExecute(State state)
    {
        Dictionary<ParameterKey, string> parameters = CreateParamDictionary(state);

        if (!CheckIfParameterCountMatches(state.CurrentPreset, parameters))
        {
            AddIssue(Resources.ErrorParamCountMissmatch);
            return false;
        }

        foreach (string inputfile in state.InputFiles)
        {
            parameters[new ParameterKey(InputKey, false)] = inputfile;

            string extension = state.CurrentPreset.TargetExtension;
            if (extension == SourceExtKey)
            {
                extension = Path.GetExtension(inputfile);
            }

            string outFile = FileSystem.CreateOutputFile(inputfile, extension, state.Arguments.OutputDirectory);

            parameters[new ParameterKey(OutputKey, false)] = outFile;

            if (state.CurrentPreset.TargetExtension == SourceExtKey)
            {
                outFile = Path.ChangeExtension(outFile, extension);
            }

            state.CreatedCommandLines.Add(new FFMpegCommand
            {
                CommandLine = FillParameters(state.CurrentPreset, parameters),
                OutputFile = outFile,
                InputFile = inputfile,
            });
        }

        return AreNoIssues();
    }


    private static string EscapePathIfNeeded(string path)
    {
        return !path.Contains(' ') ? path : $"\"{path}\"";
    }

    private static string FillParameters(Preset preset, Dictionary<ParameterKey, string> parameters)
    {
        StringBuilder sb = new(preset.CommandLine);
        foreach (var parameter in parameters)
        {
            if (!parameter.Key.IsOptional)
            {
                sb.Replace(parameter.Key.Name, EscapePathIfNeeded(parameter.Value));
            }
            else
            {
                var optionalContent = preset.ParametersToAsk
                    .Where(p => p.ParameterName == parameter.Key.Name)
                    .Select(p => p.OptionalContent)
                    .FirstOrDefault();

                if (!string.IsNullOrEmpty(optionalContent))
                {
                    string value = optionalContent.Replace(parameter.Key.Name, parameter.Value);
                    sb.Replace(parameter.Key.Name, value);
                }
            }
            
        }
        return sb.ToString();
    }

    private bool CheckIfParameterCountMatches(Preset currentPreset, Dictionary<ParameterKey, string> parameters)
    {
        MatchCollection matches = _paramRegex.Matches(currentPreset.CommandLine);
        int count = 0;
        foreach (Match match in matches)
        {
            if (parameters.Keys.Any(x => x.Name == match.Value))
                ++count;
            else
                --count;
        }

        return count == parameters.Count;

    }
}
