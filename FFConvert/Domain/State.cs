namespace FFConvert.Domain;

internal sealed class State
{
    public Preset[] Presets { get; }
    public IList<string> InputFiles { get; }
    public Preset CurrentPreset { get; set; }

    public Arguments Arguments { get; }

    public IList<FFMpegCommand> CreatedCommandLines { get; }

    public State(Preset[] presets, Arguments arguments)
    {
        Presets = presets;
        Arguments = arguments;
        CreatedCommandLines = new List<FFMpegCommand>();
        InputFiles = new List<string>();
        CurrentPreset = new Preset();
    }
}
