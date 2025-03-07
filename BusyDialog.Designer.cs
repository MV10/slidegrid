namespace slidegrid;

partial class BusyDialog
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
        lblActivity = new Label();
        SuspendLayout();
        // 
        // lblActivity
        // 
        lblActivity.AutoSize = true;
        lblActivity.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
        lblActivity.Location = new Point(12, 18);
        lblActivity.Name = "lblActivity";
        lblActivity.Size = new Size(85, 21);
        lblActivity.TabIndex = 0;
        lblActivity.Text = "lblActivity";
        // 
        // BusyDialog
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(225, 59);
        ControlBox = false;
        Controls.Add(lblActivity);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "BusyDialog";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Playback starting...";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblActivity;
}