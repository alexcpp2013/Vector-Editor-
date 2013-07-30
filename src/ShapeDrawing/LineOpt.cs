using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ShapeDrawing
{
    public partial class LineOpt : Form
    {
        public LineOpt()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            dsopt = DrawingForm.ds;
            widthopt = DrawingForm.PenWidth1;
            clropt = DrawingForm.DefColorShape1;
            nUDWidth.Value = (decimal)widthopt;
            if (dsopt == DashStyle.Solid) cBStyle.SelectedIndex = 0;
            if (dsopt == DashStyle.Dot) cBStyle.SelectedIndex = 1;
            if (clropt.R == 255) cBRed.Checked = true;
            if (clropt.G == 255) cBGreen.Checked = true;
            if (clropt.B == 255) cBBlue.Checked = true;
        }

        private Pen penopt;
        private DashStyle dsopt;
        private int widthopt;
        private Color clropt;
        int r = 0;
        int g = 0;
        int b = 0;

        private void LineOpt_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void plLineDraw_Paint(object sender, PaintEventArgs e)
        {
            if (cBRed.Checked) r = 255;
            else r = 0;
            if (cBGreen.Checked) g = 255;
            else g = 0;
            if (cBBlue.Checked) b = 255;
            else b = 0;
            clropt = Color.FromArgb(r, g, b);
            penopt = new Pen(clropt, widthopt);
            penopt.DashStyle = dsopt;
            e.Graphics.DrawLine(penopt, 10, 100, 200, 100);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cBStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBStyle.SelectedIndex == 0)
                dsopt = DashStyle.Solid;
            if (cBStyle.SelectedIndex == 1)
                dsopt = DashStyle.Dot;
            Refresh();
        }

        private void nUDWidth_ValueChanged(object sender, EventArgs e)
        {
            widthopt = (int)nUDWidth.Value;
            Refresh();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            clropt = Color.FromArgb(r, g, b);
            DrawingForm.PenWidth1 = widthopt;
            DrawingForm.DefColorShape1 = clropt;
            DrawingForm.ds = dsopt;
            Close();
        }

        private void cBRed_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void cBGreen_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void cBBlue_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
        }


    }
}
