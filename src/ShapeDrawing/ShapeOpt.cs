using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShapeDrawing
{
    public partial class ShapeOpt : Form
    {
        public ShapeOpt()
        {
            InitializeComponent();
            col = DrawingForm.col;
            hs = DrawingForm.hs;
            a = DrawingForm.all;
            r = DrawingForm.rectarc;
            el = DrawingForm.ellipse;
            if (hs == HatchStyle.BackwardDiagonal) cBStyleShape.SelectedIndex = 0;
            if (hs == HatchStyle.Cross) cBStyleShape.SelectedIndex = 1;
            col = DrawingForm.col;
        }

        bool r;
        bool el;
        bool a;
        Color col;
        HatchStyle hs;
        Color cl;

        private void plDrawShapeCOlor_Paint(object sender, PaintEventArgs e)
        {
            if (hs == HatchStyle.BackwardDiagonal)
                cl = col;
            else cl = Color.White;
            HatchBrush br = new HatchBrush(hs, cl, col);
            if (r)
            {
                e.Graphics.FillRectangle(br, 50, 40, 110, 100);
            }
            if(el)
            {
                e.Graphics.FillEllipse(br, 50, 40, 110, 100);
            }
            if (a)
            {
                e.Graphics.FillRectangle(br, 40, 20, 50, 50);
                e.Graphics.FillEllipse(br, 40, 100, 50, 60);
            }
        }

        private void cBStyleShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBStyleShape.SelectedIndex == 0) hs = HatchStyle.BackwardDiagonal;
            if (cBStyleShape.SelectedIndex == 1) hs = HatchStyle.Cross;
            Refresh();
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlgColor = new ColorDialog();
            dlgColor.Color = col;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                col = dlgColor.Color;        
            }
            Refresh();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            DrawingForm.col = col;
            DrawingForm.hs = hs;
            Close();
        }
    }
}
