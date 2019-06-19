using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bejeweled
{
    public partial class HighScores : Form
    {
        List<Score> score;
        GameOverForm form;
        public HighScores(GameOverForm f)
        {
            InitializeComponent();
            score = new List<Score>(11);
            form = f;
        }
        public HighScores()
        {
            InitializeComponent();
            score = new List<Score>(11);
            form = null;
        }

     

        public void sortHighScore(Score s)
        {
            if (score.Count < 10)
                score.Add(s);
            else
            {
                if (score[score.Count() - 1].Points < s.Points)
                {
                    score.RemoveAt(score.Count() - 1);
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

            List<Score> highScore = new List<Score>();
            using (var reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length >= 2)
                        highScore.Add(new Score(parts[0], Convert.ToInt32(parts[1])));
                }
            }
            score = highScore;
            if (score.Count() != 0)
                score.Sort((x, y) => y.Points.CompareTo(x.Points));
            for (int i = 0; i < score.Count(); i++)
            {
                lbRez.Items.Add(string.Format("{0}. {1}\t\t{2}", (i + 1), score[i].Name, score[i].Points));
            }
            return score;
        }

        public bool WriteScores(string fileName)
        {
            bool written = false;
            try
            {

                File.Delete(fileName);
                FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
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
            if (form != null)
                form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (form != null)
            {
                form.Hide();
            }
            this.Hide();          
            MainMenu cover = new MainMenu();
            cover.ShowDialog();
            this.Close();

        }
    }
}
