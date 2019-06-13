namespace Bejeweled
{
    partial class High_Scores_From
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
            this.label3 = new System.Windows.Forms.Label();
            this.thanks = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.saveScore = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "You made it in the top 5!";
            // 
            // thanks
            // 
            this.thanks.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.thanks.Location = new System.Drawing.Point(130, 144);
            this.thanks.Name = "thanks";
            this.thanks.Size = new System.Drawing.Size(82, 23);
            this.thanks.TabIndex = 11;
            this.thanks.Text = "No thanks.";
            this.thanks.UseVisualStyleBackColor = true;
            this.thanks.Click += new System.EventHandler(this.thanks_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(21, 105);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(191, 20);
            this.name.TabIndex = 10;
            // 
            // saveScore
            // 
            this.saveScore.Location = new System.Drawing.Point(21, 144);
            this.saveScore.Name = "saveScore";
            this.saveScore.Size = new System.Drawing.Size(84, 23);
            this.saveScore.TabIndex = 9;
            this.saveScore.Text = "Save";
            this.saveScore.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Enter your name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Congratulations!";
            // 
            // High_Scores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 199);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.thanks);
            this.Controls.Add(this.name);
            this.Controls.Add(this.saveScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "High_Scores";
            this.Text = "High Scores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button thanks;
        public System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button saveScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}