using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace ShapeDrawing
{
    public partial class DrawingForm : Form
    {
        public DrawingForm()
        {
            InitializeComponent();
        
            //выбираем фигуру, которая рисуется по умолчанию
            /*
            Непосредственно
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            isDrawing = true;
            rectarc = true;
            */
            /*
            Либо эмулируем нажатие клавиши простым вызовом обработчика нужной кнопки
            object S = new object();
            EventArgs E = new EventArgs();
            рисоватьПрямоугольникToolStripMenuItem_Click(S, E);
            */
            /*
            Либо вставить вызов обработчика в Load
            */
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        public static int SizeofShapeW = 0;
        public static int SizeofShapeH = 0;
        public static int pDSizeofShapeW = 0;
        public static int pDSizeofShapeH = 0;
        public static string NameofSize = "";
        public static bool rectarc = false;
        public static bool ellipse = false;
        public static bool line = false;
        public static bool all = false;
        private bool fl = false;
        private bool network = false;
        private bool isTie = false;
        private bool isDragging = false;
        private bool isResizing = false;
        private bool isDrawing = false;
        private bool isChoose = false;
        private List<Control> L = new List<Control>();
        private int Xold;
        private int Yold;
        private int Xnew;
        private int Ynew;
        private int clickOffsetX, clickOffsetY;
        public static int PenWidth1 = 5;
        public static int PenWidthn = 5;
        public static Color DefColorShape1 = Color.Red;
        public static Color DefColorShapen = Color.Red;
        public SolidBrush defShapeBrush1 = new SolidBrush(DefColorShape1);
        public Pen shapePen1 = new Pen(DefColorShape1, PenWidth1);
        public SmoothingMode defMode1 = SmoothingMode.AntiAlias;
        public static Color col = Color.Blue;
        public static Color coln = Color.Blue;
        public int size = 1;
        public int size1 = 1;
        public static DashStyle ds = DashStyle.Solid;
        public static DashStyle dsn = DashStyle.Solid;
        public static HatchStyle hs = HatchStyle.BackwardDiagonal;
        public static HatchStyle hsn = HatchStyle.BackwardDiagonal;
        private static Control ctrlToFocus;
        private static Shape Figure;

        private void cMSShape_Opening(object sender, CancelEventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Курсовой проект по ООП", "О программе",
                       System.Windows.Forms.MessageBoxButtons.OK,
                       System.Windows.Forms.MessageBoxIcon.Information);
        }

        private void рисоватьПрямоугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            isDrawing = true;
            rectarc = true;
        }

        private void рисовтьЭллипсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            isDrawing = true;
            ellipse = true;
        }

        private void рисоватьЛиниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            isDrawing = true;
            line = true;
        }

        private void сброситьВыборрисованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawing = false;
            rectarc = false;
            ellipse = false;
            line = false;
            fl = false;
            isChoose = false;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            if (L.Count != 0) L.Clear();
            if (ctrlToFocus != null) ctrlToFocus = null;
        }

        private void изменитьЦветФигурыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //заблокируем такую возмоность для Line, 
            //хотя она останеться если изменять у нескольких выделенных фигур 
            //с помощью этой же команды, если последняя выбранная не есть Line
            if (cMSShape.SourceControl.Name != "Line")
            {
                //Показать КолорДиалог
                ColorDialog dlgColor = new ColorDialog();
                dlgColor.Color = col;
                if (dlgColor.ShowDialog() == DialogResult.OK)
                {
                    //Изменить цвет всех фигур в списке выделеных
                    if (isChoose)
                    {
                        foreach (Control ctrl in L)
                        {
                            ctrl.BackColor = dlgColor.Color;
                        }
                    }
                    else
                        //Изменить цвет фигуры
                        cMSShape.SourceControl.BackColor = dlgColor.Color;
                }
            }
        }

        private void удалитьФигуруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChoose)
            {
                foreach (Control ctrl in L)
                {
                    this.pDrawing.Controls.Remove(ctrl);
                }
                if (L.Count != 0) L.Clear();
            }
            else
            {
                Control ctrlShape = cMSShape.SourceControl;
                this.pDrawing.Controls.Remove(ctrlShape);
                //Refresh() Invalidate()
            }
        }

        private void поставитьНапередToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control ctrlShape = cMSShape.SourceControl;
            ctrlShape.BringToFront();
            ctrlShape.CanFocus();
        }

        private void поставитьНазадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control ctrlShape = cMSShape.SourceControl;
            ctrlShape.SendToBack();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (L.Count != 0) L.Clear();
            this.pDrawing.Controls.Clear();
            network = false;
            isTie = false;
            Refresh();
        }

        private void удвоитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.pDrawing.Controls.Count; ++i)
            {
                int nX = 2 * pDrawing.Controls[i].Size.Width;
                int nY = 2 * pDrawing.Controls[i].Size.Height;
                pDrawing.Controls[i].Width = nX;
                pDrawing.Controls[i].Height = nY;
                nX = pDrawing.Controls[i].Location.X / 2;
                nY = pDrawing.Controls[i].Location.Y / 2;
                pDrawing.Controls[i].Location = new Point(nX, nY);
            }
        }

        private void уменьшитьВДваРазаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.pDrawing.Controls.Count; ++i)
            {
                int nX = pDrawing.Controls[i].Size.Width / 2;
                int nY = pDrawing.Controls[i].Size.Height / 2;
                pDrawing.Controls[i].Width = nX;
                pDrawing.Controls[i].Height = nY;
                nX = pDrawing.Controls[i].Location.X * 2;
                nY = pDrawing.Controls[i].Location.Y * 2;
                pDrawing.Controls[i].Location = new Point(nX, nY);
            }
        }

        private void pDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            Refresh();
            if (isDrawing)
            {
                //Создание и настройка Контрола
                Control sh = new Control();
                //Shape sh;
                Xold = e.X;
                Yold = e.Y;
                if (rectarc)
                {
                    sh = new RectArc(ds, PenWidth1, DefColorShape1, col, size, size1, e.X, e.Y, hs);
                    /*sh.ContextMenuStrip = cMSShape;
                    sh.MouseDown += new MouseEventHandler(ctrl_MouseDown);
                    sh.MouseMove += new MouseEventHandler(ctrl_MouseMove);
                    sh.MouseUp += new MouseEventHandler(ctrl_MouseUp);
                    this.pDrawing.Controls.Add(sh);
                    Figure = sh;*/
                }
                if (ellipse)
                {
                    sh = new Ellipse(ds, PenWidth1, DefColorShape1, col, size, size1, e.X, e.Y, hs);
                    /*sh.ContextMenuStrip = cMSShape;
                    sh.MouseDown += new MouseEventHandler(ctrl_MouseDown);
                    sh.MouseMove += new MouseEventHandler(ctrl_MouseMove);
                    sh.MouseUp += new MouseEventHandler(ctrl_MouseUp);
                    this.pDrawing.Controls.Add(sh);
                    Figure = sh;*/
                }
                if (line)
                {
                    sh = new Line(ds, PenWidth1, DefColorShape1, size, size1, e.X, e.Y);
                    //Прикрепить контекстное меню к Контролу
                    /*sh.ContextMenuStrip = cMSShape;
                    //Подписать Контрол на события мыши
                    sh.MouseDown += new MouseEventHandler(ctrl_MouseDown);
                    sh.MouseMove += new MouseEventHandler(ctrl_MouseMove);
                    sh.MouseUp += new MouseEventHandler(ctrl_MouseUp);
                    //Прибавить Контрол к остальным на холсте
                    this.pDrawing.Controls.Add(sh);
                    Figure = sh; //Теперь Figure будет рисоваться*/
                }
                //Прикрепить контекстное меню к Контролу
                sh.ContextMenuStrip = cMSShape;
                //Подписать Контрол на события мыши
                sh.MouseDown += new MouseEventHandler(ctrl_MouseDown);
                sh.MouseMove += new MouseEventHandler(ctrl_MouseMove);
                sh.MouseUp += new MouseEventHandler(ctrl_MouseUp);
                //Прибавить Контрол к остальным на холсте
                this.pDrawing.Controls.Add(sh);
                Figure = (Shape)sh;
                fl = true;
            }
            else
            {
                if (ctrlToFocus != null)
                {
                    ctrlToFocus = null;
                    Invalidate();
                }
                /*if (e.Button == MouseButtons.Right)
                {
                    this.ContextMenuStrip.Show(this, new Point(e.X, e.Y));
                }*/
            }
        }

        private void ctrl_MouseDown(object sender,
         System.Windows.Forms.MouseEventArgs e)
        {
            //Получить ссылку на активный Контрол
            Control currentCtrl;
            currentCtrl = (Control)sender;
            // Required for the focus rectangle.
            ctrlToFocus = currentCtrl;
            // Invalidate to show the focus rectangle.
            Invalidate();
            Refresh(); //Показать прямоугольник вокруг выброной фигуры-контрола
            if (e.Button == MouseButtons.Right)
            {
                //Показать контекстное меню
                currentCtrl.ContextMenuStrip.Show(currentCtrl, new Point(e.X, e.Y));
            }
            else if (e.Button == MouseButtons.Left)
            {
                clickOffsetX = e.X;
                clickOffsetY = e.Y;

                if (currentCtrl.Cursor == Cursors.SizeNWSE ||
                 currentCtrl.Cursor == Cursors.SizeNS ||
                 currentCtrl.Cursor == Cursors.SizeWE)
                {
                    // The mouse pointer is at one of the sides,
                    // so resizing mode is appropriate.
                    isResizing = true;
                }
                else
                {
                    // The mouse is somewhere else, so dragging mode is
                    // appropriate.
                    isDragging = true;
                }
            }
            if (isChoose)
            {
                L.Add(currentCtrl);
            }
        }

        private void ctrl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Retrieve a reference to the active shape.
            Control currentCtrl;
            currentCtrl = (Control)sender;

            if (isDragging)
            {
                // Move the control.
                currentCtrl.Left = e.X + currentCtrl.Left - clickOffsetX;
                currentCtrl.Top = e.Y + currentCtrl.Top - clickOffsetY;
            }
            else if (isResizing)
            {
                if (currentCtrl.Cursor == Cursors.SizeNWSE)
                {
                    // Resize the control, according to the resize mode.
                    currentCtrl.Width = e.X;
                    currentCtrl.Height = e.Y;
                }
                else if (currentCtrl.Cursor == Cursors.SizeNS)
                {
                    currentCtrl.Height = e.Y;
                }
                else if (currentCtrl.Cursor == Cursors.SizeWE)
                {
                    currentCtrl.Width = e.X;
                }
            }
            else
            {
                // Change the cursor if the mouse pointer is on one of the edges
                // of the control.
                if (((e.X + 5) > currentCtrl.Width) &&
                   ((e.Y + 5) > currentCtrl.Height))
                {
                    currentCtrl.Cursor = Cursors.SizeNWSE;
                }
                else if ((e.X + 5) > currentCtrl.Width)
                {
                    currentCtrl.Cursor = Cursors.SizeWE;
                }
                else if ((e.Y + 5) > currentCtrl.Height)
                {
                    currentCtrl.Cursor = Cursors.SizeNS;
                }
                else
                {
                    // This misleadingly named cursor is the four-way
                    // mouse pointer often used for moving objects.
                    currentCtrl.Cursor = Cursors.SizeAll;
                }
            }
        }

        private void ctrl_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            isDragging = false;
            isResizing = false;
            isDrawing = false;
            fl = false;
            // Invalidate to show the focus rectangle.
            Invalidate();
            Refresh(); //для уничтожения артифакта 
        }

        private void pDrawing_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            if (ctrlToFocus != null && !isDragging)
            {
                Rectangle rect = ctrlToFocus.Bounds;
                rect.Inflate(new Size(2, 2));
                ControlPaint.DrawFocusRectangle(e.Graphics, rect);
            }
            if (network)
            {
                int deltX = 0;
                int deltY = 0;
                deltX = pDrawing.Size.Width / 10;
                deltY = pDrawing.Size.Height / 10;

                //Size size = new Size(deltX, deltY);
                //ControlPaint.DrawGrid(e.Graphics, this.pDrawing.ClientRectangle, size, Color.Red);
                Graphics gn = this.pDrawing.CreateGraphics();
                Pen pn = new Pen(Color.Green, 1);
                //vertical
                for (int i = 0; i <= pDrawing.Size.Width; i += deltX)
                {
                    gn.DrawLine(pn, i, 0,  i,pDrawing.Size.Height);
                }
                //horizontal
                for (int j = 0; j <= pDrawing.Size.Width; j += deltY)
                {
                    gn.DrawLine(pn, 0, j, pDrawing.Size.Width, j);
                }

                if (isTie)
                {
                    //привязать к сетке вершину фигуры
                    //найти минимальное расстояние до точки сетки
                    //привязать левую вершину фигуры к сетке
                    for (int k = 0; k < pDrawing.Controls.Count; ++k)
                    {
                        Point Start = pDrawing.Controls[k].Location;
                        Point NewStart = new Point(0, 0);
                        int delta = (int)Math.Sqrt(Math.Pow((Start.X - NewStart.X),2)+Math.Pow((Start.Y - NewStart.Y),2));
                        for (int i = 0; i <= pDrawing.Size.Width; i += deltX)
                        {
                            for (int j = 0; j <= pDrawing.Size.Width; j += deltY)
                            {
                                Point NStart = new Point(i, j);
                                int deltanew = (int)Math.Sqrt(Math.Pow((Start.X - NStart.X), 2) + Math.Pow((Start.Y - NStart.Y), 2));
                                if (deltanew < delta) 
                                {
                                    delta = deltanew;
                                    NewStart = NStart;
                                }
                            }
                        }
                        //привязка
                        pDrawing.Controls[k].Location = NewStart;
                    }
                }
            }
        }

        private void pDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            fl = false;
            rectarc = false;
            ellipse = false;
            line = false;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void pDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && fl)
            {
                Xnew = e.X;
                Ynew = e.Y;
                Figure.Width = Xnew - Xold;
                Figure.Height = Ynew - Yold;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int r = 0;
            int g = 0;
            int b = 0;
            if (sender == toolStripMenuItem2)
            {
                r = 0; g = 0; b = 0;
            }
            if (sender == toolStripMenuItem3)
            {
                r = 0; g = 0; b = 255;
            }
            if (sender == toolStripMenuItem4)
            {
                r = 0; g = 255; b = 0;
            }
            if (sender == dToolStripMenuItem)
            {
                r = 0; g = 255; b = 255;
            }
            if (sender == toolStripMenuItem6)
            {
                r = 255; g = 0; b = 0;
            }
            if (sender == toolStripMenuItem7)
            {
                r = 255; g = 0; b = 255;
            }
            if (sender == toolStripMenuItem8)
            {
                r = 255; g = 255; b = 0;
            }
            if (sender == toolStripMenuItem9)
            {
                r = 255; g = 255; b = 255;
            }
            if (isChoose)
            {
                foreach (Control ctrl in L)
                {
                    ctrl.ForeColor = Color.FromArgb(r, g, b);
                }
            }
            else
                ctrlToFocus.ForeColor = Color.FromArgb(r, g, b);
            Refresh();
        }

        private void увеличитьТолщинуЛинииВ2РазаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChoose)
            {
                foreach (Control ctrl in L)
                {
                    ctrl.TabIndex += 1;
                }
            }
            else
                cMSShape.SourceControl.TabIndex += 1;
            pDrawing.Refresh();
        }

        private void уменьшитьТолщинуЛинииВ2РазаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChoose)
            {
                foreach (Control ctrl in L)
                {
                    if (cMSShape.SourceControl.TabIndex > 1)
                    {
                        ctrl.TabIndex -= 1;
                    }
                }
            }
            else
                if (cMSShape.SourceControl.TabIndex > 1)
                {
                    cMSShape.SourceControl.TabIndex -= 1;
                }
            pDrawing.Refresh();
        }

        private void выбратьНесколькоФигурToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isChoose = true;
        }

        private void цельнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChoose)
            {
                foreach (Control ctrl in L)
                {
                    ctrl.Text = "Solid";
                }
            }
            else
                ctrlToFocus.Text = "Solid";
            pDrawing.Refresh();
        }

        private void точечнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChoose)
            {
                foreach (Control ctrl in L)
                {
                    ctrl.Text = "Dot";
                }
            }
            else
                ctrlToFocus.Text = "Dot";
            pDrawing.Refresh();
        }

        private void сплошнойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChoose)
            {
                foreach (Control ctrl in L)
                {
                    ctrl.AccessibleName = "BackwardDiagonal";
                }
            }
            else
                ctrlToFocus.AccessibleName = "BackwardDiagonal";
            pDrawing.Refresh();
        }

        private void клеточкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChoose)
            {
                foreach (Control ctrl in L)
                {
                    ctrl.AccessibleName = "Cross";
                }
            }
            else
                ctrlToFocus.AccessibleName = "Cross";
            pDrawing.Refresh();

        }

        private void изменитьСтильЛинииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ctrlToFocus = cMSShape.SourceControl;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sFDShape.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs =
                        File.Create(sFDShape.FileName))
                    {
                        //For writting
                        StreamWriter SW = new StreamWriter(fs, System.Text.Encoding.Unicode);
                        for (int i = 0; i < this.pDrawing.Controls.Count; ++i)
                        {
                            //Возможно лучше сохранять не отдельными данными-членами,
                            //а создать новый класс, провести сериализациию
                            //и пойти таким путем:
                            //XmlSerializer serializer = new XmlSerializer(typeof(MyNewClass));
                            if (this.pDrawing.Controls[i].Name ==
                                "Rectangle" || this.pDrawing.Controls[i].Name ==
                                "Ellipse" || this.pDrawing.Controls[i].Name ==
                                "Line")
                            {
                                //this.pDrawing.Controls[i]
                                SW.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}",
                                    this.pDrawing.Controls[i].Name,
                                    this.pDrawing.Controls[i].Text,
                                    this.pDrawing.Controls[i].TabIndex.ToString(),
                                    this.pDrawing.Controls[i].ForeColor.ToArgb().ToString(),
                                    this.pDrawing.Controls[i].BackColor.ToArgb().ToString(),
                                    this.pDrawing.Controls[i].Width.ToString(),
                                    this.pDrawing.Controls[i].Height.ToString(),
                                    this.pDrawing.Controls[i].Location.X.ToString(),
                                    this.pDrawing.Controls[i].Location.Y.ToString(),
                                    this.pDrawing.Controls[i].AccessibleName));
                            }
                        }
                        SW.Close();
                        fs.Close();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Ошибка при сохранении!" + err.Message);
                }
            }
        }
       
        DashStyle stl1;
        HatchStyle stl4;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oFDShape.ShowDialog() == DialogResult.OK)
            {
                Shape myShape;
                string stl2;
                string stl3;
                int Penw;
                Color penC;
                Color BackC;
                int s;
                int s1;
                int x1;
                int y1;
                string NShape;
                Point p;
                try
                {
                    using (FileStream fs =
                        File.Open(oFDShape.FileName, FileMode.Open))
                    {
                        StreamReader SR = new StreamReader(fs, System.Text.Encoding.Unicode);
                        string str;
                        string[] strs;
                        while ((str = SR.ReadLine()) != null)
                        {
                            strs = str.Split(';');

                            NShape = strs[0];
                            stl2 = strs[1];
                            Penw = int.Parse(strs[2]);
                            penC = Color.FromArgb(int.Parse(strs[3]));
                            BackC = Color.FromArgb(int.Parse(strs[4]));
                            s = int.Parse(strs[5]);
                            s1 = int.Parse(strs[6]);
                            x1 = int.Parse(strs[7]);
                            y1 = int.Parse(strs[8]);
                            stl3 = strs[9];
                            p = new Point(x1, y1);
                            switch (stl2)
                            {
                                case "Solid":
                                    stl1 = DashStyle.Solid;
                                    break;
                                case "Dot":
                                    stl1 = DashStyle.Dot;
                                    break;
                            }
                            switch (stl3)
                            {
                                case "Cross":
                                    stl4 = HatchStyle.Cross;
                                    break;
                                case "BackwardDiagonal":
                                    stl4 = HatchStyle.BackwardDiagonal;
                                    break;
                            }
                            if (NShape == "Rectangle")
                            {
                                myShape = new RectArc(stl1, Penw, penC, BackC, s, s1, x1, y1, stl4);
                                myShape.ContextMenuStrip = cMSShape;
                                myShape.MouseDown += new MouseEventHandler(ctrl_MouseDown);
                                myShape.MouseMove += new MouseEventHandler(ctrl_MouseMove);
                                myShape.MouseUp += new MouseEventHandler(ctrl_MouseUp);
                                this.pDrawing.Controls.Add(myShape);
                            }
                            if (NShape == "Ellipse")
                            {
                                myShape = new Ellipse(stl1, Penw, penC, BackC, s, s1, x1, y1, stl4);
                                myShape.ContextMenuStrip = cMSShape;
                                myShape.MouseDown += new MouseEventHandler(ctrl_MouseDown);
                                myShape.MouseMove += new MouseEventHandler(ctrl_MouseMove);
                                myShape.MouseUp += new MouseEventHandler(ctrl_MouseUp);
                                this.pDrawing.Controls.Add(myShape);
                            }
                            if (NShape == "Line")
                            {
                                myShape = new Line(stl1, Penw, penC, s, s1, x1, y1);
                                myShape.ContextMenuStrip = cMSShape;
                                myShape.MouseDown += new MouseEventHandler(ctrl_MouseDown);
                                myShape.MouseMove += new MouseEventHandler(ctrl_MouseMove);
                                myShape.MouseUp += new MouseEventHandler(ctrl_MouseUp);
                                this.pDrawing.Controls.Add(myShape);
                            }
                        }
                        SR.Close();
                        fs.Close();
                    }
                    //this.Refresh();
                    Invalidate();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Ошибка при открытии!" + err.Message);
                }
            }
        }

        private void изменитьСтильЛинииToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if(panelSize.Visible == true) panelSize.Visible = false;
            else panelSize.Visible = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
        }

        private void toolStripSize_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panelSize_MouseClick(object sender, MouseEventArgs e)
        {

            if (ctrlToFocus != null)
            {
                int x = 0;
                int y = 0;
                int W = 0;
                int H = 0;
                x = ctrlToFocus.Location.X;
                y = ctrlToFocus.Location.Y;
                W = ctrlToFocus.Size.Width;
                H = ctrlToFocus.Size.Height;
               
                if (sender == button1)
                {
                    y--;
                    ctrlToFocus.Location = new Point(x, y);
                    pDrawing.Refresh();
                }
                if (sender == button2)
                {
                    y++;
                    ctrlToFocus.Location = new Point(x, y);
                    pDrawing.Refresh();
                }
                if (sender == button3)
                {
                    x++;
                    ctrlToFocus.Location = new Point(x, y);
                    pDrawing.Refresh();
                }
                if (sender == button4)
                {
                    x--;
                    ctrlToFocus.Location = new Point(x, y);
                    pDrawing.Refresh();
                }
                if (sender == button5)
                {
                    W++;
                    ctrlToFocus.Size = new Size(W, H);
                    pDrawing.Refresh();
                }
                if (sender == button6)
                {
                    H++;
                    ctrlToFocus.Size = new Size(W, H);
                    pDrawing.Refresh();
                }
                if (sender == button7)
                {
                    if (W > 1)
                    {
                        W--;
                        ctrlToFocus.Size = new Size(W, H);
                        pDrawing.Refresh();
                    }
                }
                if (sender == button8)
                {
                    if (H > 1)
                    {
                        H--;
                        ctrlToFocus.Size = new Size(W, H);
                        pDrawing.Refresh();
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void настройкалинииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctrlToFocus != null)
            {
                dsn = ds;
                PenWidthn = PenWidth1;
                DefColorShapen = DefColorShape1;
                if (ctrlToFocus.Text == "Solid") ds = DashStyle.Solid;
                if (ctrlToFocus.Text == "Dot") ds = DashStyle.Dot;
                PenWidth1 = ctrlToFocus.TabIndex;
                DefColorShape1 = ctrlToFocus.ForeColor;
                LineOpt FormOptions = new LineOpt();
                FormOptions.ShowDialog();
                FormOptions.Dispose();
                ctrlToFocus.ForeColor = DefColorShape1;
                ctrlToFocus.Text = ds.ToString();
                ctrlToFocus.TabIndex = PenWidth1;
                PenWidth1 = PenWidthn;
                ds = dsn;
                DefColorShape1 = DefColorShapen;
                Refresh();
            }
            else
            {
                //Запуск формы с опциями
                LineOpt FormOptions = new LineOpt();
                FormOptions.ShowDialog();
                FormOptions.Dispose();
            }
        }

        private void выбратьФигуруToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void показатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            network = true;
            pDrawing.AutoScroll = false;
            pDrawing.Refresh();
        }

        private void скрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            network = false;
            pDrawing.AutoScroll = true;
            pDrawing.Refresh();
        }

        private void привязатьКСеткеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (network) 
            {
                isTie = true;
            }
        }

        private void DrawingForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void настройкафигурыToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if ((ctrlToFocus != null) && (ctrlToFocus.Name != "Line"))
            {
                hsn = hs;
                coln = col;
                if (ctrlToFocus.AccessibleName == "BackwardDiagonal") hs = HatchStyle.BackwardDiagonal;
                if (ctrlToFocus.AccessibleName == "Cross") hs = HatchStyle.Cross;
                if (ctrlToFocus.Name == "Rectangle")
                {
                    ellipse = false;
                    rectarc = true;
                }
                if (ctrlToFocus.Name == "Ellipse")
                {
                    ellipse = true;
                    rectarc = false;
                }
                ShapeOpt FormOptions = new ShapeOpt();
                FormOptions.ShowDialog();
                FormOptions.Dispose();
                ctrlToFocus.BackColor = col;
                ctrlToFocus.AccessibleName = hs.ToString();
                col = coln;
                hs = hsn;
                rectarc = false;
                ellipse = false;
                Refresh();
            }
            else
            {
                //Запуск формы с опциями
                all = true;
                ShapeOpt FormOptions = new ShapeOpt();
                FormOptions.ShowDialog();
                FormOptions.Dispose();
                all = false;
            }
        }

        private void отменитьПривязкуКСеткеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isTie = false;
        }

        private void настройкаРазмераФигурыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctrlToFocus != null)
            {

                SizeofShapeW = ctrlToFocus.Width; 
                SizeofShapeH = ctrlToFocus.Height;
                NameofSize = ctrlToFocus.Name;
                pDSizeofShapeW = pDrawing.Width; //узнаем коефициент преобразования
                pDSizeofShapeH = pDrawing.Height;
                SizeofFigure Figure = new SizeofFigure();
                Figure.ShowDialog();
                Figure.Dispose();
                ctrlToFocus.Width = SizeofShapeW;
                ctrlToFocus.Height = SizeofShapeH;
                SizeofShapeW = 0;
                SizeofShapeH = 0;
                NameofSize = "";
                pDSizeofShapeW = 0;
                pDSizeofShapeH = 0;
                Refresh();
            }
        }
    }
}
