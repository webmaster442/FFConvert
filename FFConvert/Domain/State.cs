namespace FFConvert.Domain;

internal sealed class State
{
    public Preset[] Presets { get; }
    public IList<string> InputFiles { get; }
    public Preset CurrentPreset { get; set; }

    public ProgramConfiguration Configuration { get; }

    public Arguments Arguments { get; }

    public IList<FFMpegCommand> CreatedCommandLines { get; }

    public State(Preset[] presets, ProgramConfiguration configuration, Arguments arguments)
    {
        Presets = presets;
        Arguments = arguments;
        Configuration = configuration;
        CreatedCommandLines = new List<FFMpegCommand>();
        InputFiles = new List<string>();
        CurrentPreset = new Preset();
    }
}
