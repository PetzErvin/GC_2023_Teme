namespace TriangulareOctectomie
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonFinishUp = new System.Windows.Forms.Button();
            this.buttonTriang = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonThreeColor = new System.Windows.Forms.Button();
            this.buttonArie = new System.Windows.Forms.Button();
            this.labelArie = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(16, 19);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1115, 559);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // buttonFinishUp
            // 
            this.buttonFinishUp.Location = new System.Drawing.Point(16, 588);
            this.buttonFinishUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFinishUp.Name = "buttonFinishUp";
            this.buttonFinishUp.Size = new System.Drawing.Size(127, 39);
            this.buttonFinishUp.TabIndex = 2;
            this.buttonFinishUp.Text = "Inchidere";
            this.buttonFinishUp.UseVisualStyleBackColor = true;
            this.buttonFinishUp.Click += new System.EventHandler(this.buttonFinishUp_Click);
            // 
            // buttonTriang
            // 
            this.buttonTriang.Location = new System.Drawing.Point(151, 591);
            this.buttonTriang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonTriang.Name = "buttonTriang";
            this.buttonTriang.Size = new System.Drawing.Size(100, 39);
            this.buttonTriang.TabIndex = 3;
            this.buttonTriang.Text = "Triangulare";
            this.buttonTriang.UseVisualStyleBackColor = true;
            this.buttonTriang.Click += new System.EventHandler(this.buttonTriang_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(575, 598);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 4;
            // 
            // buttonThreeColor
            // 
            this.buttonThreeColor.Location = new System.Drawing.Point(259, 593);
            this.buttonThreeColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonThreeColor.Name = "buttonThreeColor";
            this.buttonThreeColor.Size = new System.Drawing.Size(100, 39);
            this.buttonThreeColor.TabIndex = 6;
            this.buttonThreeColor.Text = "Trei-colorare";
            this.buttonThreeColor.UseVisualStyleBackColor = true;
            this.buttonThreeColor.Click += new System.EventHandler(this.buttonThreeColor_Click);
            // 
            // buttonArie
            // 
            this.buttonArie.Location = new System.Drawing.Point(367, 593);
            this.buttonArie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonArie.Name = "buttonArie";
            this.buttonArie.Size = new System.Drawing.Size(100, 39);
            this.buttonArie.TabIndex = 7;
            this.buttonArie.Text = "Aria";
            this.buttonArie.UseVisualStyleBackColor = true;
            this.buttonArie.Click += new System.EventHandler(this.buttonArie_Click);
            // 
            // labelArie
            // 
            this.labelArie.AutoSize = true;
            this.labelArie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelArie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelArie.Location = new System.Drawing.Point(475, 605);
            this.labelArie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArie.Name = "labelArie";
            this.labelArie.Size = new System.Drawing.Size(2, 22);
            this.labelArie.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 652);
            this.Controls.Add(this.labelArie);
            this.Controls.Add(this.buttonArie);
            this.Controls.Add(this.buttonThreeColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTriang);
            this.Controls.Add(this.buttonFinishUp);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonFinishUp;
        private System.Windows.Forms.Button buttonTriang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonThreeColor;
        private System.Windows.Forms.Button buttonArie;
        private System.Windows.Forms.Label labelArie;
    }
}