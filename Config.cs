
namespace slidegrid;

internal class Config
{
    public string Pathname { get; set; } = string.Empty;

    public List<Grid> Grids { get; set; } = new();
    public List<string> Content { get; set; } = new();
    public List<string> Highlights { get; set; } = new();

    public PlaybackRandomizeMode RandomizeMode { get; set; } = PlaybackRandomizeMode.ShuffleSequences;
    public PlaybackSequenceMode SequenceMode { get; set; } = PlaybackSequenceMode.ByTimestamp;
    public PlaybackStaggerMode StaggerMode { get; set; } = PlaybackStaggerMode.Staggered;
    public double ShuffleTime { get; set; } = 10.0;

    public Config()
    { 
    }

    public Config(string pathname)
    {

    }

    public void Save()
    {

    }
}
