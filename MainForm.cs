using System.ComponentModel;

namespace slidegrid
{
    public partial class MainForm : Form
    {
        private BindingList<Grid> Grids = new();
        private FilePickerDialog fileDialog = null;
        private double txtShuffleTimeBeforeEdit = 10.0;
        private int txtLengthBeforeEdit = 5;
        private int txtFreqBeforeEdit = 5;

        public MainForm()
        {
            InitializeComponent();
            lstGrid.DataSource = Grids;
            lstGrid.DisplayMember = "ListBoxDisplay";
            lstGrid.ValueMember = "ListBoxIdentity";
            ResetForm();

            if(Program.args.Length == 1 && File.Exists(Program.args[0]))
            {
                if (LoadFile(Program.args[0]))
                {
                    lblPathname.Text = Program.args[0];
                }
                else
                {
                    ResetForm();
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////

        // FilePickerDialog callbacks

        public void FilePickerClosed()
        {
            FilePickerDispose();
        }

        public void SetPreviewPath(string pathname)
        {
            lstContent.SelectedIndex = -1;
            lstHighlight.SelectedIndex = -1;
            picPreview.ImageLocation = pathname;
        }

        private void FilePickerShow(string windowTitle, Action<string> addItemCallback)
        {
            lstGrid.SelectedIndex = -1;
            lstContent.SelectedIndex = -1;
            lstHighlight.SelectedIndex = -1;

            FilePickerDispose();
            fileDialog = new();
            fileDialog.Text = windowTitle;
            fileDialog.AddItemCallback = addItemCallback;
            fileDialog.Show(this);
        }

        private void FilePickerDispose()
        {
            fileDialog?.Dispose();
            fileDialog = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!VerifyDiscard()) return;
            ResetForm();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!VerifyDiscard()) return;

            var startPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var startFilename = string.Empty;
            if (lblPathname.Text.Length > 0)
            {
                startPath = Path.GetDirectoryName(lblPathname.Text);
            }

            ResetForm();

            using var dialog = new OpenFileDialog()
            {
                Filter = "slidegrid files (*.sg)|*.sg|All files (*.*)|*.*",
                FilterIndex = 1,
                FileName = startFilename,
                InitialDirectory = startPath,
                RestoreDirectory = true,
                ShowHelp = false,
                ShowPinnedPlaces = true,
                Title = "Load SlideGrid Config",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (LoadFile(dialog.FileName))
                {
                    lblPathname.Text = dialog.FileName;
                }
                else
                {
                    // LoadFile will show the error message
                    ResetForm();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Grids.Count == 0 || lstContent.Items.Count == 0)
            {
                MessageBox.Show("You must have at least one Grid and one Content entry to save.", "Unable to Save");
                return;
            }

            var startPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var startFilename = string.Empty;
            if (lblPathname.Text.Length > 0)
            {
                startPath = Path.GetDirectoryName(lblPathname.Text);
            }

            using var dialog = new SaveFileDialog()
            {
                Filter = "slidegrid files (*.sg)|*.sg|All files (*.*)|*.*",
                FilterIndex = 1,
                FileName = startFilename,
                InitialDirectory = startPath,
                RestoreDirectory = true,
                ShowHelp = false,
                ShowPinnedPlaces = true,
                Title = "Save SlideGrid Config",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream;
                if ((stream = dialog.OpenFile()) is not null)
                {
                    SaveFile(stream);
                    stream.Close();
                    lblPathname.Text = dialog.FileName;
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (Grids.Count == 0 || lstContent.Items.Count == 0)
            {
                MessageBox.Show("You must define Grid and Content to play a slide deck.", "Error");
                return;
            }

            Play();
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            // TODO external editor button
            MessageBox.Show("TODO");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // TODO help button
            MessageBox.Show("TODO");
        }

        private void btnGithub_Click(object sender, EventArgs e)
        {
            // TODO Github button
            MessageBox.Show("TODO");
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGrid.SelectedIndex == -1)
            {
                cmbAdvance.SelectedIndex = 0;
                cmbResize.SelectedIndex = 0;
                return;
            }
            var g = (Grid)lstGrid.SelectedItem;
            cmbAdvance.SelectedIndex = (int)g.AdvanceMode;
            cmbResize.SelectedIndex = (int)g.ResizeMode;
        }

        private void btnGridAdd_Click(object sender, EventArgs e)
        {
            if (Grids.Count == 10)
            {
                MessageBox.Show("The application only supports 10 grid items at this time.", "Add Grid");
                return;
            }

            using var dialog = new GridDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var g = dialog.Grid;
                g.AdvanceMode = (GridAdvanceMode)cmbAdvance.SelectedIndex;
                g.ResizeMode = (GridResizeMode)cmbResize.SelectedIndex;
                Grids.Add(g);
            }
        }

        private void btnGridRemove_Click(object sender, EventArgs e)
        {
            if (Grids.Count == 0 || lstGrid.SelectedIndex == -1) return;
            Grids.RemoveAt(lstGrid.SelectedIndex);
            cmbAdvance.SelectedIndex = 0;
            cmbResize.SelectedIndex = 0;
        }

        private void btnGridUp_Click(object sender, EventArgs e)
        {
            if (Grids.Count == 0 || lstGrid.SelectedIndex < 1) return;
            Grids.Swap(lstGrid.SelectedIndex, lstGrid.SelectedIndex - 1);
            lstGrid.SelectedIndex--;
        }

        private void btnGridDown_Click(object sender, EventArgs e)
        {
            if (Grids.Count == 0 || lstGrid.SelectedIndex == -1 || lstGrid.SelectedIndex == Grids.Count - 1) return;
            Grids.Swap(lstGrid.SelectedIndex, lstGrid.SelectedIndex + 1);
            lstGrid.SelectedIndex++;
        }

        private void cmbAdvance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Grids.Count == 0 || lstGrid.SelectedIndex == -1) return;
            (lstGrid.SelectedItem as Grid).AdvanceMode = (GridAdvanceMode)cmbAdvance.SelectedIndex;
        }

