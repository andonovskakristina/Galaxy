using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Media;
using Bejeweled.Properties;
using System.Threading.Tasks;

namespace Bejeweled
{
    public partial class SoundForm : Form
    {
        private SoundPlayer musicPlayer;
        Random r;
        int index;
        List<int> indeksi;
        int tick;
        bool first, second, third;
        public int Points;
        Timer delay;
        int ticks;
        Timer tri;
        int brojac;
        int clicked;
        public SoundForm()
        {
            InitializeComponent();
            r = new Random();
            clicked = -1;
            delay = new Timer();
            delay.Interval = 100;
            delay.Tick += delay_Tick;
            tri = new Timer();
            tri.Interval = 1000;
            tri.Tick += tri_Tick;
            Points = 0;
            brojac = 0;
            index = 0;
            tick = 0;
            indeksi = new List<int>();
            lblP.Text = "Points: " + Points.ToString();
            lvlTime.Text = "Time left: 25";
            Name = "";
            first = false;
            second = false;
            third = false;
            ticks = 0;
            pbFirst.Visible = pbSecond.Visible = pbThird.Visible = false;

        }

        private void tri_Tick(object sender, EventArgs e)
        {
            brojac++;

            if (brojac == 1)
            {
                tri.Stop();
                brojac = 0;
                refresh();
            }
        }

        private void delay_Tick(object sender, EventArgs e)
        {
            ticks++;
            ShowAnswer();
            if (ticks == 7)
            {
                delay.Stop();
                HideAnswer();
                ticks = 0;
            }

        }

        private void HideAnswer()
        {
            btnAnwser1.BackColor = System.Drawing.Color.Black;
            btnAnwser2.BackColor = System.Drawing.Color.Black;
            btnAnwser3.BackColor = System.Drawing.Color.Black;
        }

        private void ShowAnswer()
        {
            if (third)
            {
                btnAnwser3.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                if (clicked == 3)
                {
                    btnAnwser3.BackColor = System.Drawing.Color.Red;
                }
            }
            if (second)
            {
                btnAnwser2.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                if (clicked == 2)
                {
                    btnAnwser2.BackColor = System.Drawing.Color.Red;
                }
            }
            if (first)
            {
                btnAnwser1.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                if (clicked == 1)
                {
                    btnAnwser1.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void generateSong(int index)
        {
            first = second = third = false;

            if (index == 0)
            {
                musicPlayer = new SoundPlayer(Resources._505);
                btnAnwser1.Text = "505";
                btnAnwser2.Text = "Knee Socks";
                btnAnwser3.Text = "Do u wanna know?";
                first = true;
                second = third = false;
            }
            if (index == 1)
            {
                musicPlayer = new SoundPlayer(Resources.I_Want_To_Break_Free);
                btnAnwser1.Text = "A Kind Of Magic";
                btnAnwser2.Text = "I Want To Break Free";
                btnAnwser3.Text = "Another One Bites The Dust";
                second = true;
                first = third = false;
            }
            if (index == 2)
            {
                musicPlayer = new SoundPlayer(Resources.Love_of_my_life);
                btnAnwser1.Text = "Love of my life";
                btnAnwser2.Text = "I Want to Break Free";
                btnAnwser3.Text = "Another One Bites The Dust";
                first = true;
                second = third = false;
            }
            if (index == 3)
            {
                musicPlayer = new SoundPlayer(Resources.Englishman_In_New_York);
                btnAnwser1.Text = "Desert rose";
                btnAnwser2.Text = "Englishman in new york";
                btnAnwser3.Text = "Stolen car";
                second = true;
                first = third = false;
            }
            if (index == 4)
            {
                musicPlayer = new SoundPlayer(Resources.Toxicity);
                btnAnwser1.Text = "Prision song";
                btnAnwser2.Text = "Jet pilot";
                btnAnwser3.Text = "Toxicity";
                third = true;
                first = second = false;
            }
            if (index == 5)
            {
                musicPlayer = new SoundPlayer(Resources.Roxanne);
                btnAnwser1.Text = "Roxannee";
                btnAnwser2.Text = "Just one lifetime";
                btnAnwser3.Text = "Jet pilot";
                first = true;

                second = third = false;
            }
            if (index == 6)
            {
                musicPlayer = new SoundPlayer(Resources.Igri_Bez_Granici);
                btnAnwser1.Text = "Malechka";
                btnAnwser2.Text = "Igri bez granici";
                btnAnwser3.Text = "Polsko cvekje";
                second = true;
                first = third = false;
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            delay.Start();
            tri.Start();
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
            musicPlayer.Play();
            indeksi.Add(index);


        }
        private void btnAnwser1_Click(object sender, EventArgs e)
        {
            if (first)
            {
                Points += 300;
                lblP.Text = "Points: " + Points.ToString();
            }
            clicked = 1;
            delay.Start();
            tri.Start();
        }

        private void btnAnwser3_Click(object sender, EventArgs e)
        {

            if (third)
            {
                Points += 300;
                lblP.Text = "Points: " + Points.ToString();
            }
             clicked = 3;
            delay.Start();
            tri.Start();
        }

        private void btnAnwser2_Click(object sender, EventArgs e)
        {
            if (second)
            {
                Points += 300;
                lblP.Text = "Points: " + Points.ToString();
            }
            clicked = 2;
            delay.Start();
            tri.Start();
   
        }

        private void SoundForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            pbFirst.Visible = false;
            pbSecond.Visible = false;
            pbThird.Visible = false;
            btnSkip.Enabled = true;
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
                musicPlayer.Stop();
                DialogResult = DialogResult.OK;
              //  this.Close();
            }
        }

    }
}
