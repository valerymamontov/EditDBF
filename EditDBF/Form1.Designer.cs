namespace EditDBF
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnOpenDBF = new System.Windows.Forms.Button();
            this.btnEditDBF = new System.Windows.Forms.Button();
            this.btnSaveDBF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tBcountRows1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBcountRows2 = new System.Windows.Forms.TextBox();
            this.tBMIAC = new System.Windows.Forms.TextBox();
            this.tBDesc = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(319, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(337, 367);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(690, 101);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(337, 367);
            this.dataGridView2.TabIndex = 1;
            // 
            // btnOpenDBF
            // 
            this.btnOpenDBF.Location = new System.Drawing.Point(319, 58);
            this.btnOpenDBF.Name = "btnOpenDBF";
            this.btnOpenDBF.Size = new System.Drawing.Size(130, 23);
            this.btnOpenDBF.TabIndex = 2;
            this.btnOpenDBF.Text = "1. Выбрать файл";
            this.btnOpenDBF.UseVisualStyleBackColor = true;
            this.btnOpenDBF.Click += new System.EventHandler(this.btnOpenDBF_Click);
            // 
            // btnEditDBF
            // 
            this.btnEditDBF.Location = new System.Drawing.Point(618, 58);
            this.btnEditDBF.Name = "btnEditDBF";
            this.btnEditDBF.Size = new System.Drawing.Size(126, 23);
            this.btnEditDBF.TabIndex = 3;
            this.btnEditDBF.Text = "2. Обработать";
            this.btnEditDBF.UseVisualStyleBackColor = true;
            this.btnEditDBF.Click += new System.EventHandler(this.btnEditDBF_Click);
            // 
            // btnSaveDBF
            // 
            this.btnSaveDBF.Location = new System.Drawing.Point(879, 58);
            this.btnSaveDBF.Name = "btnSaveDBF";
            this.btnSaveDBF.Size = new System.Drawing.Size(148, 23);
            this.btnSaveDBF.TabIndex = 4;
            this.btnSaveDBF.Text = "3. Сохранить";
            this.btnSaveDBF.UseVisualStyleBackColor = true;
            this.btnSaveDBF.Click += new System.EventHandler(this.btnSaveDBF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Количество записей:";
            // 
            // tBcountRows1
            // 
            this.tBcountRows1.BackColor = System.Drawing.SystemColors.Control;
            this.tBcountRows1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBcountRows1.Location = new System.Drawing.Point(436, 484);
            this.tBcountRows1.Name = "tBcountRows1";
            this.tBcountRows1.Size = new System.Drawing.Size(100, 13);
            this.tBcountRows1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(690, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Обработано записей:";
            // 
            // tBcountRows2
            // 
            this.tBcountRows2.BackColor = System.Drawing.SystemColors.Control;
            this.tBcountRows2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBcountRows2.Location = new System.Drawing.Point(812, 484);
            this.tBcountRows2.Name = "tBcountRows2";
            this.tBcountRows2.Size = new System.Drawing.Size(100, 13);
            this.tBcountRows2.TabIndex = 8;
            // 
            // tBMIAC
            // 
            this.tBMIAC.BackColor = System.Drawing.SystemColors.Control;
            this.tBMIAC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBMIAC.Location = new System.Drawing.Point(111, 25);
            this.tBMIAC.Multiline = true;
            this.tBMIAC.Name = "tBMIAC";
            this.tBMIAC.Size = new System.Drawing.Size(187, 91);
            this.tBMIAC.TabIndex = 9;
            // 
            // tBDesc
            // 
            this.tBDesc.BackColor = System.Drawing.SystemColors.Control;
            this.tBDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBDesc.Location = new System.Drawing.Point(27, 122);
            this.tBDesc.Multiline = true;
            this.tBDesc.Name = "tBDesc";
            this.tBDesc.Size = new System.Drawing.Size(262, 375);
            this.tBDesc.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 532);
            this.Controls.Add(this.tBDesc);
            this.Controls.Add(this.tBMIAC);
            this.Controls.Add(this.tBcountRows2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBcountRows1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveDBF);
            this.Controls.Add(this.btnEditDBF);
            this.Controls.Add(this.btnOpenDBF);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Обработка DBF-файла для ДЛО";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnOpenDBF;
        private System.Windows.Forms.Button btnEditDBF;
        private System.Windows.Forms.Button btnSaveDBF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBcountRows1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBcountRows2;
        private System.Windows.Forms.TextBox tBMIAC;
        private System.Windows.Forms.TextBox tBDesc;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

