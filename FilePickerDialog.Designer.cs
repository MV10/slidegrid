namespace slidegrid;

partial class FilePickerDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        trvLocation = new TreeView();
        label2 = new Label();
        lstFiles = new ListBox();
        btnAddDirectory = new Button();
        btnAddFile = new Button();
        btnAddAll = new Button();
        btnNetwork = new Button();
        btnSort = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(160, 15);
        label1.TabIndex = 0;
        label1.Text = "Directory (select to populate)";
        // 
        // trvLocation
        // 
        trvLocation.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        trvLocation.Location = new Point(12, 27);
        trvLocation.Name = "trvLocation";
        trvLocation.Size = new Size(232, 342);
        trvLocation.TabIndex = 1;
        trvLocation.AfterSelect += trvLocation_AfterSelect;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(257, 9);
        label2.Name = "label2";
        label2.Size = new Size(30, 15);
        label2.TabIndex = 2;
        label2.Text = "Files";
        // 
        // lstFiles
        // 
        lstFiles.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lstFiles.FormattingEnabled = true;
        lstFiles.ItemHeight = 13;
        lstFiles.Location = new Point(257, 27);
        lstFiles.Name = "lstFiles";
        lstFiles.SelectionMode = SelectionMode.MultiExtended;
        lstFiles.Size = new Size(458, 342);
        lstFiles.TabIndex = 3;
        lstFiles.SelectedIndexChanged += lstFiles_SelectedIndexChanged;
        // 
        // btnAddDirectory
        // 
        btnAddDirectory.Location = new Point(12, 382);
        btnAddDirectory.Name = "btnAddDirectory";
        btnAddDirectory.Size = new Size(75, 23);
        btnAddDirectory.TabIndex = 4;
        btnAddDirectory.Text = "Add *";
        btnAddDirectory.UseVisualStyleBackColor = true;
        btnAddDirectory.Click += btnAddDirectory_Click;
        // 
        // btnAddFile
        // 
        btnAddFile.Location = new Point(257, 382);
        btnAddFile.Name = "btnAddFile";
        btnAddFile.Size = new Size(75, 23);
        btnAddFile.TabIndex = 5;
        btnAddFile.Text = "Add file(s)";
        btnAddFile.UseVisualStyleBackColor = true;
        btnAddFile.Click += btnAddFile_Click;
        // 
        // btnAddAll
        // 
        btnAddAll.Location = new Point(338, 382);
        btnAddAll.Name = "btnAddAll";
        btnAddAll.Size = new Size(75, 23);
        btnAddAll.TabIndex = 6;
        btnAddAll.Text = "Add all";
        btnAddAll.UseVisualStyleBackColor = true;
        btnAddAll.Click += btnAddAll_Click;
        // 
        // btnNetwork
        // 
        btnNetwork.Location = new Point(93, 382);
        btnNetwork.Name = "btnNetwork";
        btnNetwork.Size = new Size(75, 23);
        btnNetwork.TabIndex = 7;
        btnNetwork.Text = "Network...";
        btnNetwork.UseVisualStyleBackColor = true;
        btnNetwork.Click += btnNetwork_Click;
        // 
        // btnSort
        // 
        btnSort.Location = new Point(640, 379);
        btnSort.Name = "btnSort";
        btnSort.Size = new Size(75, 23);
        btnSort.TabIndex = 8;
        btnSort.Text = "Toggle sort";
        btnSort.UseVisualStyleBackColor = true;
        btnSort.Click += btnSort_Click;
        // 
        // FilePickerDialog
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(726, 414);
        Controls.Add(btnSort);
        Controls.Add(btnNetwork);
        Controls.Add(btnAddAll);
        Controls.Add(btnAddFile);
        Controls.Add(btnAddDirectory);
        Controls.Add(lstFiles);
        Controls.Add(label2);
        Controls.Add(trvLocation);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FilePickerDialog";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Add Content";
        FormClosed += FilePickerDialog_FormClosed;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TreeView trvLocation;
    private Label label2;
    private ListBox lstFiles;
    private Button btnAddDirectory;
    private Button btnAddFile;
    private Button btnAddAll;
    private Button btnNetwork;
    private Button btnSort;
}