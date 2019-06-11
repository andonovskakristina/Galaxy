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
            this.lblVremeForFive = new System.Windows.Forms.Label();
            this.lblNumHits = new System.Windows.Forms.Label();
            this.lblTimeLeftForFive = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblHelpers = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.picAssociationsHelper = new System.Windows.Forms.PictureBox();
            this.picSnakeHelper = new System.Windows.Forms.PictureBox();
            this.picSongHelper = new System.Windows.Forms.PictureBox();
            this.picSound = new System.Windows.Forms.PictureBox();
            this.picHint = new System.Windows.Forms.PictureBox();
            this.picStart = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAssociationsHelper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSnakeHelper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSongHelper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStart)).BeginInit();
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
            // lblVremeForFive
            // 
            this.lblVremeForFive.AutoSize = true;
            this.lblVremeForFive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblVremeForFive.Location = new System.Drawing.Point(547, 484);
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
            this.lblNumHits.Location = new System.Drawing.Point(577, 176);
            this.lblNumHits.Name = "lblNumHits";
            this.lblNumHits.Size = new System.Drawing.Size(18, 20);
            this.lblNumHits.TabIndex = 12;
            this.lblNumHits.Text = "3";
            // 
            // lblTimeLeftForFive
            // 
            this.lblTimeLeftForFive.AutoSize = true;
            this.lblTimeLeftForFive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTimeLeftForFive.Location = new System.Drawing.Point(527, 442);
            this.lblTimeLeftForFive.Name = "lblTimeLeftForFive";
            this.lblTimeLeftForFive.Size = new System.Drawing.Size(98, 25);
            this.lblTimeLeftForFive.TabIndex = 13;
            this.lblTimeLeftForFive.Text = "Time Left ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MidnightBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(459, 563);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "New Game";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblHelpers
            // 
            this.lblHelpers.AutoSize = true;
            this.lblHelpers.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblHelpers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHelpers.Location = new System.Drawing.Point(152, 56);
            this.lblHelpers.Name = "lblHelpers";
            this.lblHelpers.Size = new System.Drawing.Size(105, 29);
            this.lblHelpers.TabIndex = 18;
            this.lblHelpers.Text = "Helpers";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPoints.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPoints.Location = new System.Drawing.Point(362, 32);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(112, 39);
            this.lblPoints.TabIndex = 22;
            this.lblPoints.Text = "00000";
            // 
            // picAssociationsHelper
            // 
            this.picAssociationsHelper.Image = global::Bejeweled.Properties.Resources.MoonHelper;
            this.picAssociationsHelper.Location = new System.Drawing.Point(235, 15);
            this.picAssociationsHelper.Name = "picAssociationsHelper";
            this.picAssociationsHelper.Size = new System.Drawing.Size(45, 47);
            this.picAssociationsHelper.TabIndex = 21;
            this.picAssociationsHelper.TabStop = false;
            this.picAssociationsHelper.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // picSnakeHelper
            // 
            this.picSnakeHelper.Image = global::Bejeweled.Properties.Resources.StarHelper;
            this.picSnakeHelper.Location = new System.Drawing.Point(186, 13);
            this.picSnakeHelper.Name = "picSnakeHelper";
            this.picSnakeHelper.Size = new System.Drawing.Size(43, 49);
            this.picSnakeHelper.TabIndex = 20;
            this.picSnakeHelper.TabStop = false;
            this.picSnakeHelper.Click += new System.EventHandler(this.picSnakeHelper_Click);
            // 
            // picSongHelper
            // 
            this.picSongHelper.Image = global::Bejeweled.Properties.Resources.Sun;
            this.picSongHelper.Location = new System.Drawing.Point(131, 12);
            this.picSongHelper.Name = "picSongHelper";
            this.picSongHelper.Size = new System.Drawing.Size(49, 50);
            this.picSongHelper.TabIndex = 19;
            this.picSongHelper.TabStop = false;
            this.picSongHelper.Click += new System.EventHandler(this.button1_Click);
            // 
            // picSound
            // 
            this.picSound.Image = global::Bejeweled.Properties.Resources.SoundOn;
            this.picSound.Location = new System.Drawing.Point(558, 352);
            this.picSound.Name = "picSound";
            this.picSound.Size = new System.Drawing.Size(37, 38);
            this.picSound.TabIndex = 17;
            this.picSound.TabStop = false;
            this.picSound.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // picHint
            // 
            this.picHint.Image = global::Bejeweled.Properties.Resources.Hint;
            this.picHint.Location = new System.Drawing.Point(558, 185);
            this.picHint.Name = "picHint";
            this.picHint.Size = new System.Drawing.Size(37, 35);
            this.picHint.TabIndex = 16;
            this.picHint.TabStop = false;
            this.picHint.Click += new System.EventHandler(this.btnHint_Click);
            // 
            // picStart
            // 
            this.picStart.Image = global::Bejeweled.Properties.Resources.Pause;
            this.picStart.Location = new System.Drawing.Point(558, 273);
            this.picStart.Name = "picStart";
            this.picStart.Size = new System.Drawing.Size(37, 35);
            this.picStart.TabIndex = 15;
            this.picStart.TabStop = false;
            this.picStart.Click += new System.EventHandler(this.picStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bejeweled.Properties.Resources.BackgroundImage;
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(625, 618);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 608);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.picAssociationsHelper);
            this.Controls.Add(this.picSnakeHelper);
            this.Controls.Add(this.picSongHelper);
            this.Controls.Add(this.lblHelpers);
            this.Controls.Add(this.picSound);
            this.Controls.Add(this.picHint);
            this.Controls.Add(this.picStart);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblTimeLeftForFive);
            this.Controls.Add(this.lblNumHits);
            this.Controls.Add(this.lblVremeForFive);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNumOfHits);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picAssociationsHelper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSnakeHelper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSongHelper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblNumOfHits;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblVremeForFive;
        private System.Windows.Forms.Label lblNumHits;
        private System.Windows.Forms.Label lblTimeLeftForFive;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox picStart;
        private System.Windows.Forms.PictureBox picHint;
        private System.Windows.Forms.PictureBox picSound;
        private System.Windows.Forms.Label lblHelpers;
        private System.Windows.Forms.PictureBox picSongHelper;
        private System.Windows.Forms.PictureBox picSnakeHelper;
        private System.Windows.Forms.PictureBox picAssociationsHelper;
        private System.Windows.Forms.Label lblPoints;
    }
}

