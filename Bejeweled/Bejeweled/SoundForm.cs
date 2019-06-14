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
        private SoundPlayer soundPlayer;
       // private SoundPlayer musicPlayer;
        Random r;
        int index;
        List<int> indeksi;
        Sound song;
        int tick;
        bool first, second, third;
        public int Points;
        Timer delay;
        int ticks;

        public SoundForm()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            r = new Random();
            delay = new Timer();
            delay.Interval = 1000;
            delay.Tick += delay_Tick;
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
            ticks = 0;
           pbFirst.Visible = pbSecond.Visible = pbThird.Visible = false;
        }

        private void delay_Tick(object sender, EventArgs e)
        {
            // timer1.Stop();
            ticks++;
            if(ticks == 9909)
            {
                delay.Stop();
            }

        }

        private void generateSong(int index)
        {
            first = second = third = false;
          pbFirst.Visible = pbSecond.Visible = pbThird.Visible = false;
            if (index == 0)
            {
                soundPlayer = new SoundPlayer(Resources._505);
                btnAnwser1.Text = "505";
                btnAnwser2.Text = "Why do you only when you're high";
                btnAnwser3.Text = "Do u wanna know?";
                first = true;
                pbFirst.Image = Resources.blackCorrectMarkSmall;
                pbSecond.Image = Resources.xMarkSmall;
                pbThird.Image = Resources.xMarkSmall;

                second = third = false;
            }
            if (index == 1)
            {
                soundPlayer = new SoundPlayer(Resources.I_Want_To_Break_Free);
                btnAnwser1.Text = "A Kind Of Magic";
                btnAnwser2.Text = "I Want To Break Free";
                btnAnwser3.Text = "Another One Bites The Dust";
                second = true;
                pbFirst.Image = Resources.xMarkSmall;
                pbSecond.Image = Resources.blackCorrectMarkSmall;
                pbThird.Image = Resources.xMarkSmall;
                first = third = false;
            }
            if (index == 2)
            {
                soundPlayer = new SoundPlayer(Resources.Love_of_my_life);
                btnAnwser1.Text = "Love of my life";
                btnAnwser2.Text = "I Want to Break Free";
                btnAnwser3.Text = "Another One Bites The Dust";
                first = true;
                pbFirst.Image = Resources.blackCorrectMarkSmall;
                pbSecond.Image = Resources.xMarkSmall;
                pbThird.Image = Resources.xMarkSmall;
                second = third = false;
            }
            if (index == 3)
            {
                soundPlayer = new SoundPlayer(Resources.Englishman_In_New_York);
                btnAnwser1.Text = "Desert rose";
                btnAnwser2.Text = "Englishman in new york";
                btnAnwser3.Text = "Stolen car";
                second = true;
                pbFirst.Image = Resources.xMarkSmall;
                pbSecond.Image = Resources.blackCorrectMarkSmall;
                pbThird.Image = Resources.xMarkSmall;
                first = third = false;
            }
            if (index == 4)
            {
                soundPlayer = new SoundPlayer(Resources.Toxicity);
                btnAnwser1.Text = "Prision song";
                btnAnwser2.Text = "Jet pilot";
                btnAnwser3.Text = "Toxicity";
                third = true;
                pbFirst.Image = Resources.xMarkSmall;
                pbSecond.Image = Resources.xMarkSmall;
                pbThird.Image = Resources.blackCorrectMarkSmall;
                first = second = false;
            }
            if (index == 5)
            {
                soundPlayer = new SoundPlayer(Resources.Roxanne);
                btnAnwser1.Text = "Roxannee";
                btnAnwser2.Text = "Just one lifetime";
                btnAnwser3.Text = "Jet pilot";
                first = true;
                pbFirst.Image = Resources.blackCorrectMarkSmall;
                pbSecond.Image = Resources.xMarkSmall;
                pbThird.Image = Resources.xMarkSmall;
                second = third = false;
            }
            if (index == 6)
            {
                soundPlayer = new SoundPlayer(Resources.Igri_Bez_Granici);
                btnAnwser1.Text = "Malechka";
                btnAnwser2.Text = "Igri bez granici";
                btnAnwser3.Text = "Polsko cvekje";
                second = true;
                pbFirst.Image = Resources.xMarkSmall;
                pbSecond.Image = Resources.blackCorrectMarkSmall;
                pbThird.Image = Resources.xMarkSmall;
                first = third = false;
            }
         //  pbFirst.Visible = pbSecond.Visible = pbThird.Visible = true;
           
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            pbFirst.Visible = true;
            pbSecond.Visible = true;
            pbThird.Visible = true;
            index = r.Next(0, 7);
            delay.Start();
           
            if (indeksi.Contains(index))
            {
                while (indeksi.Contains(index))
                {
                    index = r.Next(0, 7);
                }
            }
            timer1.Start();
            generateSong(index);
            soundPlayer.Play();
            indeksi.Add(index);
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
        }

        private void btnAnwser1_Click(object sender, EventArgs e)
        {
            //pbFirst.Visible = pbSecond.Visible = pbThird.Visible = false;
            soundPlayer.Stop();
            if (first)
            {
                Points += 300;
                lblP.Text = "Points: " + Points.ToString();
            }
            else
            {
           
            }
            pbFirst.Visible = pbSecond.Visible = pbThird.Visible = true;
            
            first = false;
            // soundPlayer.Stop();
            int i = 0;
            while (i < 99999)
            {
                i++;
            }
            timer1.Stop();
           refresh();
        }

        private void btnAnwser3_Click(object sender, EventArgs e)
        {
        
            if (third)
            {
                Points += 300;
                lblP.Text = "Points: " + Points.ToString();
            }
            else
            {
               
            }
            pbFirst.Visible = pbSecond.Visible = pbThird.Visible = true;
            Task.Delay(2000);
            third = false;
            int i = 0;
            while(i<99999)
            {
                i++;
            }
            refresh();
        }

        private void btnAnwser2_Click(object sender, EventArgs e)
        {
            pbFirst.Visible = true;
            pbSecond.Visible = true;
            pbThird.Visible = true;
           // pbFirst.Refresh();
            //pbSecond.Refresh();
            //pbThird.Refresh();
          
      //      Task.Delay(20000);
            if (second)
            {
                Points += 300;
                lblP.Text = "Points: " + Points.ToString(); 
              
                //Sound correct
            }
            else
            {
               
            }
             delay.Start();
            int i = 0;
            while (i < 9999999)
            {
                i++;
            }
            refresh();      
            second = false;

        }

        private void SoundForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            soundPlayer.Stop();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            pbFirst.Visible = false;
            pbSecond.Visible = false;
            pbThird.Visible = false;
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
             //game over sound
                this.Close();
              
            }
        }

    }
}
