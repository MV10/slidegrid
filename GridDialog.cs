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
public partial class GridDialog : Form
{
    public GridDialog()
    {
        InitializeComponent();
    }

    internal Grid Grid
    {
        get
        {
            var g = new Grid();
            _ = int.TryParse(txtX.Text, out var x);
            _ = int.TryParse(txtY.Text, out var y);
            _ = int.TryParse(txtW.Text, out var w);
            _ = int.TryParse(txtH.Text, out var h);
            g.Dimensions = new(x, y, w, h);
            return g;
        }
    }

    private void txtX_KeyPress(object sender, KeyPressEventArgs e)
    {
        txtX.ValidateKeyPressInt(e);
    }

    private void txtX_TextChanged(object sender, EventArgs e)
    {
        if (!int.TryParse(txtX.Text, out var i)) txtX.Text = string.Empty;
    }

    private void txtY_KeyPress(object sender, KeyPressEventArgs e)
    {
        txtY.ValidateKeyPressInt(e);
    }

    private void txtY_TextChanged(object sender, EventArgs e)
    {
        if (!int.TryParse(txtY.Text, out var i)) txtY.Text = string.Empty;
    }

    private void txtW_KeyPress(object sender, KeyPressEventArgs e)
    {
        txtW.ValidateKeyPressInt(e);
    }

    private void txtW_TextChanged(object sender, EventArgs e)
    {
        if (!int.TryParse(txtW.Text, out var i)) txtW.Text = string.Empty;
    }

    private void txtH_KeyPress(object sender, KeyPressEventArgs e)
    {
        txtH.ValidateKeyPressInt(e);
    }

    private void txtH_TextChanged(object sender, EventArgs e)
    {
        if (!int.TryParse(txtH.Text, out var i)) txtH.Text = string.Empty;
    }

}
