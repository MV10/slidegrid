
namespace slidegrid;

// Necessary because PictureBox.Image.Clone won't correctly update the
// ImageLocation property, and setting ImageLocation would re-load the
// same image. Subclassing a control without a separate project doesn't
// work, apparently, and I don't want that complexity. Finally, extension
// properties are mired in the MS Language Design Team's navel-gazing...

public class CachingPictureBox
{
    public PictureBox PicBox { get; set; }
    public string Pathname { get; set; }

    public void Load(string url)
    {
        Pathname = url;
        PicBox.WaitOnLoad = false;
        PicBox.LoadAsync(url);
    }

    public void CloneFrom(CachingPictureBox targetSlide, bool refresh = false)
    {
        Pathname = targetSlide.Pathname;
        PicBox.Image = (Image)targetSlide.PicBox.Image.Clone();
        if (refresh) PicBox.Refresh();
    }
}
