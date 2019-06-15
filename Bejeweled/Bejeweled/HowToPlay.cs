using Bejeweled.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bejeweled
{
    public partial class HowToPlay : Form
    {
        int i;
        public HowToPlay()
        {
            InitializeComponent();
            KeyPreview = true;
            btnPrev.Enabled = false;
            lblText.Parent = pictureBox1;
            lblText.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            i = 0;
            btnNext.Text = "Next";
            refresh();
            pictureBox1.Controls.Add(pbSlika);
           pbSlika.BackColor = Color.Transparent;
            pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            
        }

        private void refresh()
        {
            if(i == 0)
            {
                pbSlika.Image = Resources.Slika1;
                lblText.Text = " The goal of the game is to have 3, 4 or 5 matches,\n horizontaly or verticaly";
            }else if(i == 1)
            {
                pbSlika.Image = Resources.Slika2;
                lblText.Text = " If you have four of the same, horizontaly or verticaly,\n you will make a bomb";
            }else if(i == 2){
                pbSlika.Image = Resources.Slika3;
                lblText.Text = " If you move the bomb, the elements around it will\n explode";
            }else if(i == 3){
                pbSlika.Image = Resources.Slika4;
                lblText.Text = " If you have five of the same, horizontaly or verticaly,\n you will make a superbomb";
            }else if(i == 4){
                pbSlika.Image = Resources.Slika5;
                lblText.Text = " If you move the superbomb, you will have four seconds\n to click as much elements as you can, and when the\n time ends they will explode";
            }else if(i == 5){
                pbSlika.Image = Resources.Slika6;
                lblText.Text = " You also have three helpers per game, which you can\n use only once. Each od them activate a mini game";
            }else if(i == 6)
            {
                pbSlika.Image = Resources.Slika7;
                lblText.Text = " This helper will add extra points, if your guess is\n correct.\n The mini game activated is the game Guess the sound";
            }else if(i == 7)
            {
                pbSlika.Image = Resources.Slika8;
                lblText.Text = " You have 25 seconds to guess as many songs as you\n can. For each correct song you get 300 extra points ";
            }else if(i == 8)
            {
                pbSlika.Image = Resources.Slika9;
                lblText.Text = " This helper will add extra time to your game.\n The mini game activated is the game Snake";
            }else if(i == 9)
            {
                pbSlika.Image = Resources.Slika10;
                lblText.Text = " You have 15 seconds to collect stars. You can move\n the snake with the arrow keys on you keyboard.If the\n snake eats itself, the game edns. Every star adds 5\n sec to your time";
            }else if(i == 10)
            {
                pbSlika.Image = Resources.Slika11;
                lblText.Text = " This helper will add extra bombs to your game.\n The mini game activated is the game Guess the term";
            }else if(i == 11)
            {
                pbSlika.Image = Resources.Slika12;
                lblText.Text = " You have 25 seconds to guess the terms based upon\n the pictures that are given. With every correct answer\n you get an extra bomb";
            }else if (i == 12)
            {
                pbSlika.Image = Resources.Slika13;
                lblText.Text = "";
            }
   
        }


        private void next()
        {
            btnPrev.Enabled = true;
            i++;
            refresh();
            if (i == 12)
            {
                btnNext.Text = "Play";
            }
            if (i == 13)
            {
                Form1 game = new Form1();
                this.Hide();
                game.ShowDialog();
                this.Close();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            next();
        }

        private void prev()
        {
            if (i == 12)
            {
                btnNext.Text = "Next";
            }
            i--;
            refresh();
            if (i == 0)
            {
                btnPrev.Enabled = false;
            }
        }
        private void btnSkip_Click(object sender, EventArgs e)
        {
            Cover c = new Cover();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            prev();
        }

       
       
    }
}
