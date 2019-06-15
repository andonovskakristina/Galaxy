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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblNumOfHits = new System.Windows.Forms.Label();
            this.lblVremeForFive = new System.Windows.Forms.Label();
            this.lblNumHits = new System.Windows.Forms.Label();
            this.lblTimeLeftForFive = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblHelpers = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblGameHover = new System.Windows.Forms.Label();
            this.lblSoundHover = new System.Windows.Forms.Label();
            this.lblAsociaciiHover = new System.Windows.Forms.Label();
            this.lblSnakeHover = new System.Windows.Forms.Label();
            this.lblSongsHover = new System.Windows.Forms.Label();
            this.lblHintHover = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.picAssociationsHelper = new System.Windows.Forms.PictureBox();
            this.picSnakeHelper = new System.Windows.Forms.PictureBox();
            this.picSongHelper = new System.Windows.Forms.PictureBox();
            this.picSound = new System.Windows.Forms.PictureBox();
            this.picHint = new System.Windows.Forms.PictureBox();
            this.picStart = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
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
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(459, 558);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 30);
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
            this.lblHelpers.Location = new System.Drawing.Point(147, 56);
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
            // lblGameHover
            // 
            this.lblGameHover.AutoSize = true;
            this.lblGameHover.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGameHover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGameHover.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblGameHover.Location = new System.Drawing.Point(537, 255);
            this.lblGameHover.Name = "lblGameHover";
            this.lblGameHover.Size = new System.Drawing.Size(39, 15);
            this.lblGameHover.TabIndex = 35;
            this.lblGameHover.Text = "game";
            this.lblGameHover.Visible = false;
            // 
            // lblSoundHover
            // 
            this.lblSoundHover.AutoSize = true;
            this.lblSoundHover.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSoundHover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSoundHover.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSoundHover.Location = new System.Drawing.Point(537, 334);
            this.lblSoundHover.Name = "lblSoundHover";
            this.lblSoundHover.Size = new System.Drawing.Size(80, 15);
            this.lblSoundHover.TabIndex = 34;
            this.lblSoundHover.Text = "Sound On/Off";
            this.lblSoundHover.Visible = false;
            this.lblSoundHover.Click += new System.EventHandler(this.lblSoundHover_Click);
            // 
            // lblAsociaciiHover
            // 
            this.lblAsociaciiHover.AutoSize = true;
            this.lblAsociaciiHover.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAsociaciiHover.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAsociaciiHover.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAsociaciiHover.Location = new System.Drawing.Point(235, -2);
            this.lblAsociaciiHover.Name = "lblAsociaciiHover";
            this.lblAsociaciiHover.Size = new System.Drawing.Size(61, 18);
            this.lblAsociaciiHover.TabIndex = 33;
            this.lblAsociaciiHover.Text = "surprise";
            this.lblAsociaciiHover.Visible = false;
            // 
            // lblSnakeHover
            // 
            this.lblSnakeHover.AutoSize = true;
            this.lblSnakeHover.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSnakeHover.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSnakeHover.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSnakeHover.Location = new System.Drawing.Point(149, -2);
            this.lblSnakeHover.Name = "lblSnakeHover";
            this.lblSnakeHover.Size = new System.Drawing.Size(134, 18);
            this.lblSnakeHover.TabIndex = 32;
            this.lblSnakeHover.Text = "earn extra seconds";
            this.lblSnakeHover.Visible = false;
            // 
            // lblSongsHover
            // 
            this.lblSongsHover.AutoSize = true;
            this.lblSongsHover.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSongsHover.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSongsHover.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSongsHover.Location = new System.Drawing.Point(108, -2);
            this.lblSongsHover.Name = "lblSongsHover";
            this.lblSongsHover.Size = new System.Drawing.Size(112, 18);
            this.lblSongsHover.TabIndex = 31;
            this.lblSongsHover.Text = "add extra points";
            this.lblSongsHover.Visible = false;
            // 
            // lblHintHover
            // 
            this.lblHintHover.AutoSize = true;
            this.lblHintHover.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHintHover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHintHover.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHintHover.Location = new System.Drawing.Point(558, 161);
            this.lblHintHover.Name = "lblHintHover";
            this.lblHintHover.Size = new System.Drawing.Size(29, 15);
            this.lblHintHover.TabIndex = 30;
            this.lblHintHover.Text = "Hint";
            this.lblHintHover.Visible = false;
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHome.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHome.Location = new System.Drawing.Point(555, 9);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(49, 18);
            this.lblHome.TabIndex = 37;
            this.lblHome.Text = "Home";
            this.lblHome.Visible = false;
            // 
            // picHome
            // 
            this.picHome.Image = global::Bejeweled.Properties.Resources.HomeIcon;
            this.picHome.Location = new System.Drawing.Point(558, 33);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(43, 38);
            this.picHome.TabIndex = 36;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.pictureBox2_Click_1);
            this.picHome.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.picHome.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // picAssociationsHelper
            // 
            this.picAssociationsHelper.Image = global::Bejeweled.Properties.Resources.MoonHelper;
            this.picAssociationsHelper.Location = new System.Drawing.Point(235, 19);
            this.picAssociationsHelper.Name = "picAssociationsHelper";
            this.picAssociationsHelper.Size = new System.Drawing.Size(45, 47);
            this.picAssociationsHelper.TabIndex = 21;
            this.picAssociationsHelper.TabStop = false;
            this.picAssociationsHelper.Click += new System.EventHandler(this.btnHelp_Click);
            this.picAssociationsHelper.MouseLeave += new System.EventHandler(this.picAssociationsHelper_MouseLeave);
            this.picAssociationsHelper.MouseHover += new System.EventHandler(this.picAssociationsHelper_MouseHover);
            // 
            // picSnakeHelper
            // 
            this.picSnakeHelper.Image = global::Bejeweled.Properties.Resources.StarHelper;
            this.picSnakeHelper.Location = new System.Drawing.Point(186, 19);
            this.picSnakeHelper.Name = "picSnakeHelper";
            this.picSnakeHelper.Size = new System.Drawing.Size(43, 49);
            this.picSnakeHelper.TabIndex = 20;
            this.picSnakeHelper.TabStop = false;
            this.picSnakeHelper.Click += new System.EventHandler(this.picSnakeHelper_Click);
            this.picSnakeHelper.MouseLeave += new System.EventHandler(this.picSnakeHelper_MouseLeave);
            this.picSnakeHelper.MouseHover += new System.EventHandler(this.picSnakeHelper_MouseHover);
            // 
            // picSongHelper
            // 
            this.picSongHelper.Image = global::Bejeweled.Properties.Resources.Sun;
            this.picSongHelper.Location = new System.Drawing.Point(131, 19);
            this.picSongHelper.Name = "picSongHelper";
            this.picSongHelper.Size = new System.Drawing.Size(49, 50);
            this.picSongHelper.TabIndex = 19;
            this.picSongHelper.TabStop = false;
            this.picSongHelper.Click += new System.EventHandler(this.button1_Click);
            this.picSongHelper.MouseLeave += new System.EventHandler(this.picSongHelper_MouseLeave);
            this.picSongHelper.MouseHover += new System.EventHandler(this.picSongHelper_MouseHover);
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
            this.picSound.MouseLeave += new System.EventHandler(this.picSound_MouseLeave);
            this.picSound.MouseHover += new System.EventHandler(this.picSound_MouseHover);
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
            this.picHint.MouseLeave += new System.EventHandler(this.picHint_MouseLeave);
            this.picHint.MouseHover += new System.EventHandler(this.picHint_MouseHover);
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
            this.picStart.MouseLeave += new System.EventHandler(this.picStart_MouseLeave_1);
            this.picStart.MouseHover += new System.EventHandler(this.picStart_MouseHover);
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
            this.Controls.Add(this.lblHome);
            this.Controls.Add(this.picHome);
            this.Controls.Add(this.lblGameHover);
            this.Controls.Add(this.lblSoundHover);
            this.Controls.Add(this.lblAsociaciiHover);
            this.Controls.Add(this.lblSnakeHover);
            this.Controls.Add(this.lblSongsHover);
            this.Controls.Add(this.lblHintHover);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Bejeweled";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
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
        private System.Windows.Forms.Label lblGameHover;
        private System.Windows.Forms.Label lblSoundHover;
        private System.Windows.Forms.Label lblAsociaciiHover;
        private System.Windows.Forms.Label lblSnakeHover;
        private System.Windows.Forms.Label lblSongsHover;
        private System.Windows.Forms.Label lblHintHover;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.Label lblHome;
    }
}

