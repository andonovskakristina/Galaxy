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
        string Name;
        List<int> indeksi;
        Sound song;
        int tick;
        bool first, second, third;
        public int Points;
        public SoundForm()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            r = new Random();
            Points = 0;
            index = 0;
            tick = 0;
            indeksi = new List<int>();
            song = new Sound();
            lblP.Text = "Points: " + Points.ToString();
            lvlTime.Text = "Time left: 25";
            Name = "";
            first = false;
            second = false;
            third = false;
        
        }

    

        private void generateSong(int index)
        {
            first = second = third = false;

            if (index == 0)
            {
                soundPlayer = new SoundPlayer(Resources._505);
                Name = "505".ToLower();
                btnAnwser1.Text = "505";
                btnAnwser2.Text = "Why do you only when you're high";
                btnAnwser3.Text = "Do u wanna know?";
                first = true;
                second = third = false;
            }
            if (index == 1)
            {
                soundPlayer = new SoundPlayer(Resources.I_Want_To_Break_Free);
                Name = "I want to break free".ToLower();
                btnAnwser1.Text = "A Kind Of Magic";
                btnAnwser2.Text = "I Want To Break Free";
                btnAnwser3.Text = "Another One Bites The Dust";
                second = true;
                first = third = false;
            }
            if (index == 2)
            {
                soundPlayer = new SoundPlayer(Resources.Love_of_my_life);
                Name = "Love of my life".ToLower();
                btnAnwser1.Text = "Love of my life";
                btnAnwser2.Text = "I Want to Break Free";
                btnAnwser3.Text = "Another One Bites The Dust";
                first = true;
                second = third = false;
            }
            if (index == 3)
            {
                soundPlayer = new SoundPlayer(Resources.Englishman_In_New_York);
                Name = "Englishman in new york".ToLower();
                btnAnwser1.Text = "Desert rose";
                btnAnwser2.Text = "Englishman in new york";
                btnAnwser3.Text = "Stolen car";
                second = true;
                first = third = false;
            }
            if (index == 4)
            {
                soundPlayer = new SoundPlayer(Resources.Toxicity);
                Name = "Toxicity".ToLower();
                btnAnwser1.Text = "Prision song";
                btnAnwser2.Text = "Toxicity";
                btnAnwser3.Text = "Jet pilot";
                second = true;
                first = third = false;
            }
            if (index == 5)
            {
                soundPlayer = new SoundPlayer(Resources.Roxanne);
                Name = "Roxanne".ToLower();
                btnAnwser1.Text = "Roxannee";
                btnAnwser2.Text = "Just one lifetime";
                btnAnwser3.Text = "Jet pilot";
                first = true;
                second = third = false;
            }
            if (index == 6)
            {
                soundPlayer = new SoundPlayer(Resources.Igri_Bez_Granici);
                Name = "Igri bez granici".ToLower();
                btnAnwser1.Text = "Malechka";
                btnAnwser2.Text = "Igri bez granici";
                btnAnwser3.Text = "Polsko cvekje";
                second = true;
                first = third = false;
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
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
        }

        private void btnAnwser1_Click(object sender, EventArgs e)
        {
            if(first)
            {
              MessageBox.Show("Well done!!");
                Points += 300;
             lblP.Text = "Points: " + Points.ToString();

            }
            else
            {
                MessageBox.Show("Sorry,you missed :(" );
            }

            first = false;
            refresh();
        }

        private void btnAnwser3_Click(object sender, EventArgs e)
        {
            if (third)
            {
                MessageBox.Show("Well done!!");
                Points += 300;
                lblP.Text = "Points: " + Points.ToString();
            }
            else
            {
                MessageBox.Show("Sorry,you missed :(");
            }

            third = false;
            refresh();
        }

        private void btnAnwser2_Click(object sender, EventArgs e)
        {
            if (second)
            {
                MessageBox.Show("Well done!!");
                Points += 300;
                lblP.Text = "Points: " + Points.ToString();
            }
            else
            {
                MessageBox.Show("Sorry,you missed :(");
            }
            refresh();
            second = false;

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            timer1.Start();
            refresh();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            lvlTime.Text = "Time left: " + (25 - tick);
            if (tick == 25)
            {
                timer1.Stop();
                soundPlayer.Stop();
                MessageBox.Show("Game over!!");
                this.Close();
              
            }
        }

    }
}
