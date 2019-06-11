using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Media;
using Bejeweled.Properties;

namespace Bejeweled
{
    public partial class SoundForm : Form
    {
        private SoundPlayer soundPlayer;
        Random r;
        int index;
        int points;
        string Name;
        List<int> indeksi;
        Sound song;
        int tick;

        public SoundForm()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            r = new Random();
            index = 0;
            points = 0;
            tick = 0;
            indeksi = new List<int>();
            song = new Sound();
            Name = "";
            lblPoeni.Text = "Current points: " + points.ToString();
            lblTime.Text = "Time left: 25";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSolution.Text = "";
            index = r.Next(0, 7);
            if (indeksi.Contains(index))
            {
                while (indeksi.Contains(index))
                {
                    index = r.Next(0, 7);
                }
            }
            generateSong(index);
            soundPlayer.Play();
            txtSolution.Focus();
            timer1.Start();

        }

        private void generateSong(int index)
        {

            if (index == 0)
            {
                soundPlayer = new SoundPlayer(Resources._505);
                Name = "505".ToLower();
            }
            if (index == 1)
            {
                soundPlayer = new SoundPlayer(Resources.I_Want_To_Break_Free);
                Name = "I want to break free".ToLower();
            }
            if (index == 2)
            {
                soundPlayer = new SoundPlayer(Resources.Love_of_my_life);
                Name = "Love of my life".ToLower();
            }
            if (index == 3)
            {
                soundPlayer = new SoundPlayer(Resources.Englishman_In_New_York);
                Name = "Englishman in new york".ToLower();
            }
            if (index == 4)
            {
                soundPlayer = new SoundPlayer(Resources.Toxicity);
                Name = "Toxicity".ToLower();
            }
            if (index == 5)
            {
                soundPlayer = new SoundPlayer(Resources.Roxanne);
                Name = "Roxanne".ToLower();
            }
            if (index == 6)
            {
                soundPlayer = new SoundPlayer(Resources.Igri_Bez_Granici);
                Name = "Igri bez granici".ToLower();
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            txtSolution.Text = "";
            index = r.Next(0, 7);
            if (indeksi.Contains(index))
            {
                while (indeksi.Contains(index))
                {
                    index = r.Next(0, 7);
                }
            }
            generateSong(index);
            soundPlayer.Play();
            indeksi.Add(index);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            if (txtSolution.Text != "")
            {
                if (Name.ToLower().Equals(txtSolution.Text.ToLower()))
                {
                    MessageBox.Show("Well done!!");
                    points += 5;
                    lblPoeni.Text = "Current points: " + points.ToString();
                }
                else
                {
                    MessageBox.Show("Sorry,you missed :(");
                }
            }
            else
            {
                MessageBox.Show("Vnesete odgovor,pa kliknete na Guess!");
            }
            txtSolution.Text = "";
            index = r.Next(0, 7);
            if (indeksi.Contains(index))
            {
                while (indeksi.Contains(index))
                {
                    index = r.Next(0, 7);
                }
            }
            generateSong(index);
            soundPlayer.Play();
            indeksi.Add(index);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            lblTime.Text = "Time left: " + (25 - tick);
            if (tick == 25)
            {
                timer1.Stop();
                lblTime.Visible = false;
                MessageBox.Show("Game over!!");
                this.Close();
              
            }
        }
    }
}
