using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slidegrid;

public partial class MainForm
{
    internal class ImageData
    {
        internal string Pathname = string.Empty;
        internal DateTime Timestamp = DateTime.MinValue;
    }

    private List<ImageData> Content;
    private List<ImageData> Highlights;
    private BusyDialog busy;
    private Random random = new();
    private int activeGrid = 0;

    ////////////////////////////////////////////////////////////////////////////////////////////////

    // callbacks

    internal double SlideshowShuffleTime { get => double.Parse(txtShuffleTime.Text); }
    internal PlaybackStaggerMode SlideshowStaggerMode { get => (PlaybackStaggerMode)cmbStagger.SelectedIndex; }

    internal int ActiveGrid 
    { 
        get => activeGrid;  

        set
        {
            if (value > Grids.Count) return;
            activeGrid = value;
            if (activeGrid > -1) Grids[activeGrid].Slide.BringToFront();
        }
    }

    internal void BroadcastKeyUp(object sender, KeyEventArgs e)
    {
        if(ActiveGrid == -1)
        {
            foreach (var g in Grids) g.Slide.BroadcastEligibleKeyUp(e);
        }
        else
        {
            (sender as SlideForm).BroadcastEligibleKeyUp(e);
        }
    }

    internal void EndPlayback()
    {
        foreach (var g in Grids) g.ReleaseSlide();
        Content = null;
        Highlights = null;
        Visible = true;
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////

    private void Play()
    {
        Visible = false;
        busy = new();

        busy.SetLabel("Resolving files...");
        busy.Show();
        Content = new();
        Highlights = new();
        CreateImageData(Content, lstContent);
        CreateImageData(Highlights, lstHighlight);

        PrepareLists();

        busy.Dispose();
        busy = null;

        // this actually begins playback (managed within SlideForm)
        for (int i = 0; i < Grids.Count; i++)
        {
            Grids[i].InitSlide(i, this, Content, Highlights);
        }
        Grids[0].Slide.Focus();
    }

    private void PrepareLists()
    {
        switch ((PlaybackRandomizeMode)cmbRandomize.SelectedIndex)
        {
            case PlaybackRandomizeMode.Shuffle:
                break;

            case PlaybackRandomizeMode.Sequential:
                busy.SetLabel("Sorting...");
                SortImageData(Content);
                SortImageData(Highlights);
                break;

            case PlaybackRandomizeMode.SequentialRandomStart:
                busy.SetLabel("Sorting...");
                SortImageData(Content);
                SortImageData(Highlights);
                break;

            case PlaybackRandomizeMode.ShuffleSequences:
                busy.SetLabel("Sorting...");
                SortImageData(Content);
                SortImageData(Highlights);
                break;
        }

        busy.SetLabel("Sequencing...");
        foreach (var g in Grids) g.PlaybackSequence = GetPlaybackSequence();
    }

    private void SortImageData(List<ImageData> dataList)
    {
        switch((PlaybackSequenceMode)cmbSequencing.SelectedIndex)
        {
            case PlaybackSequenceMode.NotSequenced:
                break;

            case PlaybackSequenceMode.ByFilename:
                dataList = dataList.OrderBy(i => i.Pathname.ToUpperInvariant()).ToList();
                break;

            case PlaybackSequenceMode.ByTimestamp:
                dataList = dataList.OrderBy(i => i.Timestamp).ToList();
                break;
        }
    }

    private List<int> GetPlaybackSequence()
    {
        // Each grid stores its own separate playback sequence which the slide references.
        // The entire playlist series is pre-determined. The PlaybackSequence list of
        // integers identifies the Content index (positive) or Highlights index (negative)
        // to be played. This way, it is possible to manually step forwards and backwards
        // through the entire sequence at any time, and also to toggle between content-only
        // and highlight-only display modes. Because there is no "negative zero" which would
        // make it impossible to reference Highlights[0] in this scheme, int.MinValue is used
        // to represent that special case.

        List<int> PlaybackSequence;

        var seqlen = 1;
        if ((PlaybackRandomizeMode)cmbRandomize.SelectedIndex != PlaybackRandomizeMode.Shuffle)
        {
            _ = int.TryParse(txtLength.Text, out seqlen);
        }

        var contentIDs = Enumerable.Range(0, Content.Count).ToList();
        var highlightIDs = Highlights.Count > 0 ? Enumerable.Range(0, Highlights.Count).ToList() : new List<int>(1);
        PlaybackSequence = new();

        var highlightFreq = int.Parse(txtFreq.Text);

        while (contentIDs.Count > 0)
        {
            List<int> target;
            int multiplier = 1;
            
            // decide if we're adding Highlight index values or Content index values
            if(contentIDs.Count == 0 || (highlightIDs.Count > 0 && random.Next(1,101) <= highlightFreq))
            {
                multiplier = -1;
                target = highlightIDs;
            }
            else
            {
                multiplier = 1;
                target = contentIDs;
            }

            // add indexes to the playlist according to the sequence length 
            var index = random.Next(target.Count);
            var countdown = seqlen;
            while(countdown > 0 && index < target.Count)
            {
                var i = target[index] * multiplier;

                // special case for Higlights[0] since "negative zero" isn't possible
                if (i == 0 && multiplier == -1) i = int.MinValue;

                PlaybackSequence.Add(i);
                target.RemoveAt(index);
                countdown--;
            }

            // highlights should never "run out"
            if(Highlights.Count > 0 && highlightIDs.Count == 0)
            {
                highlightIDs = Enumerable.Range(0, Highlights.Count).ToList();
            }
        }

        return PlaybackSequence;
    }

    private void CreateImageData(List<ImageData> dataList, ListBox pathnameList)
    {
        foreach(var i in pathnameList.Items)
        {
            var pathname = (i as string);
            if(pathname.EndsWith('*'))
            {
                foreach(var file in new DirectoryInfo(pathname.Substring(0, pathname.Length - 1)).EnumerateFiles())
                {
                    if ((file.Attributes & FileAttributes.Hidden) == 0 && (file.Attributes & FileAttributes.System) == 0)
                    {
                        var ext = Path.GetExtension(file.Name);
                        if (".jpg|.jpeg|.png|.bmp".Contains(ext, StringComparison.InvariantCultureIgnoreCase))
                        {
                            dataList.Add(new ImageData
                            {
                                Pathname = file.FullName,
                                Timestamp = file.LastWriteTime
                            });
                        }
                    }
                }
            }
            else
            {
                var file = new FileInfo(pathname);
                if(file.Exists)
                {
                    dataList.Add(new ImageData
                    {
                        Pathname = pathname,
                        Timestamp = file.LastWriteTime
                    });
                }
            }
        }
    }
}
