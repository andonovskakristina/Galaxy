using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bejeweled
{
    public partial class GameOverForm : Form
    {
        private static HighScores highScore;
        public GameOverForm()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            lblPoints.Parent = pictureBox1;
            lblPoints.BackColor = Color.Transparent;
            lblPoints.Text = String.Format("{0:00000}", Game.Points);
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            textBox1.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Game f = new Game();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MainMenu f = new MainMenu();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Trim().Length != 0)
                {
                    Score score = new Score(textBox1.Text, Game.Points);
                    highScore = new HighScores(this);
                    FileStream fileStream = new FileStream("HighScore.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                    highScore.ReadScores(fileStream);
                    highScore.sortHighScore(score);
                    highScore.Show();
                    fileStream.Close();
                    highScore.WriteScores("HighScore.txt");
                    fileStream.Close();
                }


            }
        }
    }
}