        private void cmbResize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Grids.Count == 0 || lstGrid.SelectedIndex == -1) return;
            (lstGrid.SelectedItem as Grid).ResizeMode = (GridResizeMode)cmbResize.SelectedIndex;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////

        // Called by FilePickerDialog
        public void AddItemToContentList(string item)
        {
            lstContent.Items.Add(item);
        }

        private void lstContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (string)lstContent.SelectedItem;

            if (item is null) lblFullPathname.Text = string.Empty;
            lblFullPathname.Text = item;

            if (item is null || item.IsWildcardPath())
            {
                picPreview.ImageLocation = null;
                return;
            }
            picPreview.ImageLocation = item;
        }

        private void btnContentAdd_Click(object sender, EventArgs e)
        {
            FilePickerShow("Add Content", AddItemToContentList);
        }

        private void btnContentRemove_Click(object sender, EventArgs e)
        {
            if (lstContent.SelectedIndex == -1) return;
            lstContent.Items.RemoveAt(lstContent.SelectedIndex);
        }

        private void btnContentUp_Click(object sender, EventArgs e)
        {
            if (lstContent.Items.Count == 0 || lstContent.SelectedIndex < 1) return;
            lstContent.Swap(lstContent.SelectedIndex, lstContent.SelectedIndex - 1);
            lstContent.SelectedIndex--;
        }

        private void btnContentDown_Click(object sender, EventArgs e)
        {
            if (lstContent.Items.Count == 0 || lstContent.SelectedIndex == -1 || lstContent.SelectedIndex == lstContent.Items.Count - 1) return;
            lstContent.Swap(lstContent.SelectedIndex, lstContent.SelectedIndex + 1);
            lstContent.SelectedIndex++;
        }

        private void btnContentClear_Click(object sender, EventArgs e)
        {
            lstContent.Items.Clear();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////

        // Called by FilePickerDialog
        public void AddItemToHighlightsList(string item)
        {
            lstHighlight.Items.Add(item);
        }

        private void lstHighlight_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (string)lstHighlight.SelectedItem;

            if (item is null) lblFullPathname.Text = string.Empty;
            lblFullPathname.Text = item;

            if (item is null || item.IsWildcardPath())
            {
                picPreview.ImageLocation = null;
                return;
            }
            picPreview.ImageLocation = item;
        }

        private void btnHilightAdd_Click(object sender, EventArgs e)
        {
            FilePickerShow("Add Highlights", AddItemToHighlightsList);
        }

        private void btnHilightRemove_Click(object sender, EventArgs e)
        {
            if (lstHighlight.SelectedIndex == -1) return;
            lstHighlight.Items.RemoveAt(lstHighlight.SelectedIndex);
        }

        private void btnHilightUp_Click(object sender, EventArgs e)
        {
            if (lstHighlight.Items.Count == 0 || lstHighlight.SelectedIndex < 1) return;
            lstHighlight.Swap(lstHighlight.SelectedIndex, lstHighlight.SelectedIndex - 1);
            lstHighlight.SelectedIndex--;
        }

        private void btnHilightDown_Click(object sender, EventArgs e)
        {
            if (lstHighlight.Items.Count == 0 || lstHighlight.SelectedIndex == -1 || lstHighlight.SelectedIndex == lstHighlight.Items.Count - 1) return;
            lstHighlight.Swap(lstHighlight.SelectedIndex, lstHighlight.SelectedIndex + 1);
            lstHighlight.SelectedIndex++;
        }

        private void btnHilightClear_Click(object sender, EventArgs e)
        {
            lstHighlight.Items.Clear();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtShuffleTime_Enter(object sender, EventArgs e)
        {
            _ = double.TryParse(txtShuffleTime.Text, out txtShuffleTimeBeforeEdit);
        }

        private void txtShuffleTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtShuffleTime.ValidateKeyPressDouble(e);
        }

        private void txtShuffleTime_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(txtShuffleTime.Text, out var i) || i <= 0.0)
            {
                txtShuffleTime.Text = txtShuffleTimeBeforeEdit.ToString();
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtLength_Enter(object sender, EventArgs e)
        {
            _ = int.TryParse(txtLength.Text, out txtLengthBeforeEdit);
        }

        private void txtLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtLength.ValidateKeyPressInt(e);
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtLength.Text, out var i) || i < 2)
            {
                txtLength.Text = txtLengthBeforeEdit.ToString();
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtFreq_Enter(object sender, EventArgs e)
        {
            _ = int.TryParse(txtFreq.Text, out txtFreqBeforeEdit);
        }

        private void txtFreq_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtFreq.ValidateKeyPressInt(e);
        }

        private void txtFreq_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtFreq.Text, out var i) || i < 0 || i > 100)
            {
                txtFreq.Text = txtFreqBeforeEdit.ToString();
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////

        private bool VerifyDiscard()
        {
            if (Grids.Count > 0 || lstContent.Items.Count > 0 || lstHighlight.Items.Count > 0)
            {
                var discard = MessageBox.Show("Discard current settings?", "New", MessageBoxButtons.OKCancel);
                if (discard == DialogResult.Cancel) return false;
            }
            return true;
        }

        private void ResetForm()
        {
            lblPathname.Text = string.Empty;

            Grids.Clear();
            lstContent.Items.Clear();
            lstHighlight.Items.Clear();
            picPreview.ImageLocation = null;

            foreach (Control c in Controls)
            {
                if (c.GetType().ToString().Equals("System.Windows.Forms.ComboBox"))
                {
                    ((ComboBox)c).SelectedIndex = 0;
                }

            }

            txtShuffleTimeBeforeEdit = 10.0;
            txtShuffleTime.Text = "10.0";

            txtLengthBeforeEdit = 5;
            txtLength.Text = "5";

            txtFreqBeforeEdit = 5;
            txtFreq.Text = "5";
        }
    }
}
