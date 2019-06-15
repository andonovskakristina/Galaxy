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
            btnPrev.Enabled = false;
            lblText.Parent = pictureBox1;
            lblText.BackColor = Color.Transparent;
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            i = 0;
            btnNext.Text = "Next";
            refresh();
            i++;

        }

        private void refresh()
        {
            if(i == 0)
            {
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "The goal of the game is to have 3, 4 or 5 matches, horizontaly or verticaly";
            }else if(i == 1)
            {
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "If you have four of the same, horizontaly or verticaly, you will make a bomb";
            }else if(i == 2){
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "If you move the bomb, the elements around it will explode";
            }else if(i == 3){
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "If you have five of the same, horizontaly or verticaly, you will make a superbomb";
            }else if(i == 4){
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "If you move the superbomb, you will have four seconds to click as much elements as you can, and when the time ends they will explode";
            }else if(i == 5){
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "You also have three helpers per game, which you can use only once!";
            }else if(i == 6)
            {
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "This helper will add extra points, if your guess is correct";
            }else if(i == 7)
            {
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "You have 25 seconds to guess as many songs as you can. For each correct song you get 300 extra points ";
            }else if(i == 8)
            {
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "This helper will add extra time to your game";
            }else if(i == 9)
            {
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "You have 15 seconds to collect stars. You can move the snake with the arrow keys on you keyboard.If the snake eats itself, the gae edns. Every star adds 5 sec to your time";
            }else if(i == 10)
            {
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "This helper will add extra bombs to your game";
            }else if(i == 11)
            {
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "You have 25 seconds to guess the terms based upon the pictures that are given. With every correct answer you get an extra bomb";
            }else if (i == 12)
            {
                pbSlika.Image = Resources.Slika1;
                lblText.Text = "First icon - Hint \n Second icon - Pause/Start \n Third icon Sound On/Off";
            }
   
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrev.Enabled = true;
            refresh();
            i++;
            if(i == 12)
            {
                btnNext.Text = "Play";
            }
            if(i == 1)
            {
                Form1 game = new Form1();
                this.Hide();
                game.ShowDialog();
                this.Close();
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
            refresh();
            i--;
            if(i == 0)
            {
                btnPrev.Enabled = false;
            }
        }
    }
}
