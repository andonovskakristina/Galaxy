namespace Bejeweled
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
            this.components = new System.ComponentModel.Container();
            this.lblVremeForFive = new System.Windows.Forms.Label();
            this.btnHint = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblNumOfHits = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblVremeForFive
            // 
            this.lblVremeForFive.AutoSize = true;
            this.lblVremeForFive.Location = new System.Drawing.Point(13, 398);
            this.lblVremeForFive.Name = "lblVremeForFive";
            this.lblVremeForFive.Size = new System.Drawing.Size(35, 13);
            this.lblVremeForFive.TabIndex = 0;
            this.lblVremeForFive.Text = "label1";
            // 
            // btnHint
            // 
            this.btnHint.Location = new System.Drawing.Point(534, 52);
            this.btnHint.Name = "btnHint";
            this.btnHint.Size = new System.Drawing.Size(77, 25);
            this.btnHint.TabIndex = 1;
            this.btnHint.Text = "Hint";
            this.btnHint.UseVisualStyleBackColor = true;
            this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblNumOfHits
            // 
            this.lblNumOfHits.AutoSize = true;
            this.lblNumOfHits.Location = new System.Drawing.Point(534, 84);
            this.lblNumOfHits.Name = "lblNumOfHits";
            this.lblNumOfHits.Size = new System.Drawing.Size(0, 13);
            this.lblNumOfHits.TabIndex = 2;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(534, 128);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 531);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lblNumOfHits);
            this.Controls.Add(this.btnHint);
            this.Controls.Add(this.lblVremeForFive);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVremeForFive;
        private System.Windows.Forms.Button btnHint;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblNumOfHits;
        private System.Windows.Forms.Button btnPause;
    }
}

