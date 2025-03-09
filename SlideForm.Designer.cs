namespace slidegrid;

partial class SlideForm
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
        components = new System.ComponentModel.Container();
        lblInfo = new Label();
        picSlide = new PictureBox();
        picPrev = new PictureBox();
        picNext = new PictureBox();
        timer = new System.Windows.Forms.Timer(components);
        ((System.ComponentModel.ISupportInitialize)picSlide).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picPrev).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picNext).BeginInit();
        SuspendLayout();
        // 
        // lblInfo
        // 
        lblInfo.AutoSize = true;
        lblInfo.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblInfo.ForeColor = Color.Lime;
        lblInfo.Location = new Point(4, 4);
        lblInfo.Name = "lblInfo";
        lblInfo.Size = new Size(72, 19);
        lblInfo.TabIndex = 0;
        lblInfo.Text = "lblInfo";
        // 
        // picSlide
        // 
        picSlide.Location = new Point(104, 110);
        picSlide.Name = "picSlide";
        picSlide.Size = new Size(100, 50);
        picSlide.SizeMode = PictureBoxSizeMode.Zoom;
        picSlide.TabIndex = 1;
        picSlide.TabStop = false;
        picSlide.MouseClick += picSlide_MouseClick;
        // 
        // timer
        // 
        timer.Tick += timer_Tick;
        // 
        // picPrev
        // 
        picPrev.Location = new Point(104, 166);
        picPrev.Name = "picPrev";
        picPrev.Size = new Size(100, 50);
        picPrev.SizeMode = PictureBoxSizeMode.Zoom;
        picPrev.TabIndex = 2;
        picPrev.TabStop = false;
        // 
        // picNext
        // 
        picNext.Location = new Point(104, 222);
        picNext.Name = "picNext";
        picNext.Size = new Size(100, 50);
        picNext.SizeMode = PictureBoxSizeMode.Zoom;
        picNext.TabIndex = 3;
        picNext.TabStop = false;
        // 
        // SlideForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Black;
        ClientSize = new Size(800, 450);
        Controls.Add(picNext);
        Controls.Add(picPrev);
        Controls.Add(picSlide);
        Controls.Add(lblInfo);
        FormBorderStyle = FormBorderStyle.None;
        Name = "SlideForm";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.Manual;
        KeyUp += SlideForm_KeyUp;
        ((System.ComponentModel.ISupportInitialize)picSlide).EndInit();
        ((System.ComponentModel.ISupportInitialize)picPrev).EndInit();
        ((System.ComponentModel.ISupportInitialize)picNext).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblInfo;
    private PictureBox picSlide;
    private PictureBox picPrev;
    private PictureBox picNext;
    private System.Windows.Forms.Timer timer;
}