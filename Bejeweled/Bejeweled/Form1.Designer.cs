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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblNumOfHits = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHint = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblVremeForFive = new System.Windows.Forms.Label();
            this.lblNumHits = new System.Windows.Forms.Label();
            this.lblTimeLeftForFive = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bejeweled.Properties.Resources.BackgroundPicture;
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(625, 535);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // btnHint
            // 
            this.btnHint.Location = new System.Drawing.Point(536, 26);
            this.btnHint.Name = "btnHint";
            this.btnHint.Size = new System.Drawing.Size(75, 23);
            this.btnHint.TabIndex = 7;
            this.btnHint.Text = "Hint";
            this.btnHint.UseVisualStyleBackColor = true;
            this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(536, 100);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(537, 145);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 9;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(536, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Play Song";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblVremeForFive
            // 
            this.lblVremeForFive.AutoSize = true;
            this.lblVremeForFive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblVremeForFive.Location = new System.Drawing.Point(531, 273);
            this.lblVremeForFive.Name = "lblVremeForFive";
            this.lblVremeForFive.Size = new System.Drawing.Size(64, 25);
            this.lblVremeForFive.TabIndex = 11;
            this.lblVremeForFive.Text = "label1";
            // 
            // lblNumHits
            // 
            this.lblNumHits.AutoSize = true;
            this.lblNumHits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNumHits.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumHits.Location = new System.Drawing.Point(540, 65);
            this.lblNumHits.Name = "lblNumHits";
            this.lblNumHits.Size = new System.Drawing.Size(51, 20);
            this.lblNumHits.TabIndex = 12;
            this.lblNumHits.Text = "label2";
            // 
            // lblTimeLeftForFive
            // 
            this.lblTimeLeftForFive.AutoSize = true;
            this.lblTimeLeftForFive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTimeLeftForFive.Location = new System.Drawing.Point(514, 239);
            this.lblTimeLeftForFive.Name = "lblTimeLeftForFive";
            this.lblTimeLeftForFive.Size = new System.Drawing.Size(98, 25);
            this.lblTimeLeftForFive.TabIndex = 13;
            this.lblTimeLeftForFive.Text = "Time Left ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 531);
            this.Controls.Add(this.lblTimeLeftForFive);
            this.Controls.Add(this.lblNumHits);
            this.Controls.Add(this.lblVremeForFive);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnHint);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNumOfHits);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblNumOfHits;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnHint;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblVremeForFive;
        private System.Windows.Forms.Label lblNumHits;
        private System.Windows.Forms.Label lblTimeLeftForFive;
    }
}

