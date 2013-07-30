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
    public partial class SizeofFigure : Form
    {
        public SizeofFigure()
        {
            InitializeComponent();
            FWidth = DrawingForm.SizeofShapeW;
            FHeight = DrawingForm.SizeofShapeH;
            panel1.AutoScroll = true;
        }

        int FWidth = 0;
        int FHeight = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            DrawingForm.SizeofShapeW = FWidth;
            DrawingForm.SizeofShapeH = FHeight;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FWidth += 5;
            Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FHeight += 5;
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if( FWidth > 5 ) FWidth -= 5;
            Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (FHeight > 5) FHeight -= 5;
            Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            float kW = (float)panel1.Width / DrawingForm.pDSizeofShapeW;
            float kH = (float)panel1.Height / DrawingForm.pDSizeofShapeH;
            System.Drawing.Graphics graph = this.panel1.CreateGraphics();
            System.Drawing.Pen red = new Pen(Color.Red, 2); // красное, ширина: 2
            if(DrawingForm.NameofSize == "Rectangle")
                graph.DrawRectangle(red, 0, 0, FWidth * kW, FHeight * kH); // рисуем прямоугольники
            if(DrawingForm.NameofSize == "Ellipse")
                graph.DrawEllipse(red, 0, 0, FWidth * kW, FHeight * kH);
            if(DrawingForm.NameofSize == "Line")
                graph.DrawLine(red, 0, 50, FWidth * kW, FHeight * kH);
        }
    }
}
