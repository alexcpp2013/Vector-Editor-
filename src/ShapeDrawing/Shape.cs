using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace ShapeDrawing
{
    abstract public class Shape : System.Windows.Forms.Control
    {
        protected GraphicsPath path = null;
        protected DashStyle DS;
        protected HatchStyle HS;

        //Создание соответствующего GraphicsPath на форме, и применение его
        //на Контрол, установка свойств области
        virtual protected void RefreshPath()
        {
        }


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            if (path != null)
            {
                Color color = Color.White;
                //если стиль заполнения Сплошной, то поставить цвет заполнения диагоналей 
                //равным стилю заполнения
                if (AccessibleName == "Cross") HS = HatchStyle.Cross;
                if (AccessibleName == "BackwardDiagonal")
                {
                    HS = HatchStyle.Cross;
                    color = this.BackColor;
                }
                HatchBrush hsb = new HatchBrush(HS, color, this.BackColor);
                SolidBrush shapeBrush = new SolidBrush(this.BackColor);
                Pen shapePen = new Pen(this.ForeColor, this.TabIndex);
                if( Text == "Solid" ) DS = DashStyle.Solid;
                if ( Text == "Dot" ) DS = DashStyle.Dot;
                shapePen.DashStyle = DS;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(hsb, path);
                e.Graphics.DrawPath(shapePen, path);
                shapePen.Dispose();
                shapeBrush.Dispose();
            }
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            RefreshPath();
            this.Invalidate();
        }
    }

    public class RectArc : Shape
    {
        public RectArc(DashStyle stl, int PenWidth, Color PenColor, Color BackColorShape, int SizeShape, int SizeShape1, int eX, int eY, HatchStyle hs)
        {
            Size = new Size(SizeShape, SizeShape1);
            ForeColor = PenColor;
            BackColor = BackColorShape;
            TabIndex = PenWidth; //тут просто храню толщину пера
            RefreshPath();
            Location = new Point(eX, eY);
            Name = "Rectangle"; //для распознования фигуры
            Text = stl.ToString(); //Для стиля линии
            DS = stl;
            HS = hs; 
            AccessibleName = HS.ToString(); //тут просто храню тип заполнения
        }

        protected override void RefreshPath()
        {
            if (path != null) path.Dispose();
            path = new GraphicsPath();
            int x1 = this.ClientRectangle.X;
            int y1 = this.ClientRectangle.Y;
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height;
            int cornerRadius = 10;
            int right = this.ClientRectangle.Right;
            int left = this.ClientRectangle.Left;
            int bot = this.ClientRectangle.Bottom;
            path.AddArc(x1, y1, cornerRadius * 2, cornerRadius * 2, 180, 90);
            path.AddLine(x1 + cornerRadius, y1, right - cornerRadius * 2, y1);
            path.AddArc(x1 + w - cornerRadius * 2, y1, cornerRadius * 2, cornerRadius * 2, 270, 90);
            path.AddLine(right, y1 + cornerRadius * 2, right, y1 + h - cornerRadius * 2);
            path.AddArc(x1 + w - cornerRadius * 2, y1 + h - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddLine(right - cornerRadius * 2, bot, x1 + cornerRadius * 2, bot);
            path.AddArc(x1, bot - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.AddLine(x1, bot - cornerRadius * 2, x1, y1 + cornerRadius * 2);
            path.CloseFigure();
            this.Region = new Region(path);
        }
    }

    public class Ellipse : Shape
    {
        public Ellipse(DashStyle stl, int PenWidth, Color PenColor, Color BackColorShape, int SizeShape, int SizeShape1, int eX, int eY, HatchStyle hs)
        {
            Size = new Size(SizeShape, SizeShape1);
            ForeColor = PenColor;
            BackColor = BackColorShape;
            TabIndex = PenWidth; //тут просто храню толщину пера
            RefreshPath();
            Location = new Point(eX, eY);
            Name = "Ellipse"; //для распознования фигуры
            Text = stl.ToString(); //Для стиля линии
            DS = stl;
            HS = hs;
            AccessibleName = HS.ToString();
        }

        protected override void RefreshPath()
        {
            if (path != null) path.Dispose();
            path = new GraphicsPath();
            path.AddEllipse(this.ClientRectangle);
            this.Region = new Region(path);
        }
    }

    public class Line : Shape
    {
        public Line(DashStyle stl, int PenWidth, Color PenColor, int SizeShape, int SizeShape1, int eX, int eY)
        {
            Size = new Size(SizeShape, SizeShape1);
            ForeColor = PenColor;
            TabIndex = PenWidth; //тут просто храню толщину пера
            RefreshPath();
            Location = new Point(eX, eY);
            Name = "Line"; //для распознования фигуры
            Text = stl.ToString(); //Для стиля линии
            DS = stl;
        }

        protected override void RefreshPath()
        {
            if (path != null) path.Dispose();
            path = new GraphicsPath();
            int x1 = this.ClientRectangle.X; //0
            int y1 = this.ClientRectangle.Y; //0
            int x2 = this.ClientRectangle.Width; //width координата
            int y2 = this.ClientRectangle.Height; //heigh координата
            path.AddLine(x1, y1, x2, y2);
            //path.CloseFigure();
            //this.Region = new Region(path); //не рисует!!! :(
        }
    }
}
    
