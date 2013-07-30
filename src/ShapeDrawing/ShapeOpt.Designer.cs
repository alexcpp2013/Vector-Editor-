namespace ShapeDrawing
{
    partial class ShapeOpt
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
            this.plDrawShapeCOlor = new System.Windows.Forms.Panel();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBStyleShape = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btColor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plDrawShapeCOlor
            // 
            this.plDrawShapeCOlor.BackColor = System.Drawing.Color.White;
            this.plDrawShapeCOlor.Dock = System.Windows.Forms.DockStyle.Left;
            this.plDrawShapeCOlor.ForeColor = System.Drawing.Color.White;
            this.plDrawShapeCOlor.Location = new System.Drawing.Point(0, 0);
            this.plDrawShapeCOlor.Name = "plDrawShapeCOlor";
            this.plDrawShapeCOlor.Size = new System.Drawing.Size(228, 178);
            this.plDrawShapeCOlor.TabIndex = 0;
            this.plDrawShapeCOlor.Paint += new System.Windows.Forms.PaintEventHandler(this.plDrawShapeCOlor_Paint);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(467, 12);
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
            this.btCancel.Location = new System.Drawing.Point(467, 64);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBStyleShape);
            this.groupBox1.Location = new System.Drawing.Point(234, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 75);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Стиль заполнения";
            // 
            // cBStyleShape
            // 
            this.cBStyleShape.FormattingEnabled = true;
            this.cBStyleShape.Items.AddRange(new object[] {
            "Обычный",
            "Клетка"});
            this.cBStyleShape.Location = new System.Drawing.Point(6, 19);
            this.cBStyleShape.Name = "cBStyleShape";
            this.cBStyleShape.Size = new System.Drawing.Size(121, 21);
            this.cBStyleShape.TabIndex = 0;
            this.cBStyleShape.SelectedIndexChanged += new System.EventHandler(this.cBStyleShape_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btColor);
            this.groupBox2.Location = new System.Drawing.Point(234, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 61);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Цвет";
            // 
            // btColor
            // 
            this.btColor.Location = new System.Drawing.Point(6, 19);
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(137, 23);
            this.btColor.TabIndex = 0;
            this.btColor.Text = "Изменить цвет";
            this.btColor.UseVisualStyleBackColor = true;
            this.btColor.Click += new System.EventHandler(this.btColor_Click);
            // 
            // ShapeOpt
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(563, 178);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.plDrawShapeCOlor);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ShapeOpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Опции фигуры";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plDrawShapeCOlor;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cBStyleShape;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btColor;
    }
}