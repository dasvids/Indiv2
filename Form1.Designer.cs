namespace Indiv2
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.PointsCount = new System.Windows.Forms.Label();
            this.HullCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.PlaceCountBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1239, 626);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(13, 645);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Build Hull";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.IndianRed;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(169, 645);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Black;
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Location = new System.Drawing.Point(325, 642);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(55, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "inTime";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Black;
            this.checkBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox2.Location = new System.Drawing.Point(325, 658);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(36, 17);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Fill";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // PointsCount
            // 
            this.PointsCount.AutoSize = true;
            this.PointsCount.ForeColor = System.Drawing.Color.Cornsilk;
            this.PointsCount.Location = new System.Drawing.Point(631, 646);
            this.PointsCount.Name = "PointsCount";
            this.PointsCount.Size = new System.Drawing.Size(13, 13);
            this.PointsCount.TabIndex = 5;
            this.PointsCount.Text = "0";
            // 
            // HullCount
            // 
            this.HullCount.AutoSize = true;
            this.HullCount.ForeColor = System.Drawing.Color.Cornsilk;
            this.HullCount.Location = new System.Drawing.Point(631, 664);
            this.HullCount.Name = "HullCount";
            this.HullCount.Size = new System.Drawing.Size(13, 13);
            this.HullCount.TabIndex = 6;
            this.HullCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(558, 646);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Points count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Cornsilk;
            this.label2.Location = new System.Drawing.Point(527, 662);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hull\'s pointss count:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1177, 645);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "RandPlace";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PlaceCountBox
            // 
            this.PlaceCountBox.Location = new System.Drawing.Point(1071, 647);
            this.PlaceCountBox.Name = "PlaceCountBox";
            this.PlaceCountBox.Size = new System.Drawing.Size(100, 20);
            this.PlaceCountBox.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.PlaceCountBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HullCount);
            this.Controls.Add(this.PointsCount);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label PointsCount;
        private System.Windows.Forms.Label HullCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox PlaceCountBox;
    }
}

