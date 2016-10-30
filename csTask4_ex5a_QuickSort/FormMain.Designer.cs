namespace csTask4_ex5a_QuickSort
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.pbDraw = new System.Windows.Forms.PictureBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.updwnSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.pnlDraw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDraw)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updwnSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDraw
            // 
            this.pnlDraw.Controls.Add(this.pbDraw);
            this.pnlDraw.Location = new System.Drawing.Point(12, 47);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(980, 620);
            this.pnlDraw.TabIndex = 0;
            // 
            // pbDraw
            // 
            this.pbDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDraw.Location = new System.Drawing.Point(0, 0);
            this.pbDraw.Name = "pbDraw";
            this.pbDraw.Size = new System.Drawing.Size(980, 620);
            this.pbDraw.TabIndex = 0;
            this.pbDraw.TabStop = false;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(586, 11);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(80, 23);
            this.btnSort.TabIndex = 1;
            this.btnSort.Text = "Сортировать";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 11);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(80, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Создать";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSpeed);
            this.panel1.Controls.Add(this.updwnSpeed);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.btnSort);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 41);
            this.panel1.TabIndex = 4;
            // 
            // updwnSpeed
            // 
            this.updwnSpeed.Location = new System.Drawing.Point(322, 14);
            this.updwnSpeed.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.updwnSpeed.Name = "updwnSpeed";
            this.updwnSpeed.Size = new System.Drawing.Size(120, 20);
            this.updwnSpeed.TabIndex = 3;
            this.updwnSpeed.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(208, 16);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(58, 13);
            this.lblSpeed.TabIndex = 4;
            this.lblSpeed.Text = "Скорость:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 679);
            this.Controls.Add(this.pnlDraw);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(5, 5);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Быстрая сортировка Хоара";
            this.pnlDraw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDraw)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updwnSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.PictureBox pbDraw;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown updwnSpeed;
        private System.Windows.Forms.Label lblSpeed;
    }
}

