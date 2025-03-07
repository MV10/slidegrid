
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

    internal void InitializeForm(int gridNumber, MainForm main, Grid grid, List<ImageData> content, List<ImageData> highlights, List<int> playbackSequence)
    {
        Main = main;
        GridDefinition = grid;
        GridNumber = gridNumber;
        Content = content;
        Highlights = highlights;
        PlaybackSequence = playbackSequence;

        Advance = GridDefinition.AdvanceMode;

        picSlide.Location = new Point(0, 0);
        picSlide.Size = Size;
        lblInfo.BringToFront();
        lblInfo.Visible = false;

        // get the first image up
        PlaybackIndex = 0;
        ShowSlide();

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

    private void ShowSlide(int advance = 0)
    {
        PlaybackIndex += advance;
        WrapPlaybackIndex();

        // if advance = 0 (which means "show current"), auto-advance forward to a highlight
        var autoAdvance = (advance == 0 && highlightsOnly) ? 1 : 0;
        while (highlightsOnly && PlaybackSequence[PlaybackIndex] > -1)
        {
            PlaybackIndex += advance + autoAdvance;
            WrapPlaybackIndex();
        }

        if (PlaybackSequence[PlaybackIndex] > -1)
        {
            picSlide.ImageLocation = Content[PlaybackSequence[PlaybackIndex]].Pathname;
        }
        else
        {
            // special case for Higlights[0] since "negative zero" isn't possible
            var i = PlaybackSequence[PlaybackIndex] > int.MinValue ? PlaybackSequence[PlaybackIndex] * -1 : 0;
            picSlide.ImageLocation = Highlights[i].Pathname;
        }

        lblInfo.Visible = showFileInfo;
        lblInfo.Text = picSlide.ImageLocation;
    }

    private void WrapPlaybackIndex()
    {
        if (PlaybackIndex < 0) PlaybackIndex = PlaybackSequence.Count - 1;
        if (PlaybackIndex == PlaybackSequence.Count) PlaybackIndex = 0;
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
        int s = int.Sign(numberOfTextLinesToMove);
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
            ShowSlide();
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
