
using static slidegrid.MainForm;

namespace slidegrid;

public partial class SlideForm : Form
{
    public Action<KeyPressEventArgs> MainFormKeypressCallback;

    public SlideForm()
    {
        InitializeComponent();

        this.MouseWheel += SlideForm_MouseWheel;
    }

    private MainForm Main;
    private Grid GridDefinition;
    private int GridNumber;
    List<ImageData> Content;
    List<ImageData> Highlights;
    List<int> PlaybackSequence;
    private Random random = new();
    private GridAdvanceMode Advance;
    private bool highlightsOnly = false;
    private bool showFileInfo;
    
    private int PlaybackIndex;
    private CachingPictureBox Slide = new();
    private CachingPictureBox SlidePrev = new();
    private CachingPictureBox SlideNext = new();

    internal void InitializeForm(int gridNumber, MainForm main, Grid grid, List<ImageData> content, List<ImageData> highlights, List<int> playbackSequence)
    {
        Main = main;
        GridDefinition = grid;
        GridNumber = gridNumber;
        Content = content;
        Highlights = highlights;
        PlaybackSequence = playbackSequence;

        Advance = GridDefinition.AdvanceMode;

        var origin = new Point(0, 0);
        picSlide.Location = origin;
        picPrev.Location = origin;
        picNext.Location = origin;
        picSlide.Size = Size;
        picPrev.Size = Size;
        picNext.Size = Size;
        picPrev.Visible = false;
        picNext.Visible = false;

        lblInfo.BringToFront();
        lblInfo.Visible = false;

        // load the initial images
        Slide.PicBox = picSlide;
        SlidePrev.PicBox = picPrev;
        SlideNext.PicBox = picNext;
        PlaybackIndex = 0;
        ReloadAll();

        timer.Interval = (int)(Main.SlideshowShuffleTime * 1000.0);
        if (Main.SlideshowStaggerMode == PlaybackStaggerMode.Staggered)
        {
            timer.Interval += random.Next(1000) - 500;
        }
        if (Advance == GridAdvanceMode.Automatic)
        {
            timer.Enabled = true;
        }
    }

    private void ShowSlide(int advance = 0, bool changeHighlightsMode = false)
    {
        // advance should be 0 when changing highlights mode, but index can
        // still change if the current index is not already a highlight image

        AdvanceIndex(ref PlaybackIndex, advance);

        if (!changeHighlightsMode)
        {
            if (advance == +1) SlidePrev.CloneFrom(Slide);
            if (advance == -1) SlideNext.CloneFrom(Slide);

            if (advance == +1) Slide.CloneFrom(SlideNext, refresh: true);
            if (advance == -1) Slide.CloneFrom(SlidePrev, refresh: true);

            if (advance != 0)
            {
                var index = PlaybackIndex;
                AdvanceIndex(ref index, advance);
                if (advance == +1) SlideNext.Load(ResolvePathname(index));
                if (advance == -1) SlidePrev.Load(ResolvePathname(index));
            }
        }
        else
        {
            // reload all three when changing highlights mode
            ReloadAll();
        }

        lblInfo.Visible = showFileInfo;
        lblInfo.Text = Slide.Pathname;
    }

    private void AdvanceIndex(ref int index, int advance)
    {
        // when highlights mode is active, if the current index is not already a highlight, the
        // index can change even when advance is 0 if highlights exist (index will skip forward)

        index += advance;
        WrapIndex(ref index);

        // if advance = 0 (which means "show current"), auto-advance forward to a highlight
        while (highlightsOnly && PlaybackSequence[index] > -1)
        {
            index += advance;
            WrapIndex(ref index);
        }
    }

    private void WrapIndex(ref int index)
    {
        if (index < 0) index = PlaybackSequence.Count - 1;
        if (index == PlaybackSequence.Count) index = 0;
    }

    private string ResolvePathname(int index)
    {
        if (PlaybackSequence[index] > -1)
        {
            return Content[PlaybackSequence[index]].Pathname;
        }

        // special case for Higlights[0] since "negative zero" isn't possible
        var i = PlaybackSequence[index] > int.MinValue ? PlaybackSequence[index] * -1 : 0;
        return Highlights[i].Pathname;
    }

    private void ReloadAll()
    {
        Slide.Load(ResolvePathname(PlaybackIndex));

        var index = PlaybackIndex;
        AdvanceIndex(ref index, -1);
        SlidePrev.Load(ResolvePathname(index));

        index = PlaybackIndex;
        AdvanceIndex(ref index, +1);
        SlideNext.Load(ResolvePathname(index));
    }

    private void ResetTimer()
    {
        timer.Enabled = false;
        if (Advance == GridAdvanceMode.Automatic) timer.Enabled = true;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        ShowSlide(+1);
    }

    private void picSlide_MouseClick(object sender, MouseEventArgs e)
    {
        Main.ActiveGrid = GridNumber;
        if (e.Button == MouseButtons.Left) ShowSlide(-1);
        if (e.Button == MouseButtons.Right) ShowSlide(+1);
        ResetTimer();
    }

    private void SlideForm_MouseWheel(object sender, MouseEventArgs e)
    {
        // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.control.mousewheel?view=windowsdesktop-9.0#remarks
        int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
        int s = int.Sign(numberOfTextLinesToMove) * -1;
        if (s == 0) return;
        ShowSlide(s);
        ResetTimer();
    }

    private void SlideForm_KeyUp(object sender, KeyEventArgs e)
    {
        // don't process anything if control, alt, or shift keys are pressed
        if (e.Shift || e.Control || e.Alt) return;

        // ESC end show; represented in Unicode, this is C#12, only C#13 has '\e' support
        if (e.KeyCode == Keys.Escape)
        {
            Main.EndPlayback();
            return;
        }

        // 0-9 change active grid
        if (e.KeyValue >= '0' && e.KeyValue <= '9')
        {
            Main.ActiveGrid = int.Parse(e.KeyValue.ToString());
            return;
        }

        // ~ all grids active (broadcast mode)
        if (e.KeyCode == Keys.Oemtilde)
        {
            Main.ActiveGrid = -1;
            return;
        }

        // everything else is potentially a broadcast keystroke
        Main.BroadcastKeyUp(sender, e);
    }

    internal void BroadcastEligibleKeyUp(KeyEventArgs e)
    {
        // <- previous
        if (e.KeyCode == Keys.Left)
        {
            ResetTimer();
            ShowSlide(-1);
            return;
        }

        // -> next
        if (e.KeyCode == Keys.Right)
        {
            ResetTimer();
            ShowSlide(+1);
            return;
        }

        // I identify grids
        if (e.KeyCode == Keys.I)
        {
            lblInfo.Visible = true;
            lblInfo.Text = GridNumber.ToString();
            return;
        }

        // \ toggle file info
        if (e.KeyCode == Keys.OemPipe)
        {
            showFileInfo = !showFileInfo;
            ShowSlide();
            return;
        }

        // ENTER toggle highlights only
        if (e.KeyCode == Keys.Enter)
        {
            if (Highlights.Count == 0) return;
            highlightsOnly = !highlightsOnly;
            ShowSlide(changeHighlightsMode: true);
            return;
        }

        // SPC auto/manual toggle
        if (e.KeyCode == Keys.Space)
        {
            Advance = (Advance == GridAdvanceMode.Manual) ? GridAdvanceMode.Automatic : GridAdvanceMode.Manual;
            ResetTimer();
            return;
        }
    }
}
