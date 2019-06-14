using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bejeweled
{
    public partial class High_Scores_From : Form
    {
        public Grid g;
        PrintForm p;
        Player player;
        public High_Scores_From()
        {
            InitializeComponent();
            p = new PrintForm();
            g = new Grid();
            player = new Player();
        }
        public string text = "";
        public int score;
        public Form1 parent;

        public High_Scores_From(Form1 parent, int ticks)
        {
            this.parent = parent;
            score = ticks;
            InitializeComponent();
            name.Focus();
        }
     
        private void name_TextChanged(object sender, EventArgs e)
        {
            int length = name.TextLength;

            if (length > 10)
            {
                System.Media.SystemSounds.Asterisk.Play();
                length = 10;
            }

            if (length == 10)
            {
                name.Text = name.Text.Substring(0, 10);
                name.SelectionStart = name.TextLength;
            }
        }

        private void saveScore_Click(object sender, EventArgs e)
        {
            if (name.TextLength == 0)
            {
                MessageBox.Show("Please enter your name.");
                return;
            }
            else
            {
                player.Name = name.Text;
                player.score = parent.Points;
                g.players.Add(player);
                p.Show();
                //parent.submitHighScore(name.Text, ticks);
                
                //text = name.Text;
                ////parent.setHighScoresPanel(type, diff);
                //parent.changeView(2);
                this.Close();
            }

        }
       

        private void thanks_Click(object sender, EventArgs e)
        {
            text = "";
            this.Close();
        }

    }
}
