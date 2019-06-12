namespace Bejeweled
{
    partial class SnakeForm
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
            this.pbTimeLeft = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pbTimeLeft
            // 
            this.pbTimeLeft.Location = new System.Drawing.Point(13, 387);
            this.pbTimeLeft.Name = "pbTimeLeft";
            this.pbTimeLeft.Size = new System.Drawing.Size(364, 23);
            this.pbTimeLeft.TabIndex = 0;
            // 
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 422);
            this.Controls.Add(this.pbTimeLeft);
            this.Name = "SnakeForm";
            this.Text = "SnakeForm";
            this.Load += new System.EventHandler(this.SnakeForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbTimeLeft;
    }
}