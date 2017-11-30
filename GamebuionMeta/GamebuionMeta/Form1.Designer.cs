namespace GamebuionMeta
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonU = new System.Windows.Forms.Button();
            this.buttonD = new System.Windows.Forms.Button();
            this.buttonL = new System.Windows.Forms.Button();
            this.buttonR = new System.Windows.Forms.Button();
            this.buttonA = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(85, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 128);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonU
            // 
            this.buttonU.Location = new System.Drawing.Point(34, 46);
            this.buttonU.Name = "buttonU";
            this.buttonU.Size = new System.Drawing.Size(23, 23);
            this.buttonU.TabIndex = 1;
            this.buttonU.Text = "U";
            this.buttonU.UseVisualStyleBackColor = true;
            this.buttonU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonU_MouseDown);
            this.buttonU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonU_MouseUp);
            // 
            // buttonD
            // 
            this.buttonD.Location = new System.Drawing.Point(34, 88);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(23, 23);
            this.buttonD.TabIndex = 2;
            this.buttonD.Text = "D";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonD_MouseDown);
            this.buttonD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonD_MouseUp);
            // 
            // buttonL
            // 
            this.buttonL.Location = new System.Drawing.Point(12, 67);
            this.buttonL.Name = "buttonL";
            this.buttonL.Size = new System.Drawing.Size(23, 23);
            this.buttonL.TabIndex = 3;
            this.buttonL.Text = "L";
            this.buttonL.UseVisualStyleBackColor = true;
            this.buttonL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonL_MouseDown);
            this.buttonL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonL_MouseUp);
            // 
            // buttonR
            // 
            this.buttonR.Location = new System.Drawing.Point(56, 67);
            this.buttonR.Name = "buttonR";
            this.buttonR.Size = new System.Drawing.Size(23, 23);
            this.buttonR.TabIndex = 4;
            this.buttonR.Text = "R";
            this.buttonR.UseVisualStyleBackColor = true;
            this.buttonR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonR_MouseDown);
            this.buttonR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonR_MouseUp);
            // 
            // buttonA
            // 
            this.buttonA.Location = new System.Drawing.Point(251, 67);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(23, 23);
            this.buttonA.TabIndex = 5;
            this.buttonA.Text = "A";
            this.buttonA.UseVisualStyleBackColor = true;
            // 
            // buttonB
            // 
            this.buttonB.Location = new System.Drawing.Point(280, 46);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(23, 23);
            this.buttonB.TabIndex = 6;
            this.buttonB.Text = "B";
            this.buttonB.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(85, 159);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(46, 23);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(199, 159);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(46, 23);
            this.buttonSelect.TabIndex = 8;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 10;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Motorwerk", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "GAMEBUINO meta";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 194);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.buttonR);
            this.Controls.Add(this.buttonL);
            this.Controls.Add(this.buttonD);
            this.Controls.Add(this.buttonU);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonU;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Button buttonL;
        private System.Windows.Forms.Button buttonR;
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Label label1;
    }
}

