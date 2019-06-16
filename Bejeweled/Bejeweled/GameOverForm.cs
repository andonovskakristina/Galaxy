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
        bool flag;
        public GameOverForm()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            lblPoints.Parent = pictureBox1;
            lblPoints.BackColor = Color.Transparent;
            lblPoints.Text = String.Format("{0:00000}", Game.Points);
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            textBox1.Focus();
            flag = true;

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {   if (textBox1.Text.Trim().Length != 0)
            {
                    Score score = new Score(textBox1.Text, Game.Points);
                    HighScores highScore = new HighScores(Parent);
                    FileStream fileStream = new FileStream("HighScores.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                    highScore.ReadScores(fileStream);
                    highScore.sortHighScore(score);
                   // highScore.Show();
                    fileStream.Close();
                    highScore.WriteScores("HighScores.txt");
                    fileStream.Close();
                
            }
            Game  f = new Game();
            this.Hide();
            f.ShowDialog();
            //this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
              if (textBox1.Text.Trim().Length != 0)
                {
                    Score score = new Score(textBox1.Text, Game.Points);
                    HighScores highScore = new HighScores(Parent);
                    FileStream fileStream = new FileStream("HighScores.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                    highScore.ReadScores(fileStream);
                    highScore.sortHighScore(score);
                    ///highScore.Show();
                    fileStream.Close();
                    highScore.WriteScores("HighScores.txt");
                    fileStream.Close();

                
            }
            MainMenu f = new MainMenu();
            this.Hide();
            f.ShowDialog();
           // this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Trim().Length != 0)
                {
                    Score score = new Score(textBox1.Text, Game.Points);
                    HighScores highScore = new HighScores(Parent);
                    FileStream fileStream = new FileStream("HighScores.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                    highScore.ReadScores(fileStream);
                    highScore.sortHighScore(score);
                    highScore.ShowDialog();
                    fileStream.Close();
                    highScore.WriteScores("HighScores.txt");
                    fileStream.Close();
                    this.Hide();
                   // this.Close();
                }
                else
                {
                    this.Hide();
                    MainMenu c = new MainMenu();
                    c.ShowDialog();
                  //  this.Close();
                }

            }
        }
    }
}
