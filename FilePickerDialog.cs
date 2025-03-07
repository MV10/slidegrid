using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slidegrid;
public partial class FilePickerDialog : Form
{
    public FilePickerDialog()
    {
        InitializeComponent();

        trvLocation.BeginUpdate();
        foreach(var drive in DriveInfo.GetDrives())
        {
            var name = drive.Name.Replace("\\", string.Empty);
            trvLocation.Nodes.Add(name);
        }
        trvLocation.EndUpdate();
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////

    // Set by Owner before form is shown
    public Action<string> AddItemCallback { get; set; }

    ////////////////////////////////////////////////////////////////////////////////////////////////

    private void FilePickerDialog_FormClosed(object sender, FormClosedEventArgs e)
    {
        AddItemCallback = null;
        (Owner as MainForm).SetPreviewPath(null);
        (Owner as MainForm).FilePickerClosed();
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////

    private void trvLocation_AfterSelect(object sender, TreeViewEventArgs e)
    {
        var path = trvLocation.SelectedNode.FullPath + "\\";

        if (trvLocation.SelectedNode.Nodes.Count == 0)
        {
            trvLocation.BeginUpdate();
            foreach (var dir in new DirectoryInfo(path).EnumerateDirectories())
            {
                if((dir.Attributes & FileAttributes.Hidden) == 0 && (dir.Attributes & FileAttributes.System) == 0)
                {
                    trvLocation.SelectedNode.Nodes.Add(dir.Name);
                }
            }
            trvLocation.EndUpdate();
        }

        lstFiles.Items.Clear();
        var files = new List<FileInfo>();
        foreach (var file in new DirectoryInfo(path).EnumerateFiles())
        {
            if ((file.Attributes & FileAttributes.Hidden) == 0 && (file.Attributes & FileAttributes.System) == 0)
            {
                var ext = Path.GetExtension(file.Name);
                if(".jpg|.jpeg|.png|.bmp".Contains(ext, StringComparison.InvariantCultureIgnoreCase))
                {
                    files.Add(file);
                }
            }
        }
        foreach (var file in files)
        {
            lstFiles.Items.Add($"{file.LastWriteTime:yyyy-MM-dd hh:mm:ss tt}  {file.Name}");
        }
    }

    private void btnAddDirectory_Click(object sender, EventArgs e)
    {
        var dir = GetCurrentDirectory();
        if (dir is null) return;
        AddItemCallback($"{dir}*");
    }

    private void btnNetwork_Click(object sender, EventArgs e)
    {
        // TODO prompt for network share
        MessageBox.Show("TODO");
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////

    private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        (Owner as MainForm).SetPreviewPath(GetFullPathname());
    }

    private void btnSort_Click(object sender, EventArgs e)
    {
        // TODO toggle sort mode
        MessageBox.Show("TODO");
    }

    private void btnAddFile_Click(object sender, EventArgs e)
    {
        if (lstFiles.Items.Count == 0 || lstFiles.SelectedItems.Count == 0) return;
        foreach(var item in lstFiles.SelectedItems)
        {
            AddItemCallback($"{GetCurrentDirectory()}{GetListFilename(item as string)}");
        }
    }

    private void btnAddAll_Click(object sender, EventArgs e)
    {
        if (lstFiles.Items.Count == 0) return;
        for(int i = 0; i < lstFiles.Items.Count; i++)
        {
            AddItemCallback(GetFullPathname(i));
        }
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////

    private string GetFullPathname(int filenameIndex = -1)
    {
        if (trvLocation.SelectedNode is null) return null;
        return $"{GetCurrentDirectory()}{GetListFilename(filenameIndex)}";
    }

    private string GetCurrentDirectory()
    {
        if (trvLocation.SelectedNode is null) return null;
        return $"{trvLocation.SelectedNode.FullPath}\\";
    }

    private string GetListFilename(int filenameIndex = -1)
    {
        int i = lstFiles.SelectedIndex;
        if(filenameIndex > -1 && filenameIndex < lstFiles.Items.Count)
        {
            i = filenameIndex;
        }
        else
        {
            if (i == -1) return null;
        }
        return GetListFilename(lstFiles.Items[i] as string);
    }

    private string GetListFilename(string itemText)
    {
        return itemText.Substring(24);
    }
}
