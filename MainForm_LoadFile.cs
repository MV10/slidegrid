
namespace slidegrid;

public partial class MainForm
{
    private enum LoadFileSection
    {
        None, Playback, Grids, Content, Highlights
    }

    private bool LoadFile(string pathname)
    {
        int linenum = 0;
        string originalText = "(failure loading file)";

        var section = LoadFileSection.None;

        try
        {
            foreach(var text in File.ReadAllLines(pathname))
            {
                linenum++;
                originalText = text.Trim();

                var data = originalText.ToUpperInvariant();
                if (data.Length == 0 || data.StartsWith("#")) continue;

                switch(data)
                {
                    case "[PLAYBACK]":
                        section = LoadFileSection.Playback;
                        continue;

                    case "[GRIDS]":
                        section = LoadFileSection.Grids;
                        continue;

                    case "[CONTENT]":
                        section = LoadFileSection.Content;
                        continue;

                    case "[HIGHLIGHTS]":
                        section = LoadFileSection.Highlights;
                        continue;
                }

                switch(section)
                {
                    case LoadFileSection.None:
                        continue;

                    case LoadFileSection.Content:
                        if (!Path.IsPathFullyQualified(originalText)) throw new Exception("Can't parse Content pathspec");
                        lstContent.Items.Add(originalText);
                        continue;

                    case LoadFileSection.Highlights:
                        if (!Path.IsPathFullyQualified(originalText)) throw new Exception("Can't parse Highlights pathspec");
                        lstHighlight.Items.Add(originalText);
                        continue;

                    case LoadFileSection.Grids:
                        if (Grids.Count == 10) throw new Exception("More than 10 Grids definitions is not supported");
                        int[] vals;
                        try
                        {
                            vals = Array.ConvertAll(data.Split(','), int.Parse);
                            if (vals.Length != 6) throw new();
                        }
                        catch
                        {
                            throw new Exception("Can't parse Grids entry");
                        }
                        if (vals[2] < 1 || vals[3] < 1) throw new Exception("Invalid Grid entry width or height");
                        if (!Enum.IsDefined((GridAdvanceMode)vals[4])) throw new Exception("Invalid Grid AdvanceMode");
                        if (!Enum.IsDefined((GridResizeMode)vals[5])) throw new Exception("Invalid Grid ResizeMode");
                        Grids.Add(new Grid
                        {
                            Dimensions = new(vals[0], vals[1], vals[2], vals[3]),
                            AdvanceMode = (GridAdvanceMode)vals[4],
                            ResizeMode = (GridResizeMode)vals[5]
                        });
                        continue;

                    case LoadFileSection.Playback:
                        if (!data.Contains(':')) throw new Exception("Can't parse Playback entry");
                        var separator = data.IndexOf(':');
                        var setting = data.Substring(0, separator);
                        var settingvalue = data.Substring(separator + 2);
                        if (separator + 1 >= data.Length) throw new Exception("Can't parse Playback setting");
                        switch(setting)
                        {
                            case "RANDOMIZEMODE":
                                if(!int.TryParse(settingvalue, out var rndval)) throw new Exception("Can't parse Playback RandomizeMode setting");
                                if (!Enum.IsDefined((PlaybackRandomizeMode)rndval)) throw new Exception("Invalid Playback RandomizeMode setting");
                                cmbRandomize.SelectedIndex = rndval;
                                continue;

                            case "SEQUENCEMODE":
                                if (!int.TryParse(settingvalue, out var seqval)) throw new Exception("Can't parse Playback SequenceMode setting");
                                if (!Enum.IsDefined((PlaybackSequenceMode)seqval)) throw new Exception("Invalid Playback SequenceMode setting");
                                cmbSequencing.SelectedIndex = seqval;
                                continue;

                            case "STAGGERMODE":
                                if (!int.TryParse(settingvalue, out var stgval)) throw new Exception("Can't parse Playback StaggerMode setting");
                                if (!Enum.IsDefined((PlaybackStaggerMode)stgval)) throw new Exception("Invalid Playback StaggerMode setting");
                                cmbStagger.SelectedIndex = stgval;
                                continue;

                            case "SHUFFLETIME":
                                if (!double.TryParse(settingvalue, out var shuffle)) throw new Exception("Can't parse Playback ShuffleTime setting");
                                if (shuffle < 0.5) throw new Exception("Invalid Playback ShuffleTime setting");
                                txtShuffleTime.Text = shuffle.ToString();
                                continue;

                            case "SEQUENCELENGTH":
                                if (!int.TryParse(settingvalue, out var len)) throw new Exception("Can't parse Playback SequenceLength setting");
                                if (len < 2) throw new Exception("Invalid Playback SequenceLength setting");
                                txtLength.Text = len.ToString();
                                continue;

                            case "HIGHLIGHTFREQ":
                                if (!int.TryParse(settingvalue, out var freq)) throw new Exception("Can't parse Playback HiglightFreq setting");
                                if (freq < 0 || freq > 100) throw new Exception("Invalid Playback HiglightFreq setting");
                                txtFreq.Text = freq.ToString();
                                continue;

                            default:
                                throw new Exception("Unrecognized Playback entry");
                        }
                }
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n\nLoad failed at file line: {linenum}\n{originalText}", "Error");
            return false;
        }

        return true;
    }
}
