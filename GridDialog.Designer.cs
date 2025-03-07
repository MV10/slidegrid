namespace slidegrid;

partial class GridDialog
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
        label2 = new Label();
        txtX = new TextBox();
        label3 = new Label();
        txtY = new TextBox();
        txtH = new TextBox();
        label4 = new Label();
        txtW = new TextBox();
        label5 = new Label();
        label6 = new Label();
        btnOk = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(50, 15);
        label1.TabIndex = 0;
        label1.Text = "Position";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(81, 9);
        label2.Name = "label2";
        label2.Size = new Size(14, 15);
        label2.TabIndex = 1;
        label2.Text = "X";
        // 
        // txtX
        // 
        txtX.Location = new Point(101, 6);
        txtX.MaxLength = 6;
        txtX.Name = "txtX";
        txtX.Size = new Size(64, 23);
        txtX.TabIndex = 2;
        txtX.TextChanged += txtX_TextChanged;
        txtX.KeyPress += txtX_KeyPress;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(189, 9);
        label3.Name = "label3";
        label3.Size = new Size(14, 15);
        label3.TabIndex = 3;
        label3.Text = "Y";
        // 
        // txtY
        // 
        txtY.Location = new Point(209, 6);
        txtY.MaxLength = 6;
        txtY.Name = "txtY";
        txtY.Size = new Size(64, 23);
        txtY.TabIndex = 4;
        txtY.TextChanged += txtX_TextChanged;
        txtY.KeyPress += txtX_KeyPress;
        // 
        // txtH
        // 
        txtH.Location = new Point(209, 35);
        txtH.MaxLength = 6;
        txtH.Name = "txtH";
        txtH.Size = new Size(64, 23);
        txtH.TabIndex = 9;
        txtH.TextChanged += txtX_TextChanged;
        txtH.KeyPress += txtX_KeyPress;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(189, 38);
        label4.Name = "label4";
        label4.Size = new Size(16, 15);
        label4.TabIndex = 8;
        label4.Text = "H";
        // 
        // txtW
        // 
        txtW.Location = new Point(101, 35);
        txtW.MaxLength = 6;
        txtW.Name = "txtW";
        txtW.Size = new Size(64, 23);
        txtW.TabIndex = 7;
        txtW.TextChanged += txtX_TextChanged;
        txtW.KeyPress += txtX_KeyPress;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(81, 38);
        label5.Name = "label5";
        label5.Size = new Size(18, 15);
        label5.TabIndex = 6;
        label5.Text = "W";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(12, 38);
        label6.Name = "label6";
        label6.Size = new Size(27, 15);
        label6.TabIndex = 5;
        label6.Text = "Size";
        // 
        // btnOk
        // 
        btnOk.DialogResult = DialogResult.OK;
        btnOk.Location = new Point(63, 82);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(75, 23);
        btnOk.TabIndex = 10;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = true;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(155, 82);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 23);
        btnCancel.TabIndex = 11;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // GridDialog
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(291, 126);
        ControlBox = false;
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Controls.Add(txtH);
        Controls.Add(label4);
        Controls.Add(txtW);
        Controls.Add(label5);
        Controls.Add(label6);
        Controls.Add(txtY);
        Controls.Add(label3);
        Controls.Add(txtX);
        Controls.Add(label2);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "GridDialog";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Grid Definition";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private TextBox txtX;
    private Label label3;
    private TextBox txtY;
    private TextBox txtH;
    private Label label4;
    private TextBox txtW;
    private Label label5;
    private Label label6;
    private Button btnOk;
    private Button btnCancel;
}