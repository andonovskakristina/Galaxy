using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Bejeweled
{
    public partial class SoundForm : Form
    {
        private SoundPlayer soundPlayer;
        Random r;
        int index;
        int points;
        List<int> indeksi;
        Sound song;
        int i = 0;
        
        public SoundForm()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            r = new Random();
            index = 0;
            points = 0;
            indeksi = new List<int>();
            song = new Sound();
            lblPoints.Text = "Current points: " + points.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index = r.Next(0,8);
           if(indeksi.Contains(index))
            {
                while (indeksi.Contains(index))
                {
                    index = r.Next(0, index);
                }
            }
            indeksi.Add(index);
            i++;
            song.GetSong(index);
            soundPlayer.Play();
            txtSolution.Focus();

        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            index = r.Next(0, 8);
            if (indeksi.Contains(index))
            {
                while (indeksi.Contains(index))
                {
                    index = r.Next(0, index);
                }
            }
            i++;
            indeksi.Add(index);

            song.GetSong(index);
            soundPlayer.Play();
            txtSolution.Focus();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if(txtSolution.Text != "")
            {
                if(song.Name.Equals(txtSolution.Text))
                {
                    MessageBox.Show("Well done!!");
                    points += 5;
                    lblPoints.Text = "Current points: " + points.ToString();
                    soundPlayer.Stop();
                }
                else
                {
                    MessageBox.Show("Sorry,you missed :(");
                    soundPlayer.Stop();
                }
            }
            else
            {
                MessageBox.Show("Vnesete odgovor,pa kliknete na Guess!");
            }
        }
    }
}
