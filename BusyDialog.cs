﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slidegrid;
public partial class BusyDialog : Form
{
    public BusyDialog()
    {
        InitializeComponent();
    }

    public void SetLabel(string text)
    {
        lblActivity.Text = text;
        Refresh();
    }
}
