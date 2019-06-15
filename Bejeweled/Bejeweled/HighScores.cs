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
    public partial class HighScores : Form
    {
        List<Score> score;
        Form1 form;
        public HighScores()
        {
            InitializeComponent();
            score = new List<Score>(11);
        }
        public HighScores(Control f)
        {
            InitializeComponent();
            score = new List<Score>(11);
            form = (Form1)f;
        }
        public void sortHighScore(Score s)
        {
            if (score.Count < 10)
                score.Add(s);
            else
            {
                if (score[score.Count() - 1].Points < s.Points)
                {
                    score.Remove(score[score.Count() - 1]);
                    score.Add(s);
                }
            }
            if (score.Count() != 0)
                score.Sort((x, y) => y.Points.CompareTo(x.Points));
            lbRez.Items.Clear();
            for (int i = 0; i < score.Count(); i++)
            {
                lbRez.Items.Add(string.Format("{0}. {1}\t\t{2}", (i + 1), score[i].Name, score[i].Points));
            }
        }
        public List<Score> ReadScores(FileStream fileStream)
        {
            string line;
            List<Score> highScore = new List<Score>();
            try
            {

                TextReader sr = new StreamReader(fileStream);
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length >= 2) highScore.Add(new Score(parts[0], Convert.ToInt32(parts[1])));
                    line = sr.ReadLine();
                }
                sr.Close();
                score = highScore;
                if (score.Count() != 0)
                    score.Sort((x, y) => y.Points.CompareTo(x.Points));
                for (int i = 0; i < score.Count(); i++)
                {
                    lbRez.Items.Add(string.Format("{0}. {1}\t\t{2}", (i + 1), score[i].Name, score[i].Points));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);

            }

            return score;
        }
        public bool WriteScores(string fileName)
        {
            bool written = false;
            try
            {
                System.IO.File.Delete(@fileName);
                FileStream fileStream = new FileStream(@fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                TextWriter wr = new StreamWriter(fileStream);
                for (int i = 0; i < score.Count(); i++)
                {
                    wr.WriteLine(score[i].ToString());
                }
                wr.Close();
                fileStream.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return written;

        }

        private void HighScore_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HighScore_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Cover cover = new Cover();
            cover.ShowDialog();
            this.Close();
            
        }
    }
}
