namespace slidegrid
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnPlay = new Button();
            label1 = new Label();
            lblPathname = new Label();
            btnNew = new Button();
            btnLoad = new Button();
            btnSave = new Button();
            btnEditor = new Button();
            label2 = new Label();
            lstGrid = new ListBox();
            btnGridAdd = new Button();
            btnGridRemove = new Button();
            btnGridUp = new Button();
            btnGridDown = new Button();
            btnContentDown = new Button();
            btnContentUp = new Button();
            btnContentRemove = new Button();
            btnContentAdd = new Button();
            lstContent = new ListBox();
            lblContent = new Label();
            btnHilightDown = new Button();
            btnHilightUp = new Button();
            btnHilightRemove = new Button();
            btnHilightAdd = new Button();
            lstHighlight = new ListBox();
            lblHilight = new Label();
            picPreview = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            cmbAdvance = new ComboBox();
            cmbResize = new ComboBox();
            label5 = new Label();
            cmbRandomize = new ComboBox();
            cmbSequencing = new ComboBox();
            label6 = new Label();
            txtShuffleTime = new TextBox();
            cmbStagger = new ComboBox();
            btnContentClear = new Button();
            btnHilightClear = new Button();
            btnGithub = new Button();
            btnHelp = new Button();
            label7 = new Label();
            OpenSlidesDialog = new OpenFileDialog();
            SaveSlidesDialog = new SaveFileDialog();
            label8 = new Label();
            txtLength = new TextBox();
            label9 = new Label();
            txtFreq = new TextBox();
            label10 = new Label();
            lblFullPathname = new Label();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(495, 34);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "Playlist";
            // 
            // lblPathname
            // 
            lblPathname.BorderStyle = BorderStyle.FixedSingle;
            lblPathname.Location = new Point(12, 24);
            lblPathname.Name = "lblPathname";
            lblPathname.Size = new Size(415, 23);
            lblPathname.TabIndex = 2;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(12, 50);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 3;
            btnNew.Text = "New...";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(93, 50);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Load...";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(174, 50);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnEditor
            // 
            btnEditor.Location = new Point(352, 50);
            btnEditor.Name = "btnEditor";
            btnEditor.Size = new Size(75, 23);
            btnEditor.TabIndex = 6;
            btnEditor.Text = "Editor...";
            btnEditor.UseVisualStyleBackColor = true;
            btnEditor.Click += btnEditor_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 97);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 7;
            label2.Text = "Grid";
            // 
            // lstGrid
            // 
            lstGrid.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstGrid.FormattingEnabled = true;
            lstGrid.ItemHeight = 14;
            lstGrid.Location = new Point(12, 115);
            lstGrid.Name = "lstGrid";
            lstGrid.Size = new Size(190, 130);
            lstGrid.TabIndex = 8;
            lstGrid.SelectedIndexChanged += lstGrid_SelectedIndexChanged;
            // 
            // btnGridAdd
            // 
            btnGridAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGridAdd.Location = new Point(12, 251);
            btnGridAdd.Name = "btnGridAdd";
            btnGridAdd.Size = new Size(43, 52);
            btnGridAdd.TabIndex = 9;
            btnGridAdd.Text = "+";
            btnGridAdd.UseVisualStyleBackColor = true;
            btnGridAdd.Click += btnGridAdd_Click;
            // 
            // btnGridRemove
            // 
            btnGridRemove.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGridRemove.Location = new Point(61, 251);
            btnGridRemove.Name = "btnGridRemove";
            btnGridRemove.Size = new Size(43, 52);
            btnGridRemove.TabIndex = 10;
            btnGridRemove.Text = "×";
            btnGridRemove.UseVisualStyleBackColor = true;
            btnGridRemove.Click += btnGridRemove_Click;
            // 
            // btnGridUp
            // 
            btnGridUp.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGridUp.Location = new Point(110, 251);
            btnGridUp.Name = "btnGridUp";
            btnGridUp.Size = new Size(43, 52);
            btnGridUp.TabIndex = 11;
            btnGridUp.Text = "↑";
            btnGridUp.UseVisualStyleBackColor = true;
            btnGridUp.Click += btnGridUp_Click;
            // 
            // btnGridDown
            // 
            btnGridDown.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGridDown.Location = new Point(159, 251);
            btnGridDown.Name = "btnGridDown";
            btnGridDown.Size = new Size(43, 52);
            btnGridDown.TabIndex = 12;
            btnGridDown.Text = "↓";
            btnGridDown.UseVisualStyleBackColor = true;
            btnGridDown.Click += btnGridDown_Click;
            // 
            // btnContentDown
            // 
            btnContentDown.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContentDown.Location = new Point(368, 251);
            btnContentDown.Name = "btnContentDown";
            btnContentDown.Size = new Size(43, 52);
            btnContentDown.TabIndex = 18;
            btnContentDown.Text = "↓";
            btnContentDown.UseVisualStyleBackColor = true;
            btnContentDown.Click += btnContentDown_Click;
            // 
            // btnContentUp
            // 
            btnContentUp.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContentUp.Location = new Point(319, 251);
            btnContentUp.Name = "btnContentUp";
            btnContentUp.Size = new Size(43, 52);
            btnContentUp.TabIndex = 17;
            btnContentUp.Text = "↑";
            btnContentUp.UseVisualStyleBackColor = true;
            btnContentUp.Click += btnContentUp_Click;
            // 
            // btnContentRemove
            // 
            btnContentRemove.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContentRemove.Location = new Point(270, 251);
            btnContentRemove.Name = "btnContentRemove";
            btnContentRemove.Size = new Size(43, 52);
            btnContentRemove.TabIndex = 16;
            btnContentRemove.Text = "×";
            btnContentRemove.UseVisualStyleBackColor = true;
            btnContentRemove.Click += btnContentRemove_Click;
            // 
            // btnContentAdd
            // 
            btnContentAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnContentAdd.Location = new Point(221, 251);
            btnContentAdd.Name = "btnContentAdd";
            btnContentAdd.Size = new Size(43, 52);
            btnContentAdd.TabIndex = 15;
            btnContentAdd.Text = "+";
            btnContentAdd.UseVisualStyleBackColor = true;
            btnContentAdd.Click += btnContentAdd_Click;
            // 
            // lstContent
            // 
            lstContent.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstContent.FormattingEnabled = true;
            lstContent.ItemHeight = 14;
            lstContent.Location = new Point(221, 115);
            lstContent.Name = "lstContent";
            lstContent.Size = new Size(190, 130);
            lstContent.TabIndex = 14;
            lstContent.SelectedIndexChanged += lstContent_SelectedIndexChanged;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(221, 97);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(50, 15);
            lblContent.TabIndex = 13;
            lblContent.Text = "Content";
            // 
            // btnHilightDown
            // 
            btnHilightDown.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHilightDown.Location = new Point(576, 251);
            btnHilightDown.Name = "btnHilightDown";
            btnHilightDown.Size = new Size(43, 52);
            btnHilightDown.TabIndex = 24;
            btnHilightDown.Text = "↓";
            btnHilightDown.UseVisualStyleBackColor = true;
            btnHilightDown.Click += btnHilightDown_Click;
            // 
            // btnHilightUp
            // 
            btnHilightUp.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHilightUp.Location = new Point(527, 251);
            btnHilightUp.Name = "btnHilightUp";
            btnHilightUp.Size = new Size(43, 52);
            btnHilightUp.TabIndex = 23;
            btnHilightUp.Text = "↑";
            btnHilightUp.UseVisualStyleBackColor = true;
            btnHilightUp.Click += btnHilightUp_Click;
            // 
            // btnHilightRemove
            // 
            btnHilightRemove.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHilightRemove.Location = new Point(478, 251);
            btnHilightRemove.Name = "btnHilightRemove";
            btnHilightRemove.Size = new Size(43, 52);
            btnHilightRemove.TabIndex = 22;
            btnHilightRemove.Text = "×";
            btnHilightRemove.UseVisualStyleBackColor = true;
            btnHilightRemove.Click += btnHilightRemove_Click;
            // 
            // btnHilightAdd
            // 
            btnHilightAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHilightAdd.Location = new Point(429, 251);
            btnHilightAdd.Name = "btnHilightAdd";
            btnHilightAdd.Size = new Size(43, 52);
            btnHilightAdd.TabIndex = 21;
            btnHilightAdd.Text = "+";
            btnHilightAdd.UseVisualStyleBackColor = true;
            btnHilightAdd.Click += btnHilightAdd_Click;
            // 
            // lstHighlight
            // 
            lstHighlight.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstHighlight.FormattingEnabled = true;
            lstHighlight.ItemHeight = 14;
            lstHighlight.Location = new Point(429, 115);
            lstHighlight.Name = "lstHighlight";
            lstHighlight.Size = new Size(190, 130);
            lstHighlight.TabIndex = 20;
            lstHighlight.SelectedIndexChanged += lstHighlight_SelectedIndexChanged;
            // 
            // lblHilight
            // 
            lblHilight.AutoSize = true;
            lblHilight.Location = new Point(429, 97);
            lblHilight.Name = "lblHilight";
            lblHilight.Size = new Size(55, 15);
            lblHilight.TabIndex = 19;
            lblHilight.Text = "Higlights";
            // 
            // picPreview
            // 
            picPreview.Location = new Point(640, 115);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(148, 130);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 25;
            picPreview.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(640, 97);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 26;
            label3.Text = "Preview";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 317);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 27;
            label4.Text = "Grid settings";
            // 
            // cmbAdvance
            // 
            cmbAdvance.FormattingEnabled = true;
            cmbAdvance.Items.AddRange(new object[] { "Automatic advance", "Manual advance" });
            cmbAdvance.Location = new Point(12, 335);
            cmbAdvance.Name = "cmbAdvance";
            cmbAdvance.Size = new Size(190, 23);
            cmbAdvance.TabIndex = 28;
            cmbAdvance.SelectedIndexChanged += cmbAdvance_SelectedIndexChanged;
            // 
            // cmbResize
            // 
            cmbResize.FormattingEnabled = true;
            cmbResize.Items.AddRange(new object[] { "Resize by largest dimension", "Resize by width", "Resize by height" });
            cmbResize.Location = new Point(12, 364);
            cmbResize.Name = "cmbResize";
            cmbResize.Size = new Size(190, 23);
            cmbResize.TabIndex = 29;
            cmbResize.SelectedIndexChanged += cmbResize_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(221, 317);
            label5.Name = "label5";
            label5.Size = new Size(98, 15);
            label5.TabIndex = 30;
            label5.Text = "Playback settings";
            // 
            // cmbRandomize
            // 
            cmbRandomize.FormattingEnabled = true;
            cmbRandomize.Items.AddRange(new object[] { "Shuffle", "Sequential", "Sequential, random start", "Shuffle sequences" });
            cmbRandomize.Location = new Point(221, 335);
            cmbRandomize.Name = "cmbRandomize";
            cmbRandomize.Size = new Size(190, 23);
            cmbRandomize.TabIndex = 31;
            // 
            // cmbSequencing
            // 
            cmbSequencing.FormattingEnabled = true;
            cmbSequencing.Items.AddRange(new object[] { "(not sequenced)", "Sequence by filename", "Sequence by timestamp" });
            cmbSequencing.Location = new Point(221, 364);
            cmbSequencing.Name = "cmbSequencing";
            cmbSequencing.Size = new Size(190, 23);
            cmbSequencing.TabIndex = 32;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(221, 399);
            label6.Name = "label6";
            label6.Size = new Size(128, 15);
            label6.TabIndex = 33;
            label6.Text = "Shuffle time (seconds):";
            // 
            // txtShuffleTime
            // 
            txtShuffleTime.Location = new Point(368, 393);
            txtShuffleTime.MaxLength = 5;
            txtShuffleTime.Name = "txtShuffleTime";
            txtShuffleTime.Size = new Size(43, 23);
            txtShuffleTime.TabIndex = 34;
            txtShuffleTime.Text = "10.0";
            txtShuffleTime.TextChanged += txtShuffleTime_TextChanged;
            txtShuffleTime.Enter += txtShuffleTime_Enter;
            txtShuffleTime.KeyPress += txtShuffleTime_KeyPress;
            // 
            // cmbStagger
            // 
            cmbStagger.FormattingEnabled = true;
            cmbStagger.Items.AddRange(new object[] { "(not shuffled)", "Staggered shuffle", "Syncrhonized shuffle" });
            cmbStagger.Location = new Point(221, 425);
            cmbStagger.Name = "cmbStagger";
            cmbStagger.Size = new Size(190, 23);
            cmbStagger.TabIndex = 35;
            // 
            // btnContentClear
            // 
            btnContentClear.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnContentClear.Location = new Point(365, 89);
            btnContentClear.Name = "btnContentClear";
            btnContentClear.Size = new Size(46, 23);
            btnContentClear.TabIndex = 37;
            btnContentClear.Text = "clear";
            btnContentClear.UseVisualStyleBackColor = true;
            btnContentClear.Click += btnContentClear_Click;
            // 
            // btnHilightClear
            // 
            btnHilightClear.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHilightClear.Location = new Point(573, 89);
            btnHilightClear.Name = "btnHilightClear";
            btnHilightClear.Size = new Size(46, 23);
            btnHilightClear.TabIndex = 38;
            btnHilightClear.Text = "clear";
            btnHilightClear.UseVisualStyleBackColor = true;
            btnHilightClear.Click += btnHilightClear_Click;
            // 
            // btnGithub
            // 
            btnGithub.Location = new Point(713, 34);
            btnGithub.Name = "btnGithub";
            btnGithub.Size = new Size(75, 23);
            btnGithub.TabIndex = 39;
            btnGithub.Text = "Github...";
            btnGithub.UseVisualStyleBackColor = true;
            btnGithub.Click += btnGithub_Click;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(632, 34);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(75, 23);
            btnHelp.TabIndex = 40;
            btnHelp.Text = "Help...";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // label7
            // 
            label7.Font = new Font("Consolas", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(598, 319);
            label7.Name = "label7";
            label7.Size = new Size(190, 131);
            label7.TabIndex = 41;
            label7.Text = resources.GetString("label7.Text");
            // 
            // OpenSlidesDialog
            // 
            OpenSlidesDialog.AddToRecent = false;
            OpenSlidesDialog.FileName = "OpenSlidesDialog";
            OpenSlidesDialog.ShowReadOnly = true;
            // 
            // SaveSlidesDialog
            // 
            SaveSlidesDialog.AddToRecent = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(429, 343);
            label8.Name = "label8";
            label8.Size = new Size(144, 15);
            label8.TabIndex = 42;
            label8.Text = "Max sequence length (+2)";
            // 
            // txtLength
            // 
            txtLength.Location = new Point(429, 364);
            txtLength.MaxLength = 3;
            txtLength.Name = "txtLength";
            txtLength.Size = new Size(43, 23);
            txtLength.TabIndex = 43;
            txtLength.Text = "5";
            txtLength.TextChanged += txtLength_TextChanged;
            txtLength.Enter += txtLength_Enter;
            txtLength.KeyPress += txtLength_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(429, 404);
            label9.Name = "label9";
            label9.Size = new Size(94, 15);
            label9.TabIndex = 44;
            label9.Text = "Highlight freq %";
            // 
            // txtFreq
            // 
            txtFreq.Location = new Point(429, 425);
            txtFreq.MaxLength = 3;
            txtFreq.Name = "txtFreq";
            txtFreq.Size = new Size(43, 23);
            txtFreq.TabIndex = 45;
            txtFreq.Text = "5";
            txtFreq.TextChanged += txtFreq_TextChanged;
            txtFreq.Enter += txtFreq_Enter;
            txtFreq.KeyPress += txtFreq_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 463);
            label10.Name = "label10";
            label10.Size = new Size(203, 15);
            label10.TabIndex = 46;
            label10.Text = "Full pathname (content or hlighlight)";
            // 
            // lblFullPathname
            // 
            lblFullPathname.BorderStyle = BorderStyle.FixedSingle;
            lblFullPathname.Location = new Point(12, 480);
            lblFullPathname.Name = "lblFullPathname";
            lblFullPathname.Size = new Size(776, 23);
            lblFullPathname.TabIndex = 47;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 512);
            Controls.Add(lblFullPathname);
            Controls.Add(label10);
            Controls.Add(txtFreq);
            Controls.Add(label9);
            Controls.Add(txtLength);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(btnHelp);
            Controls.Add(btnGithub);
            Controls.Add(btnHilightClear);
            Controls.Add(btnContentClear);
            Controls.Add(cmbStagger);
            Controls.Add(txtShuffleTime);
            Controls.Add(label6);
            Controls.Add(cmbSequencing);
            Controls.Add(cmbRandomize);
            Controls.Add(label5);
            Controls.Add(cmbResize);
            Controls.Add(cmbAdvance);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(picPreview);
            Controls.Add(btnHilightDown);
            Controls.Add(btnHilightUp);
            Controls.Add(btnHilightRemove);
            Controls.Add(btnHilightAdd);
            Controls.Add(lstHighlight);
            Controls.Add(lblHilight);
            Controls.Add(btnContentDown);
            Controls.Add(btnContentUp);
            Controls.Add(btnContentRemove);
            Controls.Add(btnContentAdd);
            Controls.Add(lstContent);
            Controls.Add(lblContent);
            Controls.Add(btnGridDown);
            Controls.Add(btnGridUp);
            Controls.Add(btnGridRemove);
            Controls.Add(btnGridAdd);
            Controls.Add(lstGrid);
            Controls.Add(label2);
            Controls.Add(btnEditor);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Controls.Add(btnNew);
            Controls.Add(lblPathname);
            Controls.Add(label1);
            Controls.Add(btnPlay);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "slidegrid";
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlay;
        private Label label1;
        private Label lblPathname;
        private Button btnNew;
        private Button btnLoad;
        private Button btnSave;
        private Button btnEditor;
        private Label label2;
        private ListBox lstGrid;
        private Button btnGridAdd;
        private Button btnGridRemove;
        private Button btnGridUp;
        private Button btnGridDown;
        private Button btnContentDown;
        private Button btnContentUp;
        private Button btnContentRemove;
        private Button btnContentAdd;
        private ListBox lstContent;
        private Label lblContent;
        private Button btnHilightDown;
        private Button btnHilightUp;
        private Button btnHilightRemove;
        private Button btnHilightAdd;
        private ListBox lstHighlight;
        private Label lblHilight;
        private PictureBox picPreview;
        private Label label3;
        private Label label4;
        private ComboBox cmbAdvance;
        private ComboBox cmbResize;
        private Label label5;
        private ComboBox cmbRandomize;
        private ComboBox cmbSequencing;
        private Label label6;
        private TextBox txtShuffleTime;
        private ComboBox cmbStagger;
        private Button btnContentClear;
        private Button btnHilightClear;
        private Button btnGithub;
        private Button btnHelp;
        private Label label7;
        private OpenFileDialog OpenSlidesDialog;
        private SaveFileDialog SaveSlidesDialog;
        private Label label8;
        private TextBox txtLength;
        private Label label9;
        private TextBox txtFreq;
        private Label label10;
        private Label lblFullPathname;
    }
}
