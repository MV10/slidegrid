
using static slidegrid.MainForm;

namespace slidegrid;

internal class Grid
{
    // Definition (saved to file)
    public Rectangle Dimensions { get; set; } = new();
    public GridAdvanceMode AdvanceMode { get; set; } = GridAdvanceMode.Automatic;
    public GridResizeMode ResizeMode { get; set; } = GridResizeMode.LargestDimension;


    ////////////////////////////////////////////////////////////////////////////////////////////////

    // playback mode (mostly pass-through, SlideForm does all the playback work)

    internal SlideForm Slide;

    public void InitSlide(int gridNumber, MainForm main, List<ImageData> content, List<ImageData> highlights, List<int> playbackSequence)
    {
        Slide = new();
        Slide.StartPosition = FormStartPosition.Manual;
        Slide.Location = new Point(Dimensions.X, Dimensions.Y);
        Slide.Size = new Size(Dimensions.Width, Dimensions.Height);
        Slide.InitializeForm(gridNumber, main, this, content, highlights, playbackSequence);
        Slide.Show();
    }

    public void ReleaseSlide()
    {
        Slide?.Dispose();
        Slide = null;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////

    // binding to MainForm.lstGrid

    public string ListBoxIdentity { get; } = Guid.NewGuid().ToString();
    public string ListBoxDisplay
    {
        get => $"({Dimensions.X},{Dimensions.Y}),({Dimensions.Width}x{Dimensions.Height})";
    }
}
