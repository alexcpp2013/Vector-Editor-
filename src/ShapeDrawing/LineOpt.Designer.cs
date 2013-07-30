namespace ShapeDrawing
{
    partial class LineOpt
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
            this.plLineDraw = new System.Windows.Forms.Panel();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBBlue = new System.Windows.Forms.CheckBox();
            this.cBGreen = new System.Windows.Forms.CheckBox();
            this.cBRed = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBStyle = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nUDWidth = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // plLineDraw
            // 
            this.plLineDraw.BackColor = System.Drawing.Color.White;
            this.plLineDraw.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLineDraw.ForeColor = System.Drawing.Color.White;
            this.plLineDraw.Location = new System.Drawing.Point(0, 0);
            this.plLineDraw.Name = "plLineDraw";
            this.plLineDraw.Size = new System.Drawing.Size(251, 239);
            this.plLineDraw.TabIndex = 0;
            this.plLineDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.plLineDraw_Paint);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(545, 129);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "Применить";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(545, 206);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBBlue);
            this.groupBox1.Controls.Add(this.cBGreen);
            this.groupBox1.Controls.Add(this.cBRed);
            this.groupBox1.Location = new System.Drawing.Point(275, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Цвет";
            // 
            // cBBlue
            // 
            this.cBBlue.AutoSize = true;
            this.cBBlue.Location = new System.Drawing.Point(7, 67);
            this.cBBlue.Name = "cBBlue";
            this.cBBlue.Size = new System.Drawing.Size(57, 17);
            this.cBBlue.TabIndex = 2;
            this.cBBlue.Text = "Синий";
            this.cBBlue.UseVisualStyleBackColor = true;
            this.cBBlue.CheckedChanged += new System.EventHandler(this.cBBlue_CheckedChanged);
            // 
            // cBGreen
            // 
            this.cBGreen.AutoSize = true;
            this.cBGreen.Location = new System.Drawing.Point(7, 44);
            this.cBGreen.Name = "cBGreen";
            this.cBGreen.Size = new System.Drawing.Size(71, 17);
            this.cBGreen.TabIndex = 1;
            this.cBGreen.Text = "Зелёный";
            this.cBGreen.UseVisualStyleBackColor = true;
            this.cBGreen.CheckedChanged += new System.EventHandler(this.cBGreen_CheckedChanged);
            // 
            // cBRed
            // 
            this.cBRed.AutoSize = true;
            this.cBRed.Location = new System.Drawing.Point(7, 20);
            this.cBRed.Name = "cBRed";
            this.cBRed.Size = new System.Drawing.Size(71, 17);
            this.cBRed.TabIndex = 0;
            this.cBRed.Text = "Красный";
            this.cBRed.UseVisualStyleBackColor = true;
            this.cBRed.CheckedChanged += new System.EventHandler(this.cBRed_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBStyle);
            this.groupBox2.Location = new System.Drawing.Point(420, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Стиль";
            // 
            // cBStyle
            // 
            this.cBStyle.AutoCompleteCustomSource.AddRange(new string[] {
            "Цельная",
            "Точечная"});
            this.cBStyle.FormattingEnabled = true;
            this.cBStyle.Items.AddRange(new object[] {
            "Сплошная",
            "Точечная"});
            this.cBStyle.Location = new System.Drawing.Point(16, 40);
            this.cBStyle.Name = "cBStyle";
            this.cBStyle.Size = new System.Drawing.Size(121, 21);
            this.cBStyle.TabIndex = 0;
            this.cBStyle.SelectedIndexChanged += new System.EventHandler(this.cBStyle_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nUDWidth);
            this.groupBox3.Location = new System.Drawing.Point(275, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Толщина";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // nUDWidth
            // 
            this.nUDWidth.Location = new System.Drawing.Point(6, 41);
            this.nUDWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDWidth.Name = "nUDWidth";
            this.nUDWidth.Size = new System.Drawing.Size(120, 20);
            this.nUDWidth.TabIndex = 1;
            this.nUDWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDWidth.ValueChanged += new System.EventHandler(this.nUDWidth_ValueChanged);
            // 
            // LineOpt
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(632, 239);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.plLineDraw);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LineOpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Опции линии";
            this.Load += new System.EventHandler(this.LineOpt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUDWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plLineDraw;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cBBlue;
        private System.Windows.Forms.CheckBox cBGreen;
        private System.Windows.Forms.CheckBox cBRed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cBStyle;
        private System.Windows.Forms.NumericUpDown nUDWidth;
    }
}