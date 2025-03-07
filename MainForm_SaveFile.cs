
namespace slidegrid;

public partial class MainForm
{
    private void SaveFile(Stream stream)
    {
        using var writer = new StreamWriter(stream);

        writer.WriteLine(
@"##########################################################################
# SlideGrid Config File
#
# All content including comments were generated. If you modify the
# file manually then re-save, any changes will be replaced by the
# boilerplate content you see here. If any value is omitted, option
# 0 is the default, and Shuffle Time defaults to 10 seconds. Any
# invalid option aborts the file load.

##########################################################################
# The Playback section settings are as follows:
#
# RandomizeMode:   0-Shuffle, 1-Sequential, 
#                  2-SequentialRandomStart, 3-ShuffleSequences
#
# SequenceMode:    0-NotSequenced, 1-ByFilename, 2-ByTimestamp
#
# StggerMode:      0-NotShuffled, 1-Synchronized, 2-Staggered
#
# ShuffleTime:     seconds, 0.5 or greater (default is 10.0)
#
# SequenceLength:  1 to 999 (default is 5)
#
# HighlightFreq:   percentage, 0 to 100 (default is 5)

##########################################################################
# The Grid section contains x,y,w,h,a,r where 'a' is AdvanceMode
# and 'r' is ResizeMode (below). Grid ID numbers are 0-based and
# sequential, and no more than 10 are currently supported.
#
# AdvanceMode: 0-Automatic, 1-Manual
#
# ResizeMode:  0-LargestDimension, 1-ByWidth, 2-ByHeight

##########################################################################
# The Content and Highlights sections are simple lists of fully qualified
# image pathnames, or a path ending in a '*' wildcard. UNC pathnames are
# permitted but the application will not prompt for credentials.
# Supported image formats (by file extension):
# .jpg, .jpeg, .png, .bmp

##########################################################################

");

        writer.WriteLine("[Playback]");
        writer.WriteLine($"RandomizeMode: {cmbRandomize.SelectedIndex}");
        writer.WriteLine($"SequenceMode: {cmbSequencing.SelectedIndex}");
        writer.WriteLine($"StaggerMode: {cmbStagger.SelectedIndex}");
        writer.WriteLine($"ShuffleTime: {txtShuffleTime.Text}");
        writer.WriteLine($"SequenceLength: {txtLength.Text}");
        writer.WriteLine($"HighlightFreq: {txtFreq.Text}");

        writer.WriteLine();
        writer.WriteLine($"[Grids]");
        foreach (var g in Grids)
        {
            writer.WriteLine($"{g.Dimensions.X},{g.Dimensions.Y},{g.Dimensions.Width},{g.Dimensions.Height},{(int)g.AdvanceMode},{(int)g.ResizeMode}");
        }

        writer.WriteLine();
        writer.WriteLine($"[Content]");
        foreach (var f in lstContent.Items)
        {
            writer.WriteLine(f as string);
        }

        writer.WriteLine();
        writer.WriteLine($"[Highlights]");
        foreach (var f in lstHighlight.Items)
        {
            writer.WriteLine(f as string);
        }

        writer.Flush();
        writer.Close();
    }
}

