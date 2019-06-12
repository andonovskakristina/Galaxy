namespace Bejeweled
{
    partial class SoundForm
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
            this.btnAnwser3 = new System.Windows.Forms.Button();
            this.btnAnwser2 = new System.Windows.Forms.Button();
            this.btnAnwser1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lvlTime = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnwser3
            // 
            this.btnAnwser3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAnwser3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAnwser3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnwser3.Location = new System.Drawing.Point(73, 396);
            this.btnAnwser3.Name = "btnAnwser3";
            this.btnAnwser3.Size = new System.Drawing.Size(169, 32);
            this.btnAnwser3.TabIndex = 29;
            this.btnAnwser3.UseVisualStyleBackColor = false;
            this.btnAnwser3.Click += new System.EventHandler(this.btnAnwser3_Click);
            // 
            // btnAnwser2
            // 
            this.btnAnwser2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAnwser2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAnwser2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnwser2.Location = new System.Drawing.Point(73, 434);
            this.btnAnwser2.Name = "btnAnwser2";
            this.btnAnwser2.Size = new System.Drawing.Size(169, 32);
            this.btnAnwser2.TabIndex = 28;
            this.btnAnwser2.UseVisualStyleBackColor = false;
            this.btnAnwser2.Click += new System.EventHandler(this.btnAnwser2_Click);
            // 
            // btnAnwser1
            // 
            this.btnAnwser1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAnwser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAnwser1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnwser1.Location = new System.Drawing.Point(73, 358);
            this.btnAnwser1.Name = "btnAnwser1";
            this.btnAnwser1.Size = new System.Drawing.Size(169, 32);
            this.btnAnwser1.TabIndex = 27;
            this.btnAnwser1.UseVisualStyleBackColor = false;
            this.btnAnwser1.Click += new System.EventHandler(this.btnAnwser1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(122, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Your guess:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bejeweled.Properties.Resources.guessTheSong;
            this.pictureBox1.Location = new System.Drawing.Point(46, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 225);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSkip.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSkip.Location = new System.Drawing.Point(204, 37);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(66, 33);
            this.btnSkip.TabIndex = 24;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlay.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPlay.Location = new System.Drawing.Point(46, 37);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(62, 32);
            this.btnPlay.TabIndex = 23;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::Bejeweled.Properties.Resources.Black;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(311, 540);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lvlTime
            // 
            this.lvlTime.AutoSize = true;
            this.lvlTime.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lvlTime.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lvlTime.Location = new System.Drawing.Point(43, 515);
            this.lvlTime.Name = "lvlTime";
            this.lvlTime.Size = new System.Drawing.Size(0, 16);
            this.lvlTime.TabIndex = 30;
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblP.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblP.Location = new System.Drawing.Point(201, 515);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(0, 16);
            this.lblP.TabIndex = 31;
            // 
            // SoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 540);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.lvlTime);
            this.Controls.Add(this.btnAnwser3);
            this.Controls.Add(this.btnAnwser2);
            this.Controls.Add(this.btnAnwser1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pictureBox2);
            this.Name = "SoundForm";
            this.Text = "SoundForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnwser3;
        private System.Windows.Forms.Button btnAnwser2;
        private System.Windows.Forms.Button btnAnwser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lvlTime;
        private System.Windows.Forms.Label lblP;
    }
}