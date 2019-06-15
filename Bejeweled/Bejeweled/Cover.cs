﻿using Bejeweled.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bejeweled
{
    public partial class Cover : Form
    {
        public SoundPlayer soundPlayerCover;
        
        public bool flag;
        int tick;
       
        public Cover()
        {
            InitializeComponent();
            soundPlayerCover = new SoundPlayer(Resources.Atmosphere_04);
            soundPlayerCover.Play();
             picSound.Image = Resources.SoundOn;
            picSound.Tag = "On";
           /// Form1.flagSoundIcon = true;
            flag = true;
            tick = 0;
            pictureBox1.Controls.Add(picSound); ////////SMENANO
            picSound.BackColor = Color.Transparent;

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HighScores hs = new HighScores();
            FileStream fileStream = new FileStream("HighScores.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            hs.ReadScores(fileStream);
            hs.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void picSound_Click(object sender, EventArgs e)
        {
            if (picSound.Tag.ToString() == "On")
            {
                picSound.Image = Resources.SoundOff;
                soundPlayerCover.Stop();
                Form1.flagSoundIcon = false;
                flag = false;
                picSound.Tag = "Off";
            }
            else
            {
                picSound.Image = Resources.SoundOn;
                Form1.flagSoundIcon = true;
                soundPlayerCover.Play();
                flag = true;
                picSound.Tag = "On";
            }
        }

        private void picSound_MouseHover(object sender, EventArgs e)
        {
            lblSoundHover.Visible = true;
        }
        private void picSound_MouseLeave(object sender, EventArgs e)
        {
            lblSoundHover.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
          
            if (tick % 28 == 0)
            {
                if (picSound.Tag.ToString() == "On")
                {
                    soundPlayerCover.Play();
               
                }
               
            }
        }

        private void Cover_Load(object sender, EventArgs e)
        {
            if (!Form1.flagSoundIcon)
            {
                picSound.Image = Resources.SoundOff;
                picSound.Tag = "Off";
            }
            else
            {
                picSound.Image = Resources.SoundOn;
                picSound.Tag = "On";
            }
        }
    }
}
